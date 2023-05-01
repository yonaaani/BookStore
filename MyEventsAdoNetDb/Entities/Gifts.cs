using Dapper_Example.DAL;
using System.Collections.Generic;

namespace MyEventsAdoNetDb.Entities
{
    public class Gifts
    {
        public Gifts()
        {

        }

        public Gifts(string giftName, string giftText, int giftPrice)
        {
            this.GiftName = giftName;
            this.GiftText = giftText;
            this.GiftPrice = giftPrice;
        }

        public string GiftName { get; set; }
        public string GiftText { get; set; }
        public int GiftPrice { get; set; }
        public int IDUser { get; set; }
        public Users Users { get; set; }
        public virtual ICollection<BooksAndGifts> BooksAndGifts { get; set; }
    }
}