using IbmApp.Model;
using IbmApp.Models;
using IbmApp.Service;
using IbmApp.Web.Models;
using IbmApp.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IbmApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICatalogService _catalogService;

        List<BookDto> books;

        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;

            GetBooksFromDatastore();
        }

        public IActionResult Index()
        {
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> GetForm(string bookId)
        {
            if (bookId == null)
            {
                return View("Index", books);
            }
            BookDto bookDtoToRent = books.First(x => x.Id == bookId);

            RentBook bookToRent = new RentBook()
            {
                Id = bookDtoToRent.Id,
                Author = bookDtoToRent.Author,
                Title = bookDtoToRent.Title,
            };

            return PartialView("_RentForm", bookToRent);
        }

        [HttpPost]
        public async Task<IActionResult> RentBook(RentBook bookToRent)
        {
            if (String.IsNullOrEmpty(bookToRent.Id) || String.IsNullOrEmpty(bookToRent.RentTo) || !String.IsNullOrEmpty(books.Find(x => x.Id == bookToRent.Id).RentedBy))
            {
                return View("Index", books);
            }

            books.Find(x => x.Id == bookToRent.Id).RentedBy = bookToRent.RentTo;
            _catalogService.UpdateCatalogInDatastore(new Catalog()
            {
                Books = books.Select(x => BookDto.ToBook(x)).ToList()
            });

            GetBooksFromDatastore();

            return View("Index", books);
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(string bookIdToReturn)
        {
            if (String.IsNullOrEmpty(bookIdToReturn))
            {
                return View("Index");
            }

            books.Find(x => x.Id == bookIdToReturn).RentedBy = null;
            _catalogService.UpdateCatalogInDatastore(new Catalog()
            {
                Books = books.Select(x => BookDto.ToBook(x)).ToList()
            });

            GetBooksFromDatastore();

            return PartialView("_BookTable", books);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void GetBooksFromDatastore()
        {
            books = _catalogService.GetCatalogFromDatastore().Books.Select(x => BookDto.ToBookDto(x)).ToList();
        }
    }
}
