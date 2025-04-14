# DesafioAmbev - abi-gth-omnia-developer-evaluation
Desafio técnico Ambev.

# Configuração do Ambiente de Desenvolvimento

## Passo 1: Configurar Ambiente de Desenvolvimento

### 1.1 - Acessar a pasta onde consta o arquivo `docker-compose.yml`
Certifique-se de navegar até o diretório correto onde está o arquivo `docker-compose.yml`.

### 1.2 - Rodar o comando para iniciar o ambiente (Usando Docker)
Execute o seguinte comando no terminal para construir e iniciar os contêineres:

#### docker-compose up --build -d

# Configuração das Tabelas
## Passo 2: Configurar Tabelas Ambiente de Desenvolvimento

### 1.1 - Acessar caminho do projeto 'Ambev.DeveloperEvaluation.ORM'
Certifique-se de navegar até o diretório correto onde está o projeto.

### 1.2 - Rodar o comando para iniciar as tabelas
Execute o seguinte comando no terminal para construir e iniciar as tabelas:

#### update-database

#### Executa a API

---

Este projeto foi desenvolvido usando **C# .NET Core**, com integrações para **RabbitMQ**, **Rebus** e **Entity Framework**. Ele serve como ponto de partida para a criação de APIs que lidam com autenticação, gerenciamento de carrinho, detalhes de produtos, gerenciamento de usuários e operações de vendas.

---

## Começando

### Pré-requisitos
Para executar este projeto, certifique-se de que as seguintes ferramentas estão instaladas em seu sistema:
- **.NET Core SDK (v8.0)**: [Baixe aqui](https://dotnet.microsoft.com/)
- **Docker** (opcional): Para implantação em containers
- **RabbitMQ**: Configuração do sistema de mensageria ([Guia de configuração do RabbitMQ](https://www.rabbitmq.com/documentation.html))
- **PostgreSQL**: Para operações de banco de dados ([Documentação do PostgreSQL](https://www.postgresql.org/docs/))
- **Postman**: Para testar as APIs ([Documentação do Postman](https://documenter.getpostman.com/view/27971159/2sB2cPkR3g))

---

## Como Executar

### Migrações de Banco de Dados
- Antes de executar a aplicação, configure o banco de dados criando e aplicando as migrações
- Execute a partir do caminho do projeto **Ambev.DeveloperEvaluation.ORM**

1. **Criar uma nova migração**:
    ```bash
    dotnet ef migrations add NomeDaMigracao
    ```

2. **Aplicar as migrações ao banco de dados**:
    ```bash
    dotnet ef database update
    ```

Certifique-se de que o arquivo `.csproj` correto está especificado na opção `--project`.

---

## APIs da Aplicação

### APIs Planejadas:
- **API de Autenticação**: Gerencia login via nome de usuário (não e-mail).
- **API de Carrinho**: Gerencia operações de carrinho (é necessário esclarecimento sobre o campo "data" nesta API – se refere à data de criação? Se sim, mantenha-o dentro do domínio do sistema).
- **API de Produtos**: Busca informações de produtos e gerencia estoque.
- **API de Usuários**: Gerencia cadastro, atualização e funções de usuários.
- **API de Vendas**: Mencionada na documentação, mas precisa ser alinhada com os requisitos da primeira página.

---

## Problemas Comuns e Esclarecimentos

1. **Detalhes de Autenticação**:
   - O nome de usuário é o método preferido de autenticação.
   - Autenticação por e-mail não é suportada.

2. **Campo de Data na API de Carrinho**:
   - Se essa data se refere à criação do carrinho, ela deve permanecer parte do domínio do sistema para consistência.


---

## Documentação do Postman

Para testes detalhados e exemplos de APIs, consulte a [Documentação do Postman](https://documenter.getpostman.com/view/27971159/2sB2cPkR3g).

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