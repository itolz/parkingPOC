using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;

namespace ParkingPOC.API.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class OperacoesVagaController : ControllerBase
    {

        private readonly IOperarVagasService _operarVagaService;

        public OperacoesVagaController(IOperarVagasService operarVagaService)
        {
            _operarVagaService = operarVagaService;
        }

        [HttpPost]
        [Authorize]
        public  ActionResult<OcorrenciaResultado> Post([FromBody] Ocorrencia ocorrencia)
        {
           var ocorrenciaResultado =  _operarVagaService.Executar(ocorrencia);

            return Ok(ocorrenciaResultado);
        }


        [HttpGet]
        [Authorize]
        public ActionResult<OcorrenciaResultado> Report([FromBody] Ocorrencia ocorrencia)
        {
            var ocorrenciaResultado = _operarVagaService.Executar(ocorrencia);

            return Ok(ocorrenciaResultado);
        }
    }
}
