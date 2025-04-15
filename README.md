# DesafioAmbev - abi-gth-omnia-developer-evaluation
Desafio técnico Ambev.

# Descrição

Este projeto foi desenvolvido usando **C# .NET Core**, com integrações para **RabbitMQ**, **Rebus** e **Entity Framework**. Feito com objetivo de passar em um desafio tecnico proposto pela Ambev. 

---

## 1. Configuração do Ambiente de Desenvolvimento

### 1.1 Pré-requisitos
Para executar este projeto, certifique-se de que as seguintes ferramentas estão instaladas em seu sistema:
- **.NET Core SDK (v8.0)**: [Baixe aqui](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/sdk-8.0.408-windows-x64-installer)
- **Docker** (opcional): Para implantação em containers
- **RabbitMQ**: Configuração do sistema de mensageria ([Guia de configuração do RabbitMQ](https://www.rabbitmq.com/documentation.html))
- **PostgreSQL**: Para operações de banco de dados ([Baixe aqui](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads))
- **Postman**: Para testar as APIs ([Documentação do Postman]())

## 2. Como Executar

### 2.1 Migrações de Banco de Dados
- Antes de executar a aplicação, configure o banco de dados criando e aplicando as migrações
- Execute a partir do caminho do projeto **Ambev.DeveloperEvaluation.ORM**

2.1**Instale o Entity Framework**:
    ```
    dotnet tool install --global dotnet-ef
    ```

2.2. **Criar uma nova migração**:
    ```bash
    dotnet ef migrations add <NomeDaMigracao>
    ```

2.3 **Aplicar as migrações ao banco de dados**:
    ```bash
    dotnet ef database update
    ```

3. **Para visualizar as tabelas via Docker**: 
    1.Via terminal, entre no container do PostgreSQL:
        ```bash
        docker exec -it ambev_developer_evaluation_database bash
        ```
    2.Acesse o banco de dados com psql:
        ```bash
        psql -U developer -d developer_evaluation
        ``` 
    3. Liste todas as tabelas do schema público:
        ```bash
        \dt public.*
        ```
    4. Para ver uma tabela em espeficio só fazer consultar via SQL:
        ```bash
        SELECT * FROM "Users";
        ```
    5. Para sair do psql:
        ```
        \q
        ```



## 1: Configurar Ambiente de Desenvolvimento

### 1.1 - Acessar a pasta onde consta o arquivo `docker-compose.yml`
Certifique-se de navegar até o diretório correto onde está o arquivo `docker-compose.yml`.

### 1.2 - Rodar o comando para iniciar o ambiente (Usando Docker)
Execute o seguinte comando no terminal para construir e iniciar os contêineres:

#### docker-compose up --build -d

Caso tenha problemas com o docker, limpe o cache do Docker:

Remova contêineres, imagens e caches antigos:

```bash
docker-compose down
docker builder prune
docker system prune -f
```

# Configuração das Tabelas
## 2: Configurar Tabelas Ambiente de Desenvolvimento

### 2.1 - Acessar caminho do projeto 'Ambev.DeveloperEvaluation.ORM'
Certifique-se de navegar até o diretório correto onde está o projeto.

### 2.2 - Rodar o comando para iniciar as tabelas
Execute o seguinte comando no terminal para construir e iniciar as tabelas:

#### update-database


## Executando a Aplicação

Certifique-se de que o arquivo `.csproj` correto esteja especificado na opção `--project`, se necessário.

1. Navegue até o projeto WebApi:
    ```bash
    cd template/backend/src/Ambev.DeveloperEvaluation.WebApi
    ```

2. Execute a aplicação:
    ```bash
    dotnet run
    ```

A API estará disponível, geralmente, em:
- `http://localhost:5000` ou 
- `https://localhost:5001`

Verifique a saída do console para confirmar o endereço exato.
---

## APIs da Aplicação

### APIs Planejadas:
- **API de Autenticação**: Gerencia login via nome de usuário (não e-mail).
- **API de Produtos**: Busca informações de produtos e gerencia estoque.
- **API de Usuários**: Gerencia cadastro, atualização e funções de usuários.
- **API de Vendas**: Mencionada na documentação, mas precisa ser alinhada com os requisitos da primeira página.

---

## Problemas Comuns e Esclarecimentos

1. **Detalhes de Autenticação**:
   - O nome de usuário é o método preferido de autenticação.
   - Autenticação por e-mail não é suportada.

---

## Documentação do Postman

Para testes detalhados e exemplos de APIs, consulte a [Documentação do Postman].

---

## Dependências

### Tecnologias Principais
- **C# .NET Core 8**: Framework para construção da aplicação
- **Entity Framework**: ORM para interações com o banco de dados
- **RabbitMQ**: Sistema de mensageria para comunicação
- **Rebus**: Biblioteca para fluxos de trabalho baseados em mensagens
- **PostgreSQL**: Banco de Dados Relacional

---

## Observações Adicionais

- Certifique-se de que as dependencias de ambiente estejam instaladas na versão correta e funcionando.
- Certifique-se de que o RabbitMQ esteja em execução antes de iniciar a aplicação.
- Alinhe-se com as especificações do cliente para a criação das APIs (autenticação, carrinhos, produtos, usuários e possivelmente vendas).

---

## Controle de Releases
