using Back_end.Models.DTO;
using Microsoft.Data.SqlClient;

namespace Back_end.Services
{
    public class PaintingDBService : IPaintingDBService
    {
        private readonly string _connString;

        public PaintingDBService(IConfiguration config)
        {
            _connString = config.GetConnectionString("DBString");
        }

        public async Task<bool> DeletePainting(int id)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"DELETE FROM painting WHERE paintingid = {id}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<PaintingDTO> GetPaintingById(int id)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM painting WHERE paintingid = {id}", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await sqlDataReader.ReadAsync();

            PaintingDTO painting = new()
            {
                id = int.Parse(sqlDataReader["paintingid"].ToString()),
                authorId = int.Parse(sqlDataReader["authorid"].ToString()),
                name = sqlDataReader["name"].ToString(),
                paintingDate = DateOnly.FromDateTime(DateTime.Parse(sqlDataReader["paintingdate"].ToString())),
                description = sqlDataReader["description"].ToString()
            };

            await sqlConnection.CloseAsync();

            return painting;
        }

        public async Task<IList<PaintingDTO>> GetPaintingList()
        {
            List<PaintingDTO> paintingList = new();

            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM painting", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (await sqlDataReader.ReadAsync())
            {
                PaintingDTO painting = new()
                {
                    id = int.Parse(sqlDataReader["paintingid"].ToString()),
                    authorId = int.Parse(sqlDataReader["authorid"].ToString()),
                    name = sqlDataReader["name"].ToString(),
                    paintingDate = DateOnly.FromDateTime(DateTime.Parse(sqlDataReader["paintingdate"].ToString())),
                    description = sqlDataReader["description"].ToString()
                };
                paintingList.Add(painting);
            }

            await sqlConnection.CloseAsync();

            return paintingList;
        }

        public async Task<bool> PostPainting(PaintingDTO painting)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"INSERT INTO painting (authorid, name, paintingdate, description) " +
                $"VALUES ({painting.authorId}, '{painting.name}', CAST('{painting.paintingDate}' AS DATE), '{painting.description}')", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<bool> PutPainting(PaintingDTO painting)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"UPDATE painting SET authorid = {painting.authorId}, " +
                $"name = '{painting.name}', paintingdate = CAST('{painting.paintingDate}' AS DATE), description = '{painting.description}' " +
                $"WHERE paintingid = {painting.id}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }
    }
}
