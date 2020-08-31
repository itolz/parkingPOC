﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingPOC.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReadmeController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<string> Report()
        {
            return Ok("readme");
        }
    }
}
