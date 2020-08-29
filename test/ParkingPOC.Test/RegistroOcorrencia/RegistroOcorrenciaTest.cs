using System;
using Xunit;
using Moq;
using Services.Interfaces;
using ParkingPOC.Services.Models;
using System.Threading.Tasks;
using ParkingPOC.Services.Services;

namespace ParkingPOC.Test
{
    public class RegistroOcorrenciaTest
    {
        [Theory]
        [InlineData(1, "Esta operação deveria ter permitido o estacionamento de um carro!")]
        [InlineData(0, "O Estacionamento de carros está lotado. Nenhuma ocorrencia deveria retornar com sucesso!")]
        public void SaidaAutomovel(int posicoesVagasCarros, string errorMessage)
        {

            var idEstabelecimento = Guid.NewGuid();
            var idVeiculo = Guid.NewGuid();

            var estabelecimento = new Estabelecimento
            {
                Id = idEstabelecimento,
                CNPJ = "57.856.583/0001-74",
                Endereco = "Avenida Ana Costa, 259, Santos",
                Nome = "RedePar",
                PosicoesVagasCarros = posicoesVagasCarros,
                PosicoesVagasMotos = 2,
                Telefone = "13 2522-3567"
            };

            var estabecimentoRepo = new Mock<IGenericRepository<Estabelecimento>>();
            estabecimentoRepo.Setup(x => x.Selecionar(idEstabelecimento)).Returns(Task.FromResult(estabelecimento));


            var EstabelecimentoService = new RegistrarOcorrenciaService(estabecimentoRepo.Object);

            var ocorrencia = new Ocorrencia { EstabelecimentoId = idEstabelecimento, Movimento = TipoMovimento.entrada, VeiculoId = idVeiculo };


            var resultadoOcorrencia = EstabelecimentoService.Executar(ocorrencia);


            Assert.Equal(posicoesVagasCarros - 1, resultadoOcorrencia.PosicoesVagasCarrosAtualizada);
            Assert.True(resultadoOcorrencia.Status == OcorrenciaStatus.VeiculoEstacionadoComSucesso, errorMessage);
        }
    }
}
