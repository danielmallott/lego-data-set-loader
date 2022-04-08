namespace LegoDataSetLoader.Program.PlainTypes;

public class InventoryPart
{
    public int InventoryId { get; set; }
    public string PartNumber { get; set; } = null!;
    public int ColorId { get; set; }
    public int? Quantity { get; set; }
    public bool? IsSpare { get; set; }
}