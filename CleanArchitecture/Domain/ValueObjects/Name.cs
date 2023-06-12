using System.Text.RegularExpressions;
using Domain.Common;

namespace Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string Value { get; } = default!;

        public Name() { }
        public Name(string value)
        {
            if (!IsValid(value))
                throw new ArgumentException("Name is not valid");

            Value = value;
        }


        public static bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}