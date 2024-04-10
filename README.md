# crud-mysql-aspnet-mvc-6

O código é uma implementação de um repositório em C# para interagir com um banco de dados MySQL na aplicação Loja. Vou fazer um resumo das principais partes do código:

String de Conexão e Construtor: A classe Repository possui uma constante DadosConexao que armazena a string de conexão com o banco de dados MySQL. O construtor não está presente, pois não é necessário neste caso.

Método Inserir: O método Inserir é responsável por adicionar um novo registro à tabela Cadastros do banco de dados. Ele utiliza parâmetros para evitar injeção de SQL e executa uma query SQL para inserção de dados.

Método Listar: O método Listar recupera todos os registros da tabela Cadastros do banco de dados e os armazena em uma lista de objetos Property. Ele executa uma query SQL de seleção e itera sobre o resultado para preencher os objetos Property, os quais são adicionados à lista.

Método Editar: O método Editar permite atualizar um registro existente na tabela Cadastros. Ele recebe um objeto Property com os novos valores e executa uma query SQL de atualização para modificar o registro correspondente no banco de dados.

Método BuscaPorId: O método BuscaPorId permite buscar um registro na tabela Cadastros com base no seu IdProperty. Ele executa uma query SQL de seleção com um filtro pelo IdProperty fornecido e retorna um objeto Property com os dados do registro encontrado.

Método Deletar: O método Deletar permite excluir um registro da tabela Cadastros com base no seu IdProperty. Ele executa uma query SQL de exclusão com um filtro pelo IdProperty fornecido.

Em resumo, este repositório fornece métodos para realizar as operações básicas de CRUD (criar, ler, atualizar e excluir) em registros da tabela Cadastros do banco de dados MySQL na aplicação Loja.
