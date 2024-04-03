﻿using Azure;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepositoryManager _manager;

        public BooksController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _manager.Book.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _manager.Book.GetOneBookById(id, false);

                if (book == null)
                    return NotFound();
                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest();
                _manager.Book.CreateOneBook(book);
                _manager.Save();

                return StatusCode(201, book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                //check book?

                var entity = _manager.Book.GetOneBookById(id, true);

                if (entity is null)
                {
                    return NotFound();
                }

                // check id?

                if (id != book.Id)
                    return BadRequest();

                entity.Title = book.Title;
                entity.Price = book.Price;
                _manager.Save();

                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = _manager.Book.GetOneBookById(id, false);

                if (entity is null)
                {
                    return NotFound(new
                    {
                        statusCode = 404,
                        message = $"Book with id:{id} could not found."
                    });

                    _manager.Book.DeleteOneBook(entity);
                    _manager.Save();

                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name ="id")] int id, 
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                //check

                var entity = _manager.Book.GetOneBookById(id,true);
                if (entity is null) return NotFound(); //404

                bookPatch.ApplyTo(entity);
                _manager.Book.Update(entity);

                return NoContent();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

    }
}
