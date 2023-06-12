using Domain.Common;

namespace Domain.ValueObjects
{
    public class AuthorName : ValueObject
    {
        public Name FirstName { get; init; } = default!;
        public Name LastName { get; init; } = default!;
        public string FullName => $"{FirstName.Value} {LastName.Value}";

        public AuthorName() { }
        public AuthorName(Name firstName, Name lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
        public override string ToString()
        {
            return FullName;
        }
    }
}
