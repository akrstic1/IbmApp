using System.ComponentModel.DataAnnotations;

namespace IbmApp.Web.Models
{
    public class RentBook
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string RentTo { get; set; }
    }
}
