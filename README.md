# Shop-Api
O objetivo dessa api é para estudo e pratica de autenticação e autorização utilizando EntityFrameworkCore.Identity, escolhi usar a arquitetura clean por algumas de suas vantagens como: separação de responsabilidades, organização do código, flexibilidade, facilidade de manutenção entre outras.

## Tecnologias utilizadas
- ASP.NET Core 5.0
- Microsoft.EntityFrameworkCore.InMemory 5.0.8
- Microsoft.EntityFrameworkCore.SqlServer 5.0.8
- Microsoft.EntityFrameworkCore.Design 5.0.8
- Microsoft.AspNetCore.Identity.EntityFrameworkCore 5.0.8
- Microsoft.AspNetCore.Authentication.JwtBearer 5.0.8
- Microsoft.IdentityModel.Tokens 6.14.0
- System.IdentityModel.Tokens.Jwt 6.14.0
- Microsoft.AspNetCore.Identity 2.2.0
- Swagger
- AutoMapper.Extensions.Microsoft.DependencyInjection 8.1.1

## Pré-requisitos
Visual Studio 2019 ou superior
.NET 5.0 SDK


## Executando a API
1. Clone o repositório:
```bash
 git clone https://github.com/caio2296/Registro-Api.git
 ```
2. Abra o projeto no Visual Studio

3. Use alguma ferramenta como o Postman ou o Swagger para testar os endpoints.

Alguns dos Endpoints disponíveis GetUser /api/account - Retorna o usuário. Register /api/account - Cria um usuário.
