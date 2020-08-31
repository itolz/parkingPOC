using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;

namespace ParkingPOC.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService; 
        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService; 
        }

        [HttpGet]
        [Authorize]
        public ActionResult<EstabelecimentoReport> Report()
        {
            return Ok(_relatorioService.Listar());
        }
    }
}
