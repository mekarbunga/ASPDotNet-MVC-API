using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        public int Create(Item item)
        {
            parameters.Add("@sid", item.SupplierId);
            parameters.Add("@nama", item.ItemName);
            parameters.Add("@quantity", item.ItemQuantity);
            parameters.Add("@price", item.ItemPrice);
            var spName = "SP_InsertItem";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int Delete(int id)
        {
            parameters.Add("@id", id);
            var spName = "SP_DeleteItem";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Item> Get()
        {
            var spName = "SP_RetrieveItem";
            var result = connection.Query<Item>(spName, commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<Item>> Get(int id)
        {
            parameters.Add("@id", id);
            var spName = "SP_RetrieveByIdItem";
            var result = await connection.QueryAsync<Item>(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int Update(Item item, int id)
        {
            parameters.Add("@id", id);
            parameters.Add("@sid", item.SupplierId);
            parameters.Add("@nama", item.ItemName);
            parameters.Add("@quantity", item.ItemQuantity);
            parameters.Add("@price", item.ItemPrice);
            var spName = "SP_UpdateItem";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}