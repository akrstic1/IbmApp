using IbmApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IbmApp.Web.Models.Dtos
{
    public class BookDto
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public float Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public string RentedBy { get; set; }

        public static BookDto ToBookDto(Book book)
        {
            return new BookDto()
            {
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                Price = book.Price,
                PublishDate = book.PublishDate,
                Description = book.Description,
            };
        }
    }
}
