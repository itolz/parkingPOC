using Microsoft.EntityFrameworkCore;
using ParkingPOC.Services.Interfaces.Repository;
using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ParkingPOC.Infra
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly ParkingPOCAPIContext _context;
        private readonly IConfiguration _configuration; 
      

        public OcorrenciaRepository(ParkingPOCAPIContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration; 
        }

        public async void Incluir(Ocorrencia ocorrencia)
        {
            _context.Ocorrencia.Add(ocorrencia);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<EstabelecimentoReport>> Listar()
        {
            string sqlcommand = string.Concat(  "select E.Nome as Estabelecimento, ",          
                                                "OcorrenciaEntrada.QuantidadeEntradaVeiculos, ",
                                                "OcorrenciaSaida.QuantidadeSaidaVeiculos ",
                                                "from ",
                                                "Estabelecimento E with (nolock) ",
                                                "inner join ",
                                                "(select OE.EstabelecimentoId, count(1) as QuantidadeEntradaVeiculos ",
                                                "from Ocorrencia OE with(nolock) ",
                                                "where OE.Movimento = 0 ",
                                                "group by OE.EstabelecimentoId ",
                                                ") OcorrenciaEntrada ",
                                                "on OcorrenciaEntrada.EstabelecimentoId = E.Id ",
                                                "inner join ",
                                                "(select OS.EstabelecimentoId, count(1) as QuantidadeSaidaVeiculos ",
                                                "from Ocorrencia OS with(nolock) ",
                                                "where OS.Movimento = 1 ",
                                                "group by OS.EstabelecimentoId) OcorrenciaSaida ",
                                                "on OcorrenciaSaida.EstabelecimentoId = E.Id ");

            using (SqlConnection conexao = new SqlConnection(_configuration.GetConnectionString("ParkingPOCAPIContext")))
            {
                return await  conexao.QueryAsync<EstabelecimentoReport>(sqlcommand);
            }
        }
    }
}
