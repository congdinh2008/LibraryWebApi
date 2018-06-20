using LibraryApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    [Route("api")]
    public class RootController : ControllerBase
    {
        private readonly IUrlHelper _urlHelper;

        public RootController(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        [HttpGet(Name ="GetRoot")]
        public IActionResult GetRoot(
            [FromHeader(Name ="Accept")] string mediaType)
        {
            if (mediaType == "application/vnd.vivustore.hateoas+json")
            {
                var links = new List<LinkDto>();

                links.Add(new LinkDto(_urlHelper.Link("GetRoot",
                    new { }), 
                    "self",
                    "GET"));

                links.Add(new LinkDto(_urlHelper.Link("GetAuthors",
                    new { }),
                    "authors", 
                    "GET"));

                links.Add(new LinkDto(_urlHelper.Link("CreateAuthor",
                    new { }), 
                    "create_author", 
                    "POST"));

                return Ok(links);
            }

            return NoContent();
        }
    }
}
