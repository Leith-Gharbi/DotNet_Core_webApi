using DotNet_Core_webApi.ActionResults;
using DotNet_Core_webApi.Data.Models;
using DotNet_Core_webApi.Data.Services;
using DotNet_Core_webApi.Data.ViewModels;
using DotNet_Core_webApi.Exceptions;
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
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            try
            {
                var newPublisher = _publishersServices.AddPublisher(publisherVM);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name : {ex.PublisherName} ");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersServices.GetPublisherData(id);
            return Ok(_response);


        }
        [HttpGet("get-publisher-by_id/{id}")]
       // public ActionResult<Publisher> GetPublisherById(int id)
        public CustomActionResult GetPublisherById(int id)
        {

            //throw new Exception("this is an exception that will be handled by middeleware ");
            var _response = _publishersServices.GetPublisherById(id);
            if (_response != null)
            {
                var _responseObj = new CustomActionResultVM()
                {
                    Publisher = _response
                };

                return new CustomActionResult(_responseObj);
               // return _response;
                //return Ok(_response);
            }else {
                var _responseObj = new CustomActionResultVM()
                {
                    Exception = new Exception("this is comming from publisher controller")
            };

            return new CustomActionResult(_responseObj);
            }
        }
        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {

            try
            {
                _publishersServices.DeletePublisherById(id);
                return Ok();
            }
            catch (ArithmeticException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            finally
            {
                string stopHere = "";
            }
        }
    }
}
