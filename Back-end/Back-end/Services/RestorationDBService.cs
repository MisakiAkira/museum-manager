using Back_end.Models.DTO;
using Microsoft.Data.SqlClient;

namespace Back_end.Services
{
    public class RestorationDBService : IRestorationDBService
    {
        private readonly string _connString;

        public RestorationDBService(IConfiguration config)
        {
            _connString = config.GetConnectionString("DBString");
        }

        public async Task<bool> DeleteRestoration(int restorerId, int paintingId)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"DELETE FROM restoration WHERE restorerid = {restorerId} AND paintingid = {paintingId}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<RestorationDTO> GetRestorationById(int restorerId, int paintingId)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM restoration WHERE restorerid = {restorerId} AND paintingid = {paintingId}", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await sqlDataReader.ReadAsync();

            RestorationDTO restoration = new()
            {
                restorerId = int.Parse(sqlDataReader["restorerid"].ToString()),
                paintingId = int.Parse(sqlDataReader["paintingid"].ToString()),
                cost = float.Parse(sqlDataReader["cost"].ToString()),
                startDate = DateOnly.FromDateTime(DateTime.Parse(sqlDataReader["startdate"].ToString())),
                endDate = DateOnly.FromDateTime(DateTime.Parse(sqlDataReader["enddate"].ToString()))
            };

            await sqlConnection.CloseAsync();

            return restoration;
        }

        public async Task<IList<RestorationDTO>> GetRestorationList()
        {
            List<RestorationDTO> restorationList = new();

            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"SELECT * FROM restoration", sqlConnection);

            await sqlConnection.OpenAsync();

            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (await sqlDataReader.ReadAsync())
            {
                RestorationDTO restoration = new()
                {
                    restorerId = int.Parse(sqlDataReader["restorerid"].ToString()),
                    paintingId = int.Parse(sqlDataReader["paintingid"].ToString()),
                    cost = float.Parse(sqlDataReader["cost"].ToString()),
                    startDate = DateOnly.FromDateTime(DateTime.Parse(sqlDataReader["startdate"].ToString())),
                    endDate = DateOnly.FromDateTime(DateTime.Parse(sqlDataReader["enddate"].ToString()))
                };
                restorationList.Add(restoration);
            }

            await sqlConnection.CloseAsync();

            return restorationList;
        }

        public async Task<bool> PostRestoration(RestorationDTO restoration)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"INSERT INTO restoration " +
                $"VALUES ({restoration.restorerId}, {restoration.paintingId}, {restoration.cost}," +
                $" CAST('{restoration.startDate}' AS DATE), CAST('{restoration.endDate}' AS DATE))", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }

        public async Task<bool> PutRestoration(RestorationDTO restoration)
        {
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new($"UPDATE restoration SET cost = {restoration.cost}, " +
                $"startdate = CAST('{restoration.startDate}' AS DATE), enddate = CAST('{restoration.endDate}' AS DATE) " +
                $"WHERE restorerid = {restoration.restorerId} AND paintingid = {restoration.paintingId}", sqlConnection);

            await sqlConnection.OpenAsync();

            int lines = await sqlCommand.ExecuteNonQueryAsync();

            await sqlConnection.CloseAsync();

            return lines > 0;
        }
    }
}
