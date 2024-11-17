using Back_end.Models.DTO;
using Microsoft.Data.SqlClient;
using System;

namespace Back_end.Services
{
    public class AuthorDBService : IAuthorDBService
    {
        private readonly string _connString;

        public AuthorDBService(IConfiguration config)
        {
            _connString = config.GetConnectionString("DBString");
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"DELETE FROM author WHERE personid = {id}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<AuthorDTO> GetAuthorById(int id)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM author WHERE personid = {id}", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await sqlDataReader.ReadAsync();

            AuthorDTO author = new()
            {
                id = int.Parse(sqlDataReader["personid"].ToString()),
                description = sqlDataReader["description"].ToString()
            };

            await sqlConnection.CloseAsync();

            return author;
        }

        public async Task<IList<AuthorDTO>> GetAuthorList()
        {
            List<AuthorDTO> authorList = new();

            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM author", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (await sqlDataReader.ReadAsync())
            {
                AuthorDTO author = new()
                {
                    id = int.Parse(sqlDataReader["personid"].ToString()),
                    description = sqlDataReader["description"].ToString()
                };
                authorList.Add(author);
            }

            await sqlConnection.CloseAsync();

            return authorList;
        }

        public async Task<bool> PostAuthor(AuthorDTO author)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"INSERT INTO author VALUES ({author.id}, '{author.description}')", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<bool> PutAuthor(AuthorDTO author)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"UPDATE author SET description = '{author.description}' WHERE personid = {author.id}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }
    }
}
