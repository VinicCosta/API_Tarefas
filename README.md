# API de Anotações de Tarefas
Esta é uma API RESTful desenvolvida em C# utilizando o framework .NET e o banco de dados MySQL. Ela permite aos usuários gerenciar suas tarefas pessoais, oferecendo operações básicas como criação, atualização, exclusão e consulta de tarefas. A API é projetada para ser simples de usar e integrar em aplicativos que necessitam de funcionalidades de gerenciamento de tarefas.

## Endpoints
### [GET] Listar Tarefas
Descrição: Retorna todas as tarefas do usuário em formato JSON.
Endpoint: /listartarefas
Parâmetros: Nenhum
### [GET] Buscar por ID
Descrição: Retorna uma tarefa específica do usuário pelo seu ID em formato JSON.
Endpoint: /exibirtarefaporid
Parâmetros:
id (path): ID único da tarefa a ser buscada.
### [POST] Cadastrar Tarefa
Descrição: Recebe os dados de uma nova tarefa do usuário em formato JSON e a insere no banco de dados.
Endpoint: /criartarefa
Parâmetros:
Corpo da requisição deve conter os dados da tarefa em formato JSON.
### [PUT] Atualizar Tarefa por ID
Descrição: Recebe os dados atualizados de uma tarefa do usuário pelo seu ID em formato JSON e os atualiza no banco de dados.
Endpoint: /atualizartarefa
Parâmetros:
id (path): ID único da tarefa a ser atualizada.
Corpo da requisição deve conter os dados atualizados da tarefa em formato JSON.
### [DELETE] Deletar Tarefa por ID
Descrição: Recebe o ID de uma tarefa do usuário e a exclui do banco de dados.
Endpoint: /deletartarefa
Parâmetros:
id (path): ID único da tarefa a ser deletada.

## Estrutura Json
```json
[
  {
    "id": 1,
    "titulo": "Limpar a casa",
    "descricao": "Realizar limpeza na casa.",
    "concluida": false
  },
]
```