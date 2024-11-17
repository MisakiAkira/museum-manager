using Back_end.Models.DTO;
using Microsoft.Data.SqlClient;

namespace Back_end.Services
{
    public class PersonDBService : IPersonDBService
    {
        private readonly string _connString;

        public PersonDBService(IConfiguration config) 
        {
            _connString = config.GetConnectionString("DBString");
        }

        public async Task<bool> DeletePerson(int id)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"DELETE FROM person WHERE personid = {id}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<PersonDTO> GetPersonById(int id)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM person WHERE personid = {id}", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await sqlDataReader.ReadAsync();

            PersonDTO person = new()
            {
                id = int.Parse(sqlDataReader["personid"].ToString()),
                firstName = sqlDataReader["firstname"].ToString(),
                lastName = sqlDataReader["lastname"].ToString(),
                gender = char.Parse(sqlDataReader["gender"].ToString())
            };

            await sqlConnection.CloseAsync();

            return person;
        }

        public async Task<IList<PersonDTO>> GetPersonList()
        {
            List<PersonDTO> people = new();

            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new("SELECT * FROM person", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (await sqlDataReader.ReadAsync())
            {
                PersonDTO person = new()
                {
                    id = int.Parse(sqlDataReader["personid"].ToString()),
                    firstName = sqlDataReader["firstname"].ToString(),
                    lastName = sqlDataReader["lastname"].ToString(),
                    gender = char.Parse(sqlDataReader["gender"].ToString())
                };
                people.Add(person);
            }

            await sqlConnection.CloseAsync();

            return people;
        }

        public async Task<bool> PostPerson(PersonDTO person)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"INSERT INTO person (firstname, lastname, gender) " +
                $"VALUES ('{person.firstName}', '{person.lastName}', '{person.gender}')", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<bool> PutPerson(PersonDTO person)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"UPDATE person SET firstname = '{person.firstName}', lastname = '{person.lastName}', gender = '{person.gender}' " +
                $"WHERE personid = {person.id}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }
    }
}
