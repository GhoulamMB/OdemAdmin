namespace OdemAdmin.Models;

public class Address
{
    public required string Id { get; init; }
    public required string Street { get; init; }
    public required string City { get; init; }
    public required string ZipCode { get; init; }
}