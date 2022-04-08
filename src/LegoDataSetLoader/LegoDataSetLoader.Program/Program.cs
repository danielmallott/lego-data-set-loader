using LegoDataSetLoader.Data;
using LegoDataSetLoader.Data.Models;
using LegoDataSetLoader.Program.CsvMappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LegoDataSetLoader.Program;

using IHost host = Host.CreateDefaultBuilder(args).UseEnvironment("Development").Build();

var connectionString = host.Services.GetRequiredService<IConfiguration>().GetValue<string>("ConnectionStrings:Default");
var contextOptions = new DbContextOptionsBuilder<LegoContext>().UseSqlServer(connectionString).Options;
var dbContext = new LegoContext(contextOptions);

var dataLoader = new DataLoader();

await dataLoader.Load<Minifig, MinifigsMap, string>(dbContext, "../../source-data/minifigs.csv", m => m.MinifigNumber);
await dataLoader.Load<Color, ColorsMap, int>(dbContext, "../../source-data/colors.csv", c => c.ColorId);
await dataLoader.Load<PartCategory, PartCategoriesMap, int>(dbContext, "../../source-data/part_categories.csv", pc => pc.PartCategoryId);
await dataLoader.Load<Part, PartsMap, string>(dbContext, "../../source-data/parts.csv", p => p.PartNumber);
await dataLoader.Load<Element, ElementsMap, string>(dbContext, "../../source-data/elements.csv", e => e.ElementId);
await dataLoader.Load<PartRelationship, PartRelationshipsMap, string>(dbContext, "../../source-data/part_relationships.csv", pr => string.Concat(pr.ParentPartNumber, "~", pr.ChildPartNumber, "~", pr.RelationshipType));
await dataLoader.Load<Theme, ThemesMap, int>(dbContext, "../../source-data/themes.csv", t => t.ThemeId);
await dataLoader.Load<Set, SetsMap, string>(dbContext, "../../source-data/sets.csv", s => s.SetNumber);
await dataLoader.Load<Inventory, InventoriesMap, int>(dbContext, "../../source-data/inventories.csv", i => i.InventoryId);
await dataLoader.LoadBulk<LegoDataSetLoader.Program.PlainTypes.InventoryPart, LegoDataSetLoader.Data.Models.InventoryPart, InventoryPartsMap, string>(dbContext, "../../source-data/inventory_parts.csv", ip => string.Concat(ip.InventoryId, "~", ip.PartNumber, "~", ip.ColorId, "~", ip.IsSpare), ip => string.Concat(ip.InventoryId, "~", ip.PartNumber, "~", ip.ColorId, "~", ip.IsSpare), "EXEC DataLoad.LoadInventoryParts @data", "@data", "EXEC DataLoad.UpdateInventoryParts @data", "@data", "DataLoad.InventoryParts");
await dataLoader.Load<InventoryMinifig, InventoryMinifigsMap, string>(dbContext, "../../source-data/inventory_minifigs.csv", im => string.Concat(im.InventoryId, "~", im.MinifigNumber));
await dataLoader.Load<InventorySet, InventorySetsMap, string>(dbContext, "../../source-data/inventory_sets.csv", i => string.Concat(i.SetNumber, "~", i.InventoryId));

await dbContext.DisposeAsync();

await host.RunAsync();