# parkingPOC
### Prova de Conceito .net Backend ###

# POC  de um sistema de controle de entrada e saída de estacionamento

# Abordagens
* Generic Repository
* Dependency Injection
* Unit Test (Mock Framework)
* EntityFrameworkCore(Code Fisrt)
* EF Core Migrations
* Dapper
* Authentication (JWT)
* REST

# Como  preparar o Ambiente e testar a aplicação

1. Abrir a Solution e realizar o build
2. Rodar os Testes Unitários a fim de verificar o comportamento da aplicação (Test Explorer)
3. Ajustar as credenciais de acesso ao database desejado em appsettings
4. através do Package Console Manager, e a partir do projeto Infra\ParkingPOC.Infra, rodar o comando Update-Database
5. Rodar o projeto
6. Utilize uma ferramenta para consumir api´s (como o Postman) e adicione um usuario.
    Ex.:
    url: https://localhost:44311/api/v1/Usuarios (POST)
    {"Nome":"usuarioZero", "Usuario":"usuario0", "Password":"my@password"}

7. Realizar o login, com o objetivo de capturar o bearer token para utilização nos demais Requests
    url: https://localhost:44311/api/v1/Usuarios/Login (POST)
    {"Usuario":"usuario0", "Password":"my@password"}

8. Para cada chamada. será necessário adicionar o Authorization bearer com o token devolvido no login
9. Incluir um ou mais estabelecimentos 
    url: https://localhost:44311/api/v1/estabelecimentos (POST)
    { "Nome":"RedePar", "CNPJ":"57.856.583/0001-74", "Endereco": "Avenida Ana Costa, 259, Santos", "Telefone": "13 2522-3567", "PosicoesVagasMotos": 2, "PosicoesVagasCarros": 3}
10. Incluir um ou mais veículos
    url: https://localhost:44311/api/v1/veiculos (POST)
    { "Marca":"Honda", "Modelo":"Elite 125", "Cor": "Vermelha", "Placa": "CGI2500", "Tipo": 2}
    { "Marca":"Honda", "Modelo":"Elite 125", "Cor": "Vermelha", "Placa": "CGI2500", "Tipo": 0}
11. Incluir um carro em um estacionamento.
    url: https://localhost:44311/api/v1/veiculos (POST)
    { "EstabelecimentoId":"4FB6C9C4-9CFC-480D-6FF0-08D84D215035", "VeiculoId":"8F92CD13-C7AF-4A98-A606-08D84D220A72", "Movimento":0}
12. Retirar um carro do estacionamento
    url: https://localhost:44311/api/v1/OperacoesVaga (POST)
    { "EstabelecimentoId":"4FB6C9C4-9CFC-480D-6FF0-08D84D215035", "VeiculoId":"8F92CD13-C7AF-4A98-A606-08D84D220A72", "Movimento":1}]
13. Incluir uma moto no estacionamento
    url: https://localhost:44311/api/v1/OperacoesVaga (POST)
    { "EstabelecimentoId":"4FB6C9C4-9CFC-480D-6FF0-08D84D215035", "VeiculoId":"F1A3BFC1-5580-4CBC-A607-08D84D220A72", "Movimento":0}
14. Retirar uma moto do estacionamento
    url: https://localhost:44311/api/v1/OperacoesVaga (POST)
     { "EstabelecimentoId":"4FB6C9C4-9CFC-480D-6FF0-08D84D215035", "VeiculoId":"F1A3BFC1-5580-4CBC-A607-08D84D220A72", "Movimento":1}   
15. Listar os estabelecimentos cadastrados
    url: https://localhost:44311/api/v1/estabelecimentos (GET)
16. Gerar o relatorio
    url: https://localhost:44311/api/v1/relatorios (GET)
    
