using System.ComponentModel.DataAnnotations;

namespace MyBookListBLL.Requests
{
    public class UpdateBookRequest
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookType { get; set; }
        [Required]
        public string Overview { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
