using Domain.Common;

namespace Domain.ValueObjects;

public class Rating : ValueObject
{
    public int Value { get; set; }

    private Rating() { }

    public Rating(int value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator int(Rating value) => value.Value;

    public static implicit operator Rating(int value) => new(value);
}
