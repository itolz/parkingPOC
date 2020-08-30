using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPOC.Services.Models
{
    public enum OcorrenciaStatus
    {
        VeiculoEstacionadoComSucesso, 
        VeiculoLiberado,
        EstacionamentoLotado,
        VeiculoNaoCadastrado,
        ErroDesconhecido
    }
}
