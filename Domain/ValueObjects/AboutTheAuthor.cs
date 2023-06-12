using System.Text.RegularExpressions;
using Domain.Common;

namespace Domain.ValueObjects
{
    public class AboutTheAuthor : ValueObject
    {
        public int Year { get; } = default!;

        public AboutTheAuthor() { }
        public AboutTheAuthor(int year)
        {
            if (!IsValid(year))
                throw new ArgumentException("Year is not valid");
        }

        private bool IsValid(int year)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Year;
        }
    }
}
