using ImpactaBank.API.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ImpactaBank.API.Repository
{
    public class OperationRepository : BaseRepository
    {
        public int Insert(Operation operation)
        {
            string query = @"INSERT INTO [dbo].[Operation]
                                   ([Type]
                                   ,[DateTime]
                                   ,[AccountRootId]
                                   ,[AccountDestinyId]
                                   ,[Value])
                             output INSERTED.Id VALUES
                                   (@Type
                                   ,@DateTime)
                                   ,@AccountRootId)
                                   ,@AccountDestinyId)
                                   ,@Value)";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.ExecuteScalar<int>(query, new { operation.Type, operation.DateTime, operation.AccountRootId, operation.AccountDestinyId, operation.Value });
        }

        public Operation Get(int Id)
        {
            string query = @"SELECT [Id]
                              ,[Type]
                              ,[DateTime]
                              ,[AccountRootId]
                              ,[AccountDestinyId]
                              ,[Value]
                          FROM [dbo].[Operation]
                          WHERE Id = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.QueryFirstOrDefault<Operation>(query, new { Id });
        }

        public List<Operation> ListOrigin(int Id)
        {
            string query = @"SELECT [Id]
                              ,[Type]
                              ,[DateTime]
                              ,[AccountRootId]
                              ,[AccountDestinyId]
                              ,[Value]
                          FROM [dbo].[Operation]
                          WHERE AccountRootId = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.Query<Operation>(query).ToList();
        }

        public List<Operation> ListDestiny(int Id)
        {
            string query = @"SELECT [Id]
                              ,[Type]
                              ,[DateTime]
                              ,[AccountRootId]
                              ,[AccountDestinyId]
                              ,[Value]
                          FROM [dbo].[Operation]
                          WHERE AccountDestinyId = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.Query<Operation>(query).ToList();
        }
    }
}
