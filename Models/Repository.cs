using System;
using MySqlConnector;
using System.Collections.Generic;

namespace Loja.Models;

public class Repository
{
    // Define a string de conexão com o banco de dados
    private const string DadosConexao = "Database = Loja; Data Source = localhost; User Id = root";

    // Método para inserir um objeto Property no banco de dados
    public void Inserir(Property property)
    {
        // Cria uma nova conexão com o banco de dados utilizando a string de conexão definida
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();// Abre a conexão com o banco de dados

        // Define a query SQL para inserir os dados na tabela 'Cadastros'
        string Query = "INSERT INTO Cadastros(Nome, Email, Rua, Numero, Bairro, Cidade, Cep, Estado, Pais, Pedido, Entrada, Total, Data, Registros) VALUES (@Nome, @Email, @Rua, @Numero, @Bairro, @Cidade, @Cep, @Estado, @Pais, @Pedido, @Entrada, @Total, @Data, @Registros);";

        // Cria um novo comando SQL associado à conexão e à query
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);

        // Define os parâmetros da query com os valores do objeto Property fornecido
        Comando.Parameters.AddWithValue("@Nome",property.Nome);
        Comando.Parameters.AddWithValue("@Email",property.Email);
        Comando.Parameters.AddWithValue("@Rua",property.Rua);
        Comando.Parameters.AddWithValue("@Numero",property.Numero);
        Comando.Parameters.AddWithValue("@Bairro",property.Bairro);
        Comando.Parameters.AddWithValue("@Cidade",property.Cidade);
        Comando.Parameters.AddWithValue("@Cep",property.Cep);
        Comando.Parameters.AddWithValue("@Estado",property.Estado);
        Comando.Parameters.AddWithValue("@Pais",property.Pais);
        Comando.Parameters.AddWithValue("@Pedido",property.Pedido);
        Comando.Parameters.AddWithValue("@Entrada",property.Entrada);
        Comando.Parameters.AddWithValue("@Total",property.Total);
        Comando.Parameters.AddWithValue("@Data",property.Data);
        Comando.Parameters.AddWithValue("@Registros",property.Registros);

        // Executa o comando SQL para inserir os dados na tabela
        Comando.ExecuteNonQuery();

        // Fecha a conexão com o banco de dados
        Conexao.Close();
    }
    //READ (LEITURA)
    public List<Property> Listar()
    {
        // Cria uma nova lista para armazenar objetos Property
        List<Property> Lista = new List<Property>();

        // Cria uma nova conexão com o banco de dados MySQL usando a string de conexão fornecida
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();// Abre a conexão com o banco de dados
        // Define a query SQL para selecionar todos os registros da tabela Cadastros
        string Query = "SELECT * FROM Cadastros;";
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);
        
        // Executa a query SQL e cria um leitor de dados para ler os resultados
        MySqlDataReader Reader = Comando.ExecuteReader();
        
        // Itera sobre os resultados retornados pela query
        while(Reader.Read())
        {
            // Cria um novo objeto Property para armazenar os dados de cada registro
            Property property = new Property();

            // Preenche as propriedades do objeto Property com os valores do registro atual
            property.IdProperty = Reader.GetInt32("IdProperty");
        
            if(! Reader.IsDBNull(Reader.GetOrdinal("Nome")))
            {
                property.Nome = Reader.GetString("Nome");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Email")))
            {
                property.Email = Reader.GetString("Email");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Rua")))
            {
                property.Rua = Reader.GetString("Rua");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Numero")))
            {
                property.Numero = Reader.GetInt32("Numero");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Bairro")))
            {
                property.Bairro = Reader.GetString("Bairro");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Cidade")))
            {
                property.Cidade = Reader.GetString("Cidade");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Cep")))
            {
                property.Cep = Reader.GetInt32("Cep");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Estado")))
            {
                property.Estado = Reader.GetString("Estado");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Pais")))
            {
                property.Pais = Reader.GetString("Pais");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Pedido")))
            {
                property.Pedido = Reader.GetString("Pedido");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Entrada")))
            {
                property.Entrada = Reader.GetDouble("Entrada");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Total")))
            {
                property.Total = Reader.GetDouble("Total");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Data")))
            {
                property.Data = Reader.GetDateTime("Data");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Registros")))
            {
                property.Registros = Reader.GetString("Registros");
            }

            // Calcula e define o valor da propriedade Restante com base no Total e Entrada
            property.Restante = Reader.GetDouble("Total") - Reader.GetDouble("Entrada"); 

            // Adiciona o objeto Property à lista
            Lista.Add(property);
        }
        
        // Inverte a ordem dos elementos na lista para que os registros mais recentes fiquem no topo
        Lista.Reverse();

        // Fecha a conexão com o banco de dados
        Conexao.Close();

        // Retorna a lista de objetos Property preenchida com os dados do banco de dados
        return Lista;
    }
    //UPDATE (EDITAR) 
    public void Editar(Property property)
    {
        // Cria uma nova conexão com o banco de dados MySQL usando a string de conexão fornecida
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();// Abre a conexão com o banco de dados

        // Define a query SQL para atualizar os dados na tabela Cadastros
        string Query = "UPDATE Cadastros SET Nome = @Nome, Email = @Email, Rua = @Rua, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade, Cep = @Cep, Estado = @Estado, Pais = @Pais, Pedido = @Pedido, Entrada = @Entrada, Total = @Total, Data = @Data, Registros = @Registros WHERE IdProperty = @IdProperty";
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);
        
        Comando.Parameters.AddWithValue("@IdProperty",property.IdProperty);

        // Define os parâmetros da query com os valores do objeto Property fornecido
        Comando.Parameters.AddWithValue("@Nome",property.Nome);
        Comando.Parameters.AddWithValue("@Email",property.Email);
        Comando.Parameters.AddWithValue("@Rua",property.Rua);
        Comando.Parameters.AddWithValue("@Numero",property.Numero);
        Comando.Parameters.AddWithValue("@Bairro",property.Bairro);
        Comando.Parameters.AddWithValue("@Cidade",property.Cidade);
        Comando.Parameters.AddWithValue("@Cep",property.Cep);
        Comando.Parameters.AddWithValue("@Estado",property.Estado);
        Comando.Parameters.AddWithValue("@Pais",property.Pais);
        Comando.Parameters.AddWithValue("@Pedido",property.Pedido);
        Comando.Parameters.AddWithValue("@Entrada",property.Entrada);
        Comando.Parameters.AddWithValue("@Total",property.Total);
        Comando.Parameters.AddWithValue("@Data",property.Data.ToString("yyyy-MM-dd HH:mm"));
        Comando.Parameters.AddWithValue("@Registros",property.Registros);

        // Executa a query SQL para atualizar os dados na tabela Cadastros
        Comando.ExecuteNonQuery();

        // Fecha a conexão com o banco de dados
        Conexao.Close();
    }
    //BUSCA POR ID COM INFORMAÇÕES
    public Property BuscaPorId(int Id)
    {
        // Cria uma nova conexão com o banco de dados MySQL usando a string de conexão fornecida
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();// Abre a conexão com o banco de dados

        // Define a query SQL para selecionar os dados na tabela Cadastros com base no IdProperty fornecido
        string Query = "SELECT * FROM Cadastros WHERE IdProperty = @IdProperty";
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);

        // Define o parâmetro da query com o valor do IdProperty fornecido
        Comando.Parameters.AddWithValue("@IdProperty",Id);

        // Executa a query SQL e armazena o resultado em um MySqlDataReader
        MySqlDataReader Reader = Comando.ExecuteReader();

        Property property = new Property();// Cria um novo objeto Property para armazenar os dados do registro recuperado

        // Verifica se existem linhas retornadas pela consulta
        while(Reader.Read())
        {
            // Preenche as propriedades do objeto Property com os valores obtidos do MySqlDataReader
            property.IdProperty = Reader.GetInt32("IdProperty");

            if(! Reader.IsDBNull(Reader.GetOrdinal("Nome")))
            {
                property.Nome = Reader.GetString("Nome");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Email")))
            {
                property.Email = Reader.GetString("Email");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Rua")))
            {
                property.Rua = Reader.GetString("Rua");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Numero")))
            {
                property.Numero = Reader.GetInt32("Numero");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Bairro")))
            {
                property.Bairro = Reader.GetString("Bairro");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Cidade")))
            {
                property.Cidade = Reader.GetString("Cidade");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Cep")))
            {
                property.Cep = Reader.GetInt32("Cep");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Estado")))
            {
                property.Estado = Reader.GetString("Estado");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Pais")))
            {
                property.Pais = Reader.GetString("Pais");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Pedido")))
            {
                property.Pedido = Reader.GetString("Pedido");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Entrada")))
            {
                property.Entrada = Reader.GetDouble("Entrada");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Total")))
            {
                property.Total = Reader.GetDouble("Total");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Data")))
            {
                property.Data = Reader.GetDateTime("Data");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Registros")))
            {
                property.Registros = Reader.GetString("Registros");
            }
            
        }
        // Fecha a conexão com o banco de dados
        Conexao.Close();

        // Retorna o objeto Property com os dados do registro recuperado
        return property;
    }
    //DELETE (DELETAR)
    public void Deletar(int Id)
    {
        // Cria uma nova conexão com o banco de dados MySQL usando a string de conexão fornecida
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();// Abre a conexão com o banco de dados

        // Define a query SQL para excluir o registro da tabela Cadastros com base no IdProperty fornecido
        string Query = "DELETE FROM Cadastros WHERE IdProperty = @IdProperty";
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);

        // Define o parâmetro da query com o valor do IdProperty fornecido
        Comando.Parameters.AddWithValue("@IdProperty",Id);

        // Executa a query SQL para excluir o registro da tabela
        Comando.ExecuteNonQuery();

        // Fecha a conexão com o banco de dados
        Conexao.Close();
    }
}
