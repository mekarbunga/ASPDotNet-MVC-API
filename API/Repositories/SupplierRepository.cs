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
    public class SupplierRepository : ISupplierRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        public int Create(Supplier supplier)
        {

            parameters.Add("@nama", supplier.SupplierName);
            var spName = "SP_InsertSupplier";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public int Delete(int id)
        {
            parameters.Add("@id", id);
            var spName = "SP_DeleteSupplier";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Supplier> Get()
        {
            var spName = "SP_RetrieveSupplier";
            var result = connection.Query<Supplier>(spName, commandType: CommandType.StoredProcedure);
            if (result.Count() > 0)
                return result;
            else 
                return (new List<Supplier> { new Supplier { SupplierId = 0, SupplierName = "" } });
        }

        public async Task<IEnumerable<Supplier>> Get(int id)
        {
            parameters.Add("@id", id);
            var spName = "SP_RetrieveByIdSupplier";
            var result =  await connection.QueryAsync<Supplier>(spName, parameters, commandType: CommandType.StoredProcedure);
            if (result.Count() > 0)
                return result;
            else
                return (new List<Supplier> { new Supplier { SupplierId = 0, SupplierName = "" } });
        }

        public int Update(Supplier supplier, int id)
        {
            parameters.Add("@id", id);
            parameters.Add("@name", supplier.SupplierName);
            var spName = "SP_UpdateSupplier";
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}