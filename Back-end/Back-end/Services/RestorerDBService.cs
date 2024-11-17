using Back_end.Models.DTO;
using Microsoft.Data.SqlClient;

namespace Back_end.Services
{
    public class RestorerDBService : IRestorerDBService
    {
        private readonly string _connString;

        public RestorerDBService(IConfiguration config)
        {
            _connString = config.GetConnectionString("DBString");
        }

        public async Task<bool> DeleteRestorer(int id)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"DELETE FROM restorer WHERE personid = {id}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<RestorerDTO> GetRestorerById(int id)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM restorer WHERE personid = {id}", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await sqlDataReader.ReadAsync();

            RestorerDTO restorer = new()
            {
                id = int.Parse(sqlDataReader["personid"].ToString()),
                experience = int.Parse(sqlDataReader["experience"].ToString())
            };

            await sqlConnection.CloseAsync();

            return restorer;
        }

        public async Task<IList<RestorerDTO>> GetRestorerList()
        {
            List<RestorerDTO> restorerList = new();

            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM restorer", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (await sqlDataReader.ReadAsync())
            {
                RestorerDTO restorer = new()
                {
                    id = int.Parse(sqlDataReader["personid"].ToString()),
                    experience = int.Parse(sqlDataReader["experience"].ToString())
                };
                restorerList.Add(restorer);
            }

            await sqlConnection.CloseAsync();

            return restorerList;
        }

        public async Task<bool> PostRestorer(RestorerDTO restorer)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"INSERT INTO restorer VALUES ({restorer.id}, '{restorer.experience}')", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<bool> PutRestorer(RestorerDTO restorer)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"UPDATE restorer SET experience = '{restorer.experience}' WHERE personid = {restorer.id}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }
    }
}
