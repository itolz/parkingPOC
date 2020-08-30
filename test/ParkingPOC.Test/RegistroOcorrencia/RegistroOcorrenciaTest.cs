using System;
using Xunit;
using Moq;
using Services.Interfaces;
using ParkingPOC.Services.Models;
using System.Threading.Tasks;
using ParkingPOC.Services.Services;
using ParkingPOC.Services.Interfaces;

namespace ParkingPOC.Test
{
    public class RegistroOcorrenciaTest
    {
        [Theory]
        [InlineData(1,  OcorrenciaStatus.VeiculoEstacionadoComSucesso, "Esta operação deveria ter permitido o estacionamento de um carro!")]
        [InlineData(0,  OcorrenciaStatus.EstacionamentoLotado, "O Estacionamento de carros está lotado. Nenhuma ocorrencia deveria retornar com sucesso!")]
        public void EstacionamentoCarro(int posicoesVagasCarros,  OcorrenciaStatus statusAguardado,  string errorMessage)
        {

            var estabelecimento = new Estabelecimento
            {
                Id = new Guid("3b60f69c-f052-4d6d-b439-2cfd26eed720"),
                CNPJ = "57.856.583/0001-74",
                Endereco = "Avenida Ana Costa, 259, Santos",
                Nome = "RedePar",
                PosicoesVagasCarros = posicoesVagasCarros,
                PosicoesVagasMotos = 0,
                Telefone = "13 2522-3567"
            };

            var veiculoCarro= new Veiculo
            {
                Id = new Guid("4dfbfafd-1122-449a-82b8-a81e924adc1a"),
                Marca = "Nissan",
                Modelo = "Livina X-Gear",
                Cor = "Branca",
                Placa = "FTY-1183",
                Tipo = VeiculoTipo.Carro
            };

            var estabecimentoRepo = new Mock<IGenericRepository<Estabelecimento>>();
            estabecimentoRepo.Setup(x => x.Selecionar(estabelecimento.Id)).Returns(Task.FromResult(estabelecimento));

            var veiculoRepo = new Mock<IGenericRepository<Veiculo>>();
            veiculoRepo.Setup(x => x.Selecionar(veiculoCarro.Id)).Returns(Task.FromResult(veiculoCarro));

            IVeiculoService veiculoService = new VeiculoService(veiculoRepo.Object);
            IEstabelecimentoService estabelecimentoService = new EstabelecimentoService(estabecimentoRepo.Object);
            IOperarVagasService OperarVagas = new OperarVagasService(veiculoService, estabelecimentoService);


            var ocorrencia = new Ocorrencia { EstabelecimentoId = estabelecimento.Id, Movimento = TipoMovimento.entrada, VeiculoId = veiculoCarro.Id };

            var resultadoOcorrencia = OperarVagas.Executar(ocorrencia).Result;

            int posicoesVagaCarrosAguardada = (posicoesVagasCarros - 1 > 0) ? posicoesVagasCarros - 1 : 0; 

            Assert.Equal(posicoesVagaCarrosAguardada, resultadoOcorrencia.PosicoesVagasCarrosAtualizada);
            Assert.True(resultadoOcorrencia.Status == statusAguardado, errorMessage);
        }

        [Theory]
        [InlineData(1, OcorrenciaStatus.VeiculoEstacionadoComSucesso, "Esta operação deveria ter permitido o estacionamento de uma moto!")]
        [InlineData(0, OcorrenciaStatus.EstacionamentoLotado, "O Estacionamento de motos está lotado. Nenhuma ocorrencia deveria retornar com sucesso!")]
        public void EstacionamentoMoto(int posicoesVagasMotos, OcorrenciaStatus statusAguardado, string errorMessage)
        {

            var estabelecimento = new Estabelecimento
            {
                Id = new Guid("3b60f69c-f052-4d6d-b439-2cfd26eed720"),
                CNPJ = "57.856.583/0001-74",
                Endereco = "Avenida Ana Costa, 259, Santos",
                Nome = "RedePar",
                PosicoesVagasCarros = 0,
                PosicoesVagasMotos = posicoesVagasMotos,
                Telefone = "13 2522-3567"
            };

            var veiculoMoto = new Veiculo
            {
                Id = new Guid("eb005874-95bd-49d7-ab8d-95b9738bbe22"),
                Marca = "Honda",
                Modelo = "Elite 125",
                Cor = "Vermelha",
                Placa = "CGI-2500",
                Tipo = VeiculoTipo.Moto
            };


            var estabecimentoRepo = new Mock<IGenericRepository<Estabelecimento>>();
            estabecimentoRepo.Setup(x => x.Selecionar(estabelecimento.Id)).Returns(Task.FromResult(estabelecimento));

            var veiculoRepo = new Mock<IGenericRepository<Veiculo>>();
            veiculoRepo.Setup(x => x.Selecionar(veiculoMoto.Id)).Returns(Task.FromResult(veiculoMoto));

            IVeiculoService veiculoService = new VeiculoService(veiculoRepo.Object);
            IEstabelecimentoService estabelecimentoService = new EstabelecimentoService(estabecimentoRepo.Object);
            IOperarVagasService OperarVagas = new OperarVagasService(veiculoService, estabelecimentoService);


            var ocorrencia = new Ocorrencia { EstabelecimentoId = estabelecimento.Id, Movimento = TipoMovimento.entrada, VeiculoId = veiculoMoto.Id };

            var resultadoOcorrencia = OperarVagas.Executar(ocorrencia).Result;

            int posicoesVagaMotosAguardada = (posicoesVagasMotos - 1 > 0) ? posicoesVagasMotos - 1 : 0;

            Assert.Equal(posicoesVagaMotosAguardada, resultadoOcorrencia.PosicoesVagasMotosAtualizada);
            Assert.True(resultadoOcorrencia.Status == statusAguardado, errorMessage);
        }

        [Fact]
        public void SaidaCarro()
        {

  
            var estabelecimento = new Estabelecimento
            {
                Id = new Guid("3b60f69c-f052-4d6d-b439-2cfd26eed720"),
                CNPJ = "57.856.583/0001-74",
                Endereco = "Avenida Ana Costa, 259, Santos",
                Nome = "RedePar",
                PosicoesVagasCarros = 0,
                PosicoesVagasMotos = 0,
                Telefone = "13 2522-3567"
            };

            var veiculoCarro = new Veiculo
            {
                Id = new Guid("4dfbfafd-1122-449a-82b8-a81e924adc1a"),
                Marca = "Nissan",
                Modelo = "Livina X-Gear",
                Cor = "Branca",
                Placa = "FTY-1183",
                Tipo = VeiculoTipo.Carro
            };



            var estabecimentoRepo = new Mock<IGenericRepository<Estabelecimento>>();
            estabecimentoRepo.Setup(x => x.Selecionar(estabelecimento.Id)).Returns(Task.FromResult(estabelecimento));

            var veiculoRepo = new Mock<IGenericRepository<Veiculo>>();
            veiculoRepo.Setup(x => x.Selecionar(veiculoCarro.Id)).Returns(Task.FromResult(veiculoCarro));

            IVeiculoService veiculoService = new VeiculoService(veiculoRepo.Object);
            IEstabelecimentoService estabelecimentoService = new EstabelecimentoService(estabecimentoRepo.Object);
            IOperarVagasService operarVagas = new OperarVagasService(veiculoService, estabelecimentoService);

            var ocorrencia = new Ocorrencia { EstabelecimentoId = estabelecimento.Id, Movimento = TipoMovimento.saida, VeiculoId = veiculoCarro.Id };

            var resultadoOcorrencia = operarVagas.Executar(ocorrencia).Result;

            Assert.Equal(1, resultadoOcorrencia.PosicoesVagasCarrosAtualizada);
            Assert.True(resultadoOcorrencia.Status == OcorrenciaStatus.VeiculoLiberado, "Uma vaga de carro deveria ter sido liberada");
        }


        [Fact]
        public void SaidaMoto()
        {

            var estabelecimento = new Estabelecimento
            {
                Id = new Guid("3b60f69c-f052-4d6d-b439-2cfd26eed720"),
                CNPJ = "57.856.583/0001-74",
                Endereco = "Avenida Ana Costa, 259, Santos",
                Nome = "RedePar",
                PosicoesVagasCarros = 0,
                PosicoesVagasMotos = 0,
                Telefone = "13 2522-3567"
            };

            var veiculoMoto = new Veiculo
            {
                Id = new Guid("eb005874-95bd-49d7-ab8d-95b9738bbe22"),
                Marca = "Honda",
                Modelo = "Elite 125",
                Cor = "Vermelha",
                Placa = "CGI-2500",
                Tipo = VeiculoTipo.Moto
            };


            var estabecimentoRepo = new Mock<IGenericRepository<Estabelecimento>>();
            estabecimentoRepo.Setup(x => x.Selecionar(estabelecimento.Id)).Returns(Task.FromResult(estabelecimento));

            var veiculoRepo = new Mock<IGenericRepository<Veiculo>>();
            veiculoRepo.Setup(x => x.Selecionar(veiculoMoto.Id)).Returns(Task.FromResult(veiculoMoto));

            IVeiculoService veiculoService = new VeiculoService(veiculoRepo.Object);
            IEstabelecimentoService estabelecimentoService = new EstabelecimentoService(estabecimentoRepo.Object);
            IOperarVagasService OperarVagas = new OperarVagasService(veiculoService, estabelecimentoService);


            var ocorrencia = new Ocorrencia { EstabelecimentoId = estabelecimento.Id, Movimento = TipoMovimento.saida, VeiculoId = veiculoMoto.Id };


            var resultadoOcorrencia = OperarVagas.Executar(ocorrencia).Result;

            Assert.Equal(1, resultadoOcorrencia.PosicoesVagasMotosAtualizada);
            Assert.True(resultadoOcorrencia.Status == OcorrenciaStatus.VeiculoLiberado, "Uma vaga de carro deveria ter sido liberada");
        }
    }
}
