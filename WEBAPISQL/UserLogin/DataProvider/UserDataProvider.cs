using Dapper;
using Microsoft.IdentityModel.Protocols; //Added 02 08 2019
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UserLogin.Models;

namespace UserLogin.DataProvider
{
    public class UserDataProvider : IUserDataProvider
    {
        //private readonly string connectionString = "Server=.\\SQL2014;Database=Master;Trusted_Connection=True;";

        private readonly string connectionString = "Server = tcp:mymasterapiserver.database.windows.net,1433;Initial Catalog = MasterApi; Persist Security Info=False;User ID = dev; Password=D3v@piServer; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        private SqlConnection sqlConnection;


        public async Task AddQRScan(string qRScanned)
        {
            try
            {
                if (!qRScanned.Equals(string.Empty) || qRScanned != null || qRScanned != "")
                {
                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        await sqlConnection.OpenAsync();
                        var dynamicParamaters = new DynamicParameters();
                        //dynamicParamaters.Add("@ID", qRScanned.ID);
                        dynamicParamaters.Add("@ScannedQR", qRScanned);

                        await sqlConnection.ExecuteAsync(
                            "spAddQR", dynamicParamaters, commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AddUser(User user)
        {

            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserId", user.UserId);
                    dynamicParameters.Add("@UserName", user.UserName);
                    dynamicParameters.Add("@Email", user.Email);
                    dynamicParameters.Add("@Password", user.Password);

                    await sqlConnection.ExecuteAsync(
                        "spAddUser",
                        dynamicParameters,
                        commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Generic Exception Handler: {0}", e.ToString());
            }

        }

        public async Task DeleteUser(int UserId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", UserId);
                await sqlConnection.ExecuteAsync(
                    "spDeleteUser",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<User> GetUser(int UserId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", UserId);
                return await sqlConnection.QuerySingleOrDefaultAsync<User>(
                    "spGetUser",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<User>(
                    "spGetUsers",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateUser(User user)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserId", user.UserId);
                    dynamicParameters.Add("@UserName", user.UserName);
                    dynamicParameters.Add("@Email", user.Email);
                    dynamicParameters.Add("@Password", user.Password);
                    await sqlConnection.ExecuteAsync(
                        "spUpdateUser",
                        dynamicParameters,
                        commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Generic Exception Handler: {0}", e.ToString());
            }

        }




    }
}