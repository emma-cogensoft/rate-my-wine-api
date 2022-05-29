namespace Api.Requests;

public class UpdateBeverageRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ManufacturerId { get; set; }
}