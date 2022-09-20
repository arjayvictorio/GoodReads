using DatabaseService.Models;
using GoodReadsAPI.ClassObjects;
using GoodReadsAPI.Data;
using GoodReadsAPI.Extended;
using Microsoft.AspNetCore.Mvc;

namespace GoodReadsAPI.Controllers
{
    [Route("api/[controller]/Done/[action]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        private readonly ApiContext _context;

        public ReadController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public Book Save(Book book)
        {
           return new BookService(_context).Save(book);
        }

        [HttpGet]
        public List<Book> GetAll()
        {
            return new BookService(_context).GetAll(_context);
        }

        [HttpGet]
        public Book Fetch(string name)
        {
            return new BookService(_context).Get(_context, name);
        }
    }
}
