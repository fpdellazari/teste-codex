# Pessoas API (.NET 8)

API com arquitetura em camadas seguindo princípios de DDD + Clean Architecture:

- `PessoasApi.Domain`: Entidades e contratos de domínio.
- `PessoasApi.Application`: Casos de uso (sorteio de nomes medievais).
- `PessoasApi.Infrastructure`: EF Core + SQLite e implementação de repositórios.
- `PessoasApi.API`: Camada de apresentação HTTP.

## Endpoint

- `GET /api/pessoas?gender=m`
- `GET /api/pessoas?gender=f`

### Regras

- O parâmetro `gender` é obrigatório.
- Valores aceitos:
  - `m`: sorteia 1 nome medieval masculino (entre 200 opções).
  - `f`: sorteia 1 nome medieval feminino (entre 200 opções).

Resposta de exemplo:

```json
{
  "id": "d9764e0c-355c-4f72-bdd8-3bd307af5afe",
  "name": "Aldric Ironwood"
}
```

## Como executar

```bash
dotnet restore
dotnet run --project src/PessoasApi.API/PessoasApi.API.csproj
```

Swagger em ambiente de desenvolvimento.
