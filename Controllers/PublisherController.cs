using DotNet_Core_webApi.Data.Services;
using DotNet_Core_webApi.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {

        private PublishersService _publishersServices;
        public PublisherController(PublishersService publishersService)
        {
            _publishersServices = publishersService;
        }
        [HttpPost("add-publisher")]
        public IActionResult AddAuthor([FromBody] PublisherVM publisherVM)
        {
            _publishersServices.AddPublisher(publisherVM);
            return Ok();
        }


    }
}
