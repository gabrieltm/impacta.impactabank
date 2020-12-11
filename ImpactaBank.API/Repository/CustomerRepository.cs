using ImpactaBank.API.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ImpactaBank.API.Repository
{
    public class CustomerRepository : BaseRepository
    {
        public int Insert(Customer customer)
        {
            string query = @"INSERT INTO [dbo].[Customer]
                                   ([Name]
                                   ,[Age]
                                   ,[Cpf])
                             output INSERTED.Id VALUES
                                   (@Name
                                   ,@Age
                                   ,@Cpf)";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.ExecuteScalar<int>(query, new { customer.Name, customer.Age });
        }

        public Customer Get(int Id)
        {
            string query = @"SELECT [Id]
                              ,[Name]
                              ,[Age]
                              ,[Cpf]
                          FROM [dbo].[Customer]
                          WHERE Id = @Id";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.QueryFirstOrDefault<Customer>(query, new { Id });
        }

        public List<Customer> List()
        {
            string query = @"SELECT [Id]
                              ,[Name]
                              ,[Age]
                              ,[Cpf]
                          FROM [dbo].[Customer]";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.Query<Customer>(query).ToList();
        }
    }
}
