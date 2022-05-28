namespace EverybodyCodes.Api.QueryParams;

public class DivisibleByGetParams
{
    public IEnumerable<int>? Numbers { get; set; }
    public bool Negation { get; set; }
}