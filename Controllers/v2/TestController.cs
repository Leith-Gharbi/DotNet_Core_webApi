using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Controllers.v2
{
    [ApiVersion("2.0")]

  [Route("api/[controller]")]
  //  [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-data")]
        public IActionResult GetV2()
        {
            return Ok("this is TestController V2");
        }


        [HttpGet("get-test-data") , MapToApiVersion("2.1")]
        public IActionResult GetV21()
        {
            return Ok("this is TestController V21");
        }

        [HttpGet("get-test-data"), MapToApiVersion("2.9")]
        public IActionResult GetV29()
        {
            return Ok("this is TestController V29");
        }
    }
}
