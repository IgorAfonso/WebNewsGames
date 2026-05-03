# Agent Guide

WebNewsGames e um monorepo para uma aplicacao de noticias, artigos, comunidade e campeonatos de jogos. Use este arquivo como onboarding rapido para agentes; detalhes extensos ficam nos READMEs e nos arquivos-fonte apontados aqui.

Referencia de escrita: https://www.humanlayer.dev/blog/writing-a-good-claude-md. Mantenha este guia curto, universal e baseado em ponteiros para codigo canonico.

## Mapa do repositorio

```text
WebNewsGames/
  backend/                  # API .NET, dominio, EF Core, autenticacao e testes
  frontend/                 # Aplicacao web Next.js
  README.md                 # Documentacao geral do monorepo
  agent.md                  # Guia operacional para agentes
```

## Aplicacoes

### Frontend

Local: `frontend/webnewsgames`

Stack principal:

- Next.js 15 com App Router
- React 19
- TypeScript
- Tailwind CSS 4
- Axios
- lucide-react

Estrutura relevante:

- `app/`: rotas e layouts. Rotas atuais: home, `login`, `register`, `community`, `championships`.
- `components/`: componentes agrupados por pagina ou responsabilidade visual.
- `services/`: cliente Axios, autenticacao, cadastro e dados mockados.
- `models/` e `types/`: contratos TypeScript usados pela interface.
- `assets/` e `public/`: imagens e assets estaticos.

Pontos canonicos:

- `frontend/webnewsgames/package.json`: scripts e dependencias.
- `frontend/webnewsgames/app/layout.tsx`: layout raiz e metadata.
- `frontend/webnewsgames/app/page.tsx`: composicao da home.
- `frontend/webnewsgames/services/api.ts`: instancia Axios e interceptor de token.
- `frontend/webnewsgames/services/AuthService.ts`: login, logout e estado local de autenticacao.
- `frontend/webnewsgames/services/RegisterUser.ts`: cadastro de usuarios.

Configuracao esperada:

- O frontend roda em `http://localhost:3001`.
- Defina `NEXT_PUBLIC_API_URL` apontando para a API, normalmente `http://localhost:5181/api/v1`.
- `NEXT_PUBLIC_LOGIN_ENDPOINT` e `NEXT_PUBLIC_REGISTER_ENDPOINT` sao opcionais; os defaults sao `/auth/login` e `/auth/users`.

Comandos:

```powershell
cd frontend/webnewsgames
npm install
npm run dev
npm run build
```

Observacao: o script `lint` esta como `next lint`; confirme compatibilidade antes de tratar falha desse comando como regressao, pois versoes recentes do Next podem exigir ajuste no script.

### Backend

Local: `backend/src/WebGames`

Stack principal:

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- PostgreSQL via Npgsql
- ASP.NET Core Identity com JWT Bearer
- Swagger/OpenAPI
- NUnit

Projetos da solucao:

- `WebGames.API`: controllers, `Program.cs`, Swagger, CORS e pipeline HTTP.
- `WebGames.Application`: AppServices, requests, responses, mappers e paginacao.
- `WebGames.Domain`: entidades, interfaces e servicos de dominio.
- `WebGames.Infra`: `DbContext`, mappings, migrations e repositories EF Core.
- `WebGames.CrossCutting.Authentication`: Identity, JWT, usuario atual e seed de roles/admin.
- `WebGames.Infra.CrossCutting.IoC`: registro de injecao de dependencia.
- `WebGames.Test`: testes NUnit de dominio e controllers.

Fluxo padrao de uma feature backend:

```text
Controller -> AppService -> DomainService -> Repository -> WebGamesDbContext
```

Pontos canonicos:

- `backend/src/WebGames/WebGames.API/Program.cs`: pipeline, Swagger, CORS, auth e seed.
- `backend/src/WebGames/WebGames.API/Controllers/`: endpoints HTTP.
- `backend/src/WebGames/WebGames.Infra.CrossCutting.IoC/DependencyInjectionConfig.cs`: DI central.
- `backend/src/WebGames/WebGames.Infra/Context/WebGamesDbContext.cs`: EF Core + IdentityDbContext.
- `backend/src/WebGames/WebGames.Infra/Mapping/`: nomes de tabelas, colunas e limites.
- `backend/src/WebGames/WebGames.Domain/Service/`: validacoes de regra de negocio.
- `backend/src/WebGames/WebGames.Application/AppService/`: orquestracao dos casos de uso.
- `backend/src/WebGames/WebGames.CrossCutting.Authentication/AuthenticationConfig.cs`: Identity e JWT.

Entidades principais:

- `News`: noticias com ate tres blocos de conteudo/imagem/legenda.
- `Article`: artigos com autoria e ate tres blocos de conteudo/imagem/legenda.
- `Championship`: campeonatos com sistema, local, datas e modo exibicional.

Rotas base:

- `api/v1/auth`
- `api/v1/news`
- `api/v1/article`
- `api/v1/championship`

Autorizacao atual:

- `GET` de noticias, artigos e campeonatos e publico.
- Criar, alterar e excluir noticias exige `Administrator`.
- Criar, alterar e excluir campeonatos exige `Administrator`.
- Criar artigos exige `Administrator` ou `User`.
- Alterar e excluir artigos exige `Administrator` ou o proprio autor.

Configuracao local:

- API HTTP: `http://localhost:5181`
- API HTTPS: `https://localhost:7261`
- Swagger em desenvolvimento: `http://localhost:5181/swagger`
- Banco esperado: PostgreSQL local, database `webgames`.
- Connection string default: `backend/src/WebGames/WebGames.API/appsettings.json`.
- CORS permite `http://localhost:3001` e `https://localhost:3001`.

Comandos:

```powershell
cd backend/src/WebGames
dotnet restore
dotnet build
dotnet test
dotnet run --project WebGames.API/WebGames.API.csproj
```

Migrations:

```powershell
cd backend/src/WebGames
dotnet ef database update --project WebGames.Infra/WebGames.Infra.Data.csproj --startup-project WebGames.API/WebGames.API.csproj
dotnet ef migrations add NomeDaMigration --project WebGames.Infra/WebGames.Infra.Data.csproj --startup-project WebGames.API/WebGames.API.csproj
```

## Regras para trabalhar neste repo

- Antes de alterar comportamento, localize o fluxo real no codigo. Nao dependa apenas deste arquivo.
- Preserve a separacao de camadas do backend: controllers nao devem conter regra de dominio ou acesso direto ao banco.
- Ao adicionar endpoint backend, atualize controller, request/response, mapper, AppService, DomainService, repository/interface se necessario, DI e testes.
- Ao alterar contratos da API, confira tambem os services e types do frontend.
- Toda modificacao estrutural no projeto deve atualizar tambem este `agent.md`, incluindo novas aplicacoes, pastas principais, camadas, fluxos de arquitetura, comandos essenciais ou mudancas de configuracao.
- Use os comandos deterministicos do projeto para verificar mudancas: `dotnet test` no backend e `npm run build` no frontend.
- Nao coloque segredos reais em `appsettings.json` ou arquivos versionados. Prefira User Secrets, variaveis de ambiente ou configuracao local ignorada pelo Git.
- Dados mockados do frontend vivem em `services/Get*.tsx`; integre com a API via `services/api.ts` quando substituir mocks.
- Mantenha este arquivo curto. Para detalhes longos, crie docs especificos e aponte para eles aqui.
