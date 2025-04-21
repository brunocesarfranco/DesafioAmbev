# DesafioAmbev - abi-gth-omnia-developer-evaluation
Desafio técnico Ambev.

# Descrição
Este projeto foi desenvolvido em **.NET Core 8.0 (C#)**, com utilização de **MediatR**, **Postgres**, **Docker** e **Entity Framework**. Feito com objetivo de passar em um desafio tecnico proposto pela Ambev. 

## Configuração do Ambiente de Desenvolvimento
### 1. **Pré-requisitos**
Para executar este projeto, certifique-se de que as seguintes ferramentas estão instaladas em seu sistema:
- **.NET Core SDK (v8.0)**: ([Baixe aqui](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/sdk-8.0.408-windows-x64-installer))
- **Docker**: Para implantação do ambiente em containers. ([Baixe aqui](https://www.docker.com/))
- **PostgreSQL**: Para operações de banco de dados (Não será necessário em caso usar Docker)([Baixe aqui](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads))
- **Postman**: Para testar as APIs. (Ou use o Swagger já implementado) ([Baixe aqui](https://www.postman.com/downloads/))


### 2. Configurar Ambiente Docker
- 2.1 Acessar a pasta onde consta o arquivo `docker-compose.yml`
Certifique-se de navegar até o diretório correto onde está o arquivo `docker-compose.yml`.

- 2.2 Rodar o comando para iniciar o ambiente (Usando Docker)
Execute o seguinte comando no terminal para construir e iniciar os contêineres:
```
docker-compose up --build -d
```

- 2.3 Caso tenha problemas com o Docker, limpe o cache e tente iniciar os contêineres novamente:
- Em ordem, faça os seguintes comandos em terminal
    ```
    docker-compose down
    ```

    ```
    docker builder prune
    ```

    ```
    docker system prune -f
    ```


### 3. Gerar e configurar Banco de Dados (Migrations)
- 3.1 **Migrações de Banco de Dados**:
    - Após iniciar os contêineres via Docker ou instalar o Postgre localmente, vamos aplicar as migrações para criar e configurar o banco de dados
    - Execute a partir do caminho do projeto **Ambev.DeveloperEvaluation.ORM**

- 3.2 **Navegue até o projeto ORM**:
    ```bash
    cd template/backend/src/Ambev.DeveloperEvaluation.ORM
    ```

- 3.3 **Instale o Entity Framework** (Caso não tenha):
    ```
    dotnet tool install --global dotnet-ef
    ```

- 3.4 **Aplicar as migrações ao banco de dados**:
    ```
    dotnet ef database update
    ```    

- 3.5 **Criar uma nova migração** (Caso criar uma nova entidade):
    ```
    dotnet ef migrations add <NomeDaMigracao>
    ```


### 4. Para visualizar as tabelas via Docker
- 4.1 Via terminal, entre no container do PostgreSQL:
    ```
    docker exec -it ambev_developer_evaluation_database bash
    ```

- 4.2 Acesse o banco de dados com psql:
    ```
    psql -U developer -d developer_evaluation
    ``` 
    
- 4.3 Liste todas as tabelas do schema público:
    ```
    \dt public.*
    ```

- 4.4 Para ver uma tabela em espeficio só fazer consultar via SQL:
    ```
    SELECT * FROM "Users";
    ```

    ```
    SELECT * FROM "Products";
    ```

    ```
    SELECT * FROM "Sales";
    ```

    ```
    SELECT * FROM "ItemSales";
    ```

- 4.5 Para sair do psql:
    ```
    \q
    ```
    
- 4.6 Para sair do root:
    ```
    exit
    ```

### 5. Executando a Aplicação (WebAPI)
Certifique-se de que o arquivo `.csproj` correto esteja especificado na opção `--project`, se necessário.

5.1 Navegue até o projeto WebApi:
    ```bash
    cd template/backend/src/Ambev.DeveloperEvaluation.WebApi
    ```

5.2 Execute a aplicação:
    ```bash
    dotnet run
    ```

A API estará disponível, geralmente, em:
- `http://localhost:5000` ou 
- `https://localhost:5001`

Swagger disponivel em: 
- `http://localhost:5000/swagger/index.html`

Verifique a saída do console para confirmar o endereço exato.

## APIs da Aplicação
### APIs Planejadas:
- **API de Autenticação**: Gerencia login via e-mail e senha, gera token para Autenticação nos demais end-points.
- **API de Produtos**: Busca informações de produtos e gerencia estoque.
- **API de Usuários**: Gerencia cadastro de usuário, atualização e funções gerais.
- **API de Vendas**: Gerencia vendas de um ou mais produtos e calcula descontos.
    - **Regra de Negocio de Vendas**: 
        - 0 a 3 itens sem desconto.
        - 4 a 10 itens = 10% de desconto.
        - 10 a 20 itens = 20% de desconto.
        - Acima de 20 itens = Não é possivel fazer a compra.

## Problemas Comuns e Esclarecimentos
1. **Detalhes de Autenticação**:
   - Autenticação é feita apenas por e-mail.
   - O unico end-point que é possivel usar sem autenticação via Bearer Token é o Post "/api/Users" (CreateUser).


## Documentação do Postman
- CURL para importação e teste via Postman [Deixar CURL aqui].

## Dependências
### Tecnologias Principais
- **C# .NET Core 8**: Linguagem e Framework para construção da aplicação
- **MediatR**: Aplica o padrão Mediator, centralizando a comunicação entre classes.
- **PostgreSQL**: Banco de Dados Relacional.
- **Docker**: Containerização da aplicação e seus serviços para facilitar o desenvolvimento e implantação em diferentes ambientes
- **Entity Framework**: ORM para interações com o banco de dados


## Observações Adicionais
- Certifique-se de que as dependencias de ambiente estejam instaladas na versão correta e funcionando.
- Certifique-se de que o Docker esteja em execução antes de iniciar a migration.


## Controle de Releases
v0.1: Versão inicial não estável
v0.2: Versão com ambiente e conexão estáveis (CreateUser, GetUserById e GetAllUsers)

## Testes Funcionais

[Adicionar Imagens]
