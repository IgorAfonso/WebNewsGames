# WebNewsGames

WebNewsGames é uma aplicação de notícias, artigos e campeonatos do universo de jogos. O repositório é único para frontend e backend, por isso a raiz funciona como documentação geral do projeto e cada pasta mantém a responsabilidade de uma parte da aplicação.

## Estrutura do repositório

```text
WebNewsGames/
├── backend/   # API, domínio, persistência, IoC e testes em .NET
├── frontend/  # Aplicação web em Next.js
├── README.md  # Documentação principal do monorepo
└── LICENSE
```

## Backend

O backend está em `backend/src/WebGames` e foi estruturado em camadas para separar entrada HTTP, orquestração de casos de uso, regras de domínio, persistência e configuração de dependências.

### Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- PostgreSQL via `Npgsql.EntityFrameworkCore.PostgreSQL`
- Swagger/OpenAPI via `Swashbuckle.AspNetCore`
- NUnit para testes
- Dockerfile para execução da API em container

### Projetos da solução

```text
backend/src/WebGames/
├── WebGames.API/                    # Controllers, Program.cs, Swagger, CORS e appsettings
├── WebGames.Application/            # AppServices, requests e responses da API
├── WebGames.Domain/                 # Entidades, interfaces e serviços de domínio
├── WebGames.Infra/                  # EF Core, DbContext, mappings, migrations e repositories
├── WebGames.Infra.CrossCutting/     # Projeto cross-cutting base
├── WebGames.Infra.CrossCutting.IoC/ # Registro de injeção de dependência
├── WebGames.Test/                   # Projeto de testes
└── WebGames.slnx
```

### Responsabilidade das camadas

| Camada | Responsabilidade |
| --- | --- |
| `WebGames.API` | Expõe endpoints HTTP, configura Swagger, CORS, HTTPS, controllers e pipeline da aplicação. |
| `WebGames.Application` | Define contratos de entrada e saída e centraliza AppServices que orquestram operações da aplicação. |
| `WebGames.Domain` | Contém entidades, contratos de repositório, contratos de serviços de domínio e validações de regra de negócio. |
| `WebGames.Infra` | Implementa acesso a dados com EF Core, `DbContext`, mapeamentos, migrations e repositories. |
| `WebGames.Infra.CrossCutting.IoC` | Registra dependências da aplicação, domínio, repositórios e `DbContext`. |
| `WebGames.Test` | Projeto reservado para testes automatizados com NUnit. |

### Configuração da API

Arquivo principal:

```text
backend/src/WebGames/WebGames.API/appsettings.json
```

Configuração atual de banco:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=webgames;Username=postgres;Password=1234"
  }
}
```

Em desenvolvimento, a API usa os perfis definidos em:

```text
backend/src/WebGames/WebGames.API/Properties/launchSettings.json
```

URLs locais configuradas:

- HTTP: `http://localhost:5181`
- HTTPS: `https://localhost:7261`
- Swagger em desenvolvimento: `/swagger`

### CORS

A política `DevelopmentCorsPolicy` permite chamadas do frontend nas seguintes origens:

- `http://localhost:3001`
- `https://localhost:3001`

Se o frontend rodar em outra porta, ajuste a lista em `WebGames.API/Program.cs`.

### Injeção de dependência

O registro central fica em:

```text
backend/src/WebGames/WebGames.Infra.CrossCutting.IoC/DependencyInjectionConfig.cs
```

Dependências registradas:

- `WebGamesDbContext` usando PostgreSQL e a connection string `DefaultConnection`
- AppServices:
  - `IArticlesAppService` -> `ArticlesAppService`
  - `IChampionshipAppService` -> `ChampionshipAppService`
  - `INewsAppService` -> `NewsAppService`
- Domain Services:
  - `IArticleDomainService` -> `ArticleDomainService`
  - `IChampionshipDomainService` -> `ChampionshipDomainService`
  - `INewsDomainService` -> `NewsDomainService`
- Repositories:
  - `IArticleRepository` -> `ArticleRepository`
  - `IChampionshipRepository` -> `ChampionshipRepository`
  - `INewsRepository` -> `NewsRepository`

### Banco de dados

O backend usa PostgreSQL com Entity Framework Core.

`WebGamesDbContext` expõe os seguintes `DbSet`s:

| DbSet | Entidade | Tabela |
| --- | --- | --- |
| `Artigos` | `Article` | `artigos` |
| `Campeonatos` | `Championship` | `campeonatos` |
| `Noticias` | `News` | `noticias` |

Mappings:

- `ArticleMapping`
- `ChampionshipMapping`
- `NewsMapping`

Migration existente:

- `20260501000000_InitialCreate`

### Entidades

Todas as entidades herdam de `BaseEntity`.

#### BaseEntity

| Campo | Tipo | Descrição |
| --- | --- | --- |
| `Id` | `Guid` | Identificador único. |
| `CreateDate` | `DateTime` | Data de criação. |
| `UpdateDate` | `DateTime` | Data da última atualização. |

#### Article

| Campo | Tipo | Descrição |
| --- | --- | --- |
| `Id` | `Guid` | Identificador herdado de `BaseEntity` e retornado nas respostas de artigo. |
| `Title` | `string?` | Título do artigo. |
| `Content` | `string?` | Conteúdo principal. |
| `PublishedDate` | `DateTime` | Data de publicação. |
| `AuthorId` | `Guid?` | Identificador do autor. |
| `SecondContent` | `string?` | Conteúdo secundário. |

Tabela `artigos`:

- `titulo` é obrigatório e tem tamanho máximo de 200 caracteres.
- `conteudo` é obrigatório.
- `conteudo_secundario` é opcional.
- `autor_id` é opcional.

#### Championship

| Campo | Tipo | Descrição |
| --- | --- | --- |
| `Name` | `string?` | Nome do campeonato. |
| `Description` | `string?` | Descrição do campeonato. |
| `StartDate` | `DateTime` | Data de início. |
| `EndDate` | `DateTime` | Data de término. |

Tabela `campeonatos`:

- `nome` é obrigatório e tem tamanho máximo de 200 caracteres.
- `descricao` é obrigatória e tem tamanho máximo de 1000 caracteres.

#### News

| Campo | Tipo | Descrição |
| --- | --- | --- |
| `Title` | `string?` | Título da notícia. |
| `Content` | `string?` | Conteúdo da notícia. |
| `PublishedAt` | `DateTime` | Data de publicação. |

Tabela `noticias`:

- `titulo` é obrigatório e tem tamanho máximo de 200 caracteres.
- `conteudo` é obrigatório.

### Repositories

Os repositórios concretos herdam de `RepositoryBase<TEntity>`.

Operações disponíveis:

| Método | Descrição |
| --- | --- |
| `AddAsync` | Gera `Id` quando vazio, preenche `CreateDate` e `UpdateDate`, adiciona a entidade e salva. |
| `GetByIdAsync` | Busca uma entidade por `Id` usando `AsNoTracking`. |
| `GetAllAsync` | Lista entidades ordenadas por `CreateDate` decrescente. |
| `UpdateAsync` | Atualiza `UpdateDate`, marca a entidade para update e salva. |
| `DeleteAsync` | Busca por `Id`, remove se existir e salva. |

### Serviços de domínio

Os serviços de domínio validam regras antes da persistência ou retorno.

#### ArticleDomainService

- Criação e atualização exigem `Title` e `Content`.
- Exclusão e busca exigem `Id` diferente de `Guid.Empty`.
- Listagem retorna sucesso.

#### ChampionshipDomainService

- Criação e atualização exigem `Name` e `Description`.
- Exclusão e busca por `Id` exigem `Guid` válido.

#### NewsDomainService

- Criação exige `Title` e `Content`.
- Busca, atualização e exclusão exigem `Id` válido.

### Endpoints

As respostas seguem o formato padronizado pelo `BaseController`.

#### Artigos

Base route:

```text
/api/v1/article
```

| Método | Rota | Parâmetros | Body | Descrição |
| --- | --- | --- | --- | --- |
| `GET` | `/api/v1/article` | Query `request: string` | Não | Busca artigo por nome/título. |
| `GET` | `/api/v1/article/id` | Query `Id: Guid` | Não | Busca artigo por identificador. |
| `POST` | `/api/v1/article` | Não | `PostArticleRequest` | Cria artigo. |
| `PATCH` | `/api/v1/article` | Não | `PatchArticleRequest` | Atualiza artigo. |
| `DELETE` | `/api/v1/article` | Query `Id: Guid` | Não | Remove artigo. |

Body de criação:

```json
{
  "title": "string",
  "content": "string"
}
```

Body de atualização:

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "title": "string",
  "content": "string"
}
```

#### Campeonatos

Base route:

```text
/api/v1/championship
```

| Método | Rota | Parâmetros | Body | Descrição |
| --- | --- | --- | --- | --- |
| `GET` | `/api/v1/championship` | Query `request: string` | Não | Busca campeonato por nome. |
| `GET` | `/api/v1/championship/id` | Query `Id: Guid` | Não | Busca campeonato por identificador. |
| `POST` | `/api/v1/championship` | Não | `PostChampionshipRequest` | Cria campeonato. |
| `PATCH` | `/api/v1/championship` | Não | `PatchChampionshipRequest` | Atualiza campeonato. |
| `DELETE` | `/api/v1/championship` | Query `Id: Guid` | Não | Remove campeonato. |

Body de criação:

```json
{
  "championshipName": "string",
  "championshipDescription": "string",
  "registrationDeadLine": "2026-05-01T00:00:00Z",
  "champDate": "2026-05-01T00:00:00Z"
}
```

Body de atualização:

```json
{
  "champId": "00000000-0000-0000-0000-000000000000",
  "championshipName": "string",
  "championshipDescription": "string",
  "registrationDeadLine": "2026-05-01T00:00:00Z",
  "champDate": "2026-05-01T00:00:00Z"
}
```

#### Notícias

Base route:

```text
/api/v1/news
```

| Método | Rota | Parâmetros | Body | Descrição |
| --- | --- | --- | --- | --- |
| `GET` | `/api/v1/news` | Query `request: string` | Não | Busca notícia por nome/título. |
| `GET` | `/api/v1/news/id` | Query `Id: Guid` | Não | Busca notícia por identificador. |
| `POST` | `/api/v1/news` | Não | `PostNewsRequest` | Cria notícia. |
| `PATCH` | `/api/v1/news` | Não | `PatchNewsRequest` | Atualiza notícia. |
| `DELETE` | `/api/v1/news` | Query `Id: Guid` | Não | Remove notícia. |

Body de criação:

```json
{
  "title": "string",
  "content": "string"
}
```

Body de atualização:

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "title": "string",
  "content": "string"
}
```

### Formato de resposta

Sucesso em operações `GET`, `PATCH` e `DELETE`:

```json
{
  "success": true,
  "message": "Success to process the request.",
  "data": {}
}
```

Sucesso sem dados:

```json
{
  "success": true,
  "message": "Success to process the request."
}
```

Criação com sucesso:

```json
{
  "success": true,
  "message": "Success to process the request.",
  "data": {}
}
```

Falha:

```json
{
  "success": false,
  "message": "Failed to process the request."
}
```

### Como executar o backend localmente

Pré-requisitos:

- .NET SDK 10
- PostgreSQL
- Banco `webgames` criado localmente

Passos:

```powershell
cd backend/src/WebGames
dotnet restore
dotnet build
dotnet run --project WebGames.API/WebGames.API.csproj
```

A API ficará disponível em:

```text
http://localhost:5181
```

Em ambiente de desenvolvimento, acesse:

```text
http://localhost:5181/swagger
```

### Migrations

Executar migrations existentes:

```powershell
cd backend/src/WebGames
dotnet ef database update --project WebGames.Infra/WebGames.Infra.Data.csproj --startup-project WebGames.API/WebGames.API.csproj
```

Criar uma nova migration:

```powershell
cd backend/src/WebGames
dotnet ef migrations add NomeDaMigration --project WebGames.Infra/WebGames.Infra.Data.csproj --startup-project WebGames.API/WebGames.API.csproj
```

### Testes

Executar testes:

```powershell
cd backend/src/WebGames
dotnet test
```

### Docker

O backend possui `Dockerfile` em:

```text
backend/src/WebGames/WebGames.API/Dockerfile
```

O container expõe:

- `8080`
- `8081`

### Estado atual da implementação

- A estrutura de API, domínio, infraestrutura, IoC, migrations e repositories está criada.
- Os controllers expõem rotas para notícias, artigos e campeonatos.
- O EF Core está configurado para PostgreSQL.
- Os AppServices executam o CRUD usando os repositories da Infra e validam as operações com os serviços de domínio.
- O Swagger só é habilitado em ambiente `Development`.

## Frontend

O frontend está em:

```text
frontend/webnewsgames
```

Ele é mantido no mesmo repositório para facilitar a evolução conjunta entre interface e API. Ao integrar com o backend local, mantenha a porta do frontend compatível com a política de CORS configurada no backend ou atualize `Program.cs` conforme necessário.
