using Bookstore.Communication.Responses;
using Bookstore.DataStore;
using Bookstore.Entity;
using Microsoft.AspNetCore.Mvc;


namespace Bookstore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{

    private static DataStoreService<Book> _book = new();

    [HttpGet]
    [ProducesResponseType(typeof(Book[]), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(_book.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        return Ok(_book.Get(id));
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] Book book)
    {
        _book.Create(book);
        return Ok(book);
    }

    [HttpPut]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status201Created)]
    public IActionResult Update([FromBody] Book book)
    {
        _book.Update(book);
        return Ok(book);
    }


    [HttpDelete]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromBody] Book book)
    {
        _book.Delete(book);
        return Ok(book);
    }

}
