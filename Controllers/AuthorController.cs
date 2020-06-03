using System;
using System.Collections.Generic;
using FlexNewsApi.Models;
using FlexNewsApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlexNewsApi.Controllers
{
  [ApiController]
  public class AuthorController : ControllerBase
  {
    protected readonly IAuthorRepository _authorRepository;

    public AuthorController([FromServices] IAuthorRepository authorRepository)
    {
      _authorRepository = authorRepository;
    }

    [HttpGet, Route("v1/authors")]
    public ActionResult<IEnumerable<Author>> GetAll()
    {
      try
      {
        var authors = _authorRepository.GetAll();
        return Ok(authors);
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { message = ex.Message });
      }      
    }
  }
}