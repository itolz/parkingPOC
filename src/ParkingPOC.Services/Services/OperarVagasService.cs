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
        IIncluirOcorrenciaService _incluirOcorrrenciaService;
        public OperarVagasService(  IVeiculoService veiculoService, 
                                    IEstabelecimentoService estabelecimentoService, 
                                    IIncluirOcorrenciaService incluirOcorrenciaService)
        {
            _veiculoService = veiculoService;
            _estabelecimentoService = estabelecimentoService;
            _incluirOcorrrenciaService = incluirOcorrenciaService;

        }


        public OcorrenciaResultado Executar(Ocorrencia ocorrencia)
        {
            OcorrenciaResultado resultado = new OcorrenciaResultado();
            resultado.EstabelecimentoId = ocorrencia.EstabelecimentoId;

            var veiculo = _veiculoService.Selecionar(ocorrencia.VeiculoId).Result;

            if (veiculo == null)
                resultado.Status = OcorrenciaStatus.VeiculoNaoCadastrado;
            else
            {
                var estabelecimento = _estabelecimentoService.Selecionar(ocorrencia.EstabelecimentoId).Result;

                switch (veiculo.Tipo)
                {
                    case VeiculoTipo.Carro:
                        if (ocorrencia.Movimento == TipoMovimento.entrada)
                          EstacionarCarro(resultado, estabelecimento, ocorrencia);
                        else 
                            LiberarCarro(resultado, estabelecimento, ocorrencia);
                        break;
                    case VeiculoTipo.Moto:
                        if (ocorrencia.Movimento == TipoMovimento.entrada)
                           EstacionarMoto(resultado, estabelecimento, ocorrencia);
                        else
                            LiberarMoto(resultado, estabelecimento, ocorrencia);
                        break;
                }

                _estabelecimentoService.Atualizar(ocorrencia.EstabelecimentoId, estabelecimento);

                resultado.PosicoesVagasCarrosAtualizada = estabelecimento.PosicoesVagasCarros;
                resultado.PosicoesVagasMotosAtualizada = estabelecimento.PosicoesVagasMotos;
            }

            return resultado;
        }

        private void EstacionarMoto(OcorrenciaResultado resultado, Estabelecimento estabelecimento, Ocorrencia ocorrencia)
        {
            if (estabelecimento.PosicoesVagasMotos > 0)
            {
                resultado.Status = OcorrenciaStatus.VeiculoEstacionadoComSucesso;
                estabelecimento.PosicoesVagasMotos--;
                _incluirOcorrrenciaService.Executar(ocorrencia);
            }

            else
                resultado.Status = OcorrenciaStatus.EstacionamentoLotado;

        }

        private void LiberarMoto(OcorrenciaResultado resultado, Estabelecimento estabelecimento, Ocorrencia ocorrencia)
        {
            resultado.Status = OcorrenciaStatus.VeiculoLiberado;
            estabelecimento.PosicoesVagasMotos++;
            _incluirOcorrrenciaService.Executar(ocorrencia);

        }

        private void LiberarCarro(OcorrenciaResultado resultado, Estabelecimento estabelecimento, Ocorrencia ocorrencia)
        {
            resultado.Status = OcorrenciaStatus.VeiculoLiberado;
            estabelecimento.PosicoesVagasCarros++;
            _incluirOcorrrenciaService.Executar(ocorrencia);

        }

        private void EstacionarCarro(OcorrenciaResultado resultado, Estabelecimento estabelecimento, Ocorrencia ocorrencia)
        {
            if (estabelecimento.PosicoesVagasCarros > 0)
            {
                resultado.Status = OcorrenciaStatus.VeiculoEstacionadoComSucesso;
                estabelecimento.PosicoesVagasCarros--;
                 _incluirOcorrrenciaService.Executar(ocorrencia);
            }

            else
                resultado.Status = OcorrenciaStatus.EstacionamentoLotado;

        }

    }
}
