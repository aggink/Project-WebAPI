namespace Company.WPF.Models.Product;

#nullable disable

public class BulatProduct
{
    public Guid Id { get; set; }
    public Guid PropertyParserId { get; set; }
    public string URL { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Article { get; set; }
    public string Weight { get; set; }
    public string Vendor { get; set; }
    public string CodeProduct { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Availability { get; set; }
    public string AvailabilityType { get; set; }
    public string Color { get; set; }
    public string Compatibility { get; set; }
    public string LengthWidthHeight { get; set; }
    public string Model { get; set; }
    public string AnalogProduct { get; set; }
    public double Resource { get; set; }
    public string TypeProduct { get; set; }
    public string TypeEquipment { get; set; }
    public string OriginallyProduct { get; set; }
    public string SeriesProduct { get; set; }
    public decimal PriceFrom5 { get; set; }
    public decimal PriceFrom10 { get; set; }
}

#nullable enable