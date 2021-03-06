
using Models;
using Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BooksApi.Controllers;
using System.Collections;

namespace Controllers
{
    

    public class BooksController : BaseApiController
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Book>> Get() =>
            _bookService.Get();

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> Get(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            _bookService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book._id.ToString() }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Book bookIn)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Remove(book._id);

            return NoContent();
        }


        [HttpGet]
        [Route("categories")]
        public List<string> GetCategories() {
            List<string> categories = _bookService.GetCategories();
            HashSet<string> hashset = new HashSet<string>();
            categories.RemoveAll(x=> !hashset.Add(x));
            return categories;
        }


        [HttpGet]
        [Route("authors")]
        public string[] GetAuthors() {
            string[] authors = _bookService.GetAuthors();
            return authors;
        }
    }
}