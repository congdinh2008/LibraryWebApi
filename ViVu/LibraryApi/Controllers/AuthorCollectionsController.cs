using AutoMapper;
using LibraryApi.Dtos;
using LibraryApi.Extensions;
using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.Controllers
{
    [Route("api/authorcollections")]
    public class AuthorCollectionsController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;

        public AuthorCollectionsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet("({ids})", Name = "GetAuthorCollection")]
        public IActionResult GetAuthorCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
                return BadRequest();

            var authorModels = _libraryRepository.GetAuthors(ids);

            if (ids.Count() != authorModels.Count())
                return NotFound();

            var authorsToReturn = Mapper.Map<IEnumerable<AuthorDto>>(authorModels);
            return Ok(authorsToReturn);
        }

        [HttpPost]
        public IActionResult CreateAuthorCollection(
            [FromBody] IEnumerable<AuthorForCreateDto> authorCollection)
        {
            if (authorCollection == null)
                return BadRequest();

            var authorModels = Mapper.Map<IEnumerable<Author>>(authorCollection);
            foreach (var author in authorModels)
            {
                _libraryRepository.AddAuthor(author);
            }

            if (!_libraryRepository.Save())
                throw new Exception("Creating an author collection failed on save.");

            var authorCollectionToReturn = Mapper.Map<IEnumerable<AuthorDto>>(authorModels);
            var idsAsString = string.Join(",", authorCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetAuthorCollection",
                new { ids = idsAsString }, authorCollectionToReturn);
        }
    }
}