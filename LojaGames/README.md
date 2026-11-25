# GameZone - Loja de Videogames

Projeto adaptado do material original, mantendo ASP.NET Core MVC, C#, DAO e SQLite.

## Tecnologias
- C# / ASP.NET Core MVC (.NET 8)
- SQLite com `Microsoft.Data.Sqlite`
- Razor Views
- Bootstrap 5 e Bootstrap Icons

## Como executar
1. Instale o .NET 8 SDK.
2. Abra `LojaGames.sln` no Visual Studio ou entre na pasta `LojaGames`.
3. Execute `dotnet restore`.
4. Execute `dotnet run`.
5. Acesse o endereço informado no terminal.

O banco `loja_games.db` é criado automaticamente na primeira execução e recebe três produtos de exemplo.

## Estrutura
- `Controllers/`: área pública, área restrita e controller padrão.
- `Models/`: classe Produto e modelo de erro.
- `Dao/`: consultas e operações de produtos no SQLite.
- `Data/`: conexão e criação do banco.
- `Views/`: telas Razor públicas e administrativas.
- `wwwroot/`: arquivos estáticos e bibliotecas do projeto original.

A área administrativa é demonstrativa e não possui autenticação. Não utilize em produção sem implementar login, autorização e validação adicional.
