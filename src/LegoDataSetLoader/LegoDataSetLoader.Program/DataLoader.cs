using System.Data;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using LegoDataSetLoader.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ToDataTable;

namespace LegoDataSetLoader.Program;

public class DataLoader
{
    public async Task Load<T, TMap, TIdType>(LegoContext dbContext, string path, Func<T, TIdType> idSelector) 
        where T : class 
        where TMap : ClassMap<T>
        where TIdType : notnull
    {
        using (var reader = new StreamReader(path))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csvReader.Context.RegisterClassMap<TMap>();
            var records = csvReader.GetRecordsAsync<T>();
            int counter = 1;
            
            var existingIds = dbContext.Set<T>().AsNoTracking().Select(idSelector).ToList();

            await foreach (var record in records)
            {
                if (existingIds.Contains(idSelector(record)))
                {
                    var attach = dbContext.Attach(record);
                    attach.State = EntityState.Modified;
                }
                else
                {
                    dbContext.Add(record);
                }

                if (counter == 1000)
                {
                    await dbContext.SaveChangesAsync();
                    counter = 0;
                }
                counter++;
            }
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task LoadBulk<T, TEFType, TMap, TIdType>(LegoContext dbContext, string path, Func<T, TIdType> idSelector, Func<TEFType, TIdType> efIdSelector, string loadStoredProcedure, string loadStoredProcedureParameterName, string updateStoredProcedure, string updateStoredProcedureParameterName, string tableType)
        where T : class
        where TEFType : class
        where TMap : ClassMap<T>
        where TIdType : notnull
    {
        using (var reader = new StreamReader(path))
        using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csvReader.Context.RegisterClassMap<TMap>();
            var records = csvReader.GetRecordsAsync<T>();

            var existingIds = dbContext.Set<TEFType>().AsNoTracking().Select(efIdSelector).ToList();
            var recordsToUpdate = new List<T>();
            var recordsToInsert = new List<T>();
            int counter = 1;

            await foreach(var record in records)
            {
                if (existingIds.Contains(idSelector(record)))
                {
                    recordsToUpdate.Add(record);
                }
                else
                {
                    recordsToInsert.Add(record);
                }

                if (counter == 10000)
                {
                    var loopInsertTable = new SqlParameter(loadStoredProcedureParameterName, SqlDbType.Structured);
                    loopInsertTable.Value = recordsToInsert.ToDataTable();
                    loopInsertTable.TypeName = tableType;
                    await dbContext.Database.ExecuteSqlRawAsync(loadStoredProcedure, loopInsertTable);
                    var loopUpdateTable = new SqlParameter(updateStoredProcedureParameterName, SqlDbType.Structured);
                    loopUpdateTable.Value = recordsToUpdate.ToDataTable();
                    loopUpdateTable.TypeName = tableType;
                    await dbContext.Database.ExecuteSqlRawAsync(updateStoredProcedure, loopUpdateTable);
                    recordsToInsert.Clear();
                    recordsToUpdate.Clear();
                    counter = 0;
                }
                counter++;
            }

            var insertTable = new SqlParameter(loadStoredProcedureParameterName, SqlDbType.Structured);
            insertTable.Value = recordsToInsert.ToDataTable();
            insertTable.TypeName = tableType;
            await dbContext.Database.ExecuteSqlRawAsync(loadStoredProcedure, insertTable);
            var updateTable = new SqlParameter(updateStoredProcedureParameterName, SqlDbType.Structured);
            updateTable.Value = recordsToUpdate.ToDataTable();
            updateTable.TypeName = tableType;
            await dbContext.Database.ExecuteSqlRawAsync(updateStoredProcedure, updateTable);
        }
    }
}