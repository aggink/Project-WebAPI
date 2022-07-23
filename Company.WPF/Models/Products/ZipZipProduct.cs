namespace Company.WPF.Models.Product;

#nullable disable

public class ZipZipProduct
{
    public Guid Id { get; set; }
    public Guid PropertyParserId { get; set; }
    public string URL { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Article { get; set; }
    public string Compatibility { get; set; }
    public string Availability { get; set; }
    public string AvailabilityType { get; set; }
    public decimal Price { get; set; }
    public string OriginallyProduct { get; set; }
    public string Category { get; set; }
}

#nullable enable