using ImpactaBank.API.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ImpactaBank.API.Repository
{
    public class AccountRepository : BaseRepository
    {
        public int Insert(Account account)
        {
            string query = @"INSERT INTO [dbo].[Account]
                                   ([Hash]
                                   ,[CustomerId])
                             output INSERTED.Id VALUES
                                   (@Hash
                                   ,@CustomerId)";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.ExecuteScalar<int>(query, new { account.Hash, account.CustomerId });
        }

        public Account Get(int Id)
        {
            string query = @"SELECT [Id]
                                  ,[Hash]
                                  ,[CustomerId]
                              FROM[dbo].[Account]
                              WHERE Id = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.QueryFirstOrDefault<Account>(query, new { Id });
        }
    }
}
