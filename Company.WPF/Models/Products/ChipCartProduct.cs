namespace Company.WPF.Models.Product;

#nullable disable

public class ChipCartProduct
{
    public Guid Id { get; set; }
    public Guid PropertyParserId { get; set; }
    public string URL { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Article { get; set; }
    public decimal Price { get; set; }
    public string Availability { get; set; }
    public string AvailabilityType { get; set; }
    public string Weight { get; set; }
    public string Vendor { get; set; }
    public string CodeProduct { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string PrinterCompatibility { get; set; }
    public string CartridgeCompatibility { get; set; }
    public string TypeProduct { get; set; }
}

#nullable enable