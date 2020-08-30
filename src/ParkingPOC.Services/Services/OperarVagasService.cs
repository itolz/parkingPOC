using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;
using System;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Services
{
    public class OperarVagasService : IOperarVagasService
    {
        IVeiculoService _veiculoService;
        IEstabelecimentoService _estabelecimentoService;
        public OperarVagasService(IVeiculoService veiculoService, IEstabelecimentoService estabelecimentoService)
        {
            _veiculoService = veiculoService;
            _estabelecimentoService = estabelecimentoService;
        }


        public async Task<OcorrenciaResultado> Executar(Ocorrencia ocorrencia)
        {
            OcorrenciaResultado resultado = new OcorrenciaResultado();
            resultado.EstabelecimentoId = ocorrencia.EstabelecimentoId;

            var veiculo = await _veiculoService.Selecionar(ocorrencia.VeiculoId);

            if (veiculo == null)
                resultado.Status = OcorrenciaStatus.VeiculoNaoCadastrado;
            else
            {
                var estabelecimento = await _estabelecimentoService.Selecionar(ocorrencia.EstabelecimentoId);

                switch (veiculo.Tipo)
                {
                    case VeiculoTipo.Carro:
                        if (ocorrencia.Movimento == TipoMovimento.entrada)
                            EstacionarCarro(resultado, estabelecimento);
                        else 
                            LiberarCarro(resultado, estabelecimento);
                        break;
                    default:
                        if (ocorrencia.Movimento == TipoMovimento.entrada)
                            EstacionarMoto(resultado, estabelecimento);
                        else
                            LiberarMoto(resultado, estabelecimento);
                        break;
                }

                await _estabelecimentoService.Atualizar(ocorrencia.EstabelecimentoId, estabelecimento);

                resultado.PosicoesVagasCarrosAtualizada = estabelecimento.PosicoesVagasCarros;
                resultado.PosicoesVagasMotosAtualizada = estabelecimento.PosicoesVagasMotos;
            }

            return resultado;
        }

        private void EstacionarMoto(OcorrenciaResultado resultado, Estabelecimento estabelecimento)
        {
            if (estabelecimento.PosicoesVagasMotos > 0)
            {
                resultado.Status = OcorrenciaStatus.VeiculoEstacionadoComSucesso;
                estabelecimento.PosicoesVagasMotos--;
            }

            else
                resultado.Status = OcorrenciaStatus.EstacionamentoLotado;
        }

        private void LiberarMoto(OcorrenciaResultado resultado, Estabelecimento estabelecimento)
        {
            resultado.Status = OcorrenciaStatus.VeiculoLiberado;
            estabelecimento.PosicoesVagasMotos++;
        }

        private void LiberarCarro(OcorrenciaResultado resultado, Estabelecimento estabelecimento)
        {
            resultado.Status = OcorrenciaStatus.VeiculoLiberado;
            estabelecimento.PosicoesVagasCarros++;
        }

        private void EstacionarCarro(OcorrenciaResultado resultado, Estabelecimento estabelecimento)
        {
            if (estabelecimento.PosicoesVagasCarros > 0)
            {
                resultado.Status = OcorrenciaStatus.VeiculoEstacionadoComSucesso;
                estabelecimento.PosicoesVagasCarros--;
            }

            else
                resultado.Status = OcorrenciaStatus.EstacionamentoLotado;
        }

    }
}
