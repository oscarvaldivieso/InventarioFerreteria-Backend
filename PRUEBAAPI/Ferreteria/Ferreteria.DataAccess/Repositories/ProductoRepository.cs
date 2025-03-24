using Dapper;
using FerreteriaEntities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.DataAccess.Repositories
{
    public class ProductoRepository : IRepository<tbProductos>
    {
        private FerreteriaContext db = new FerreteriaContext();
        public tbProductos FindProd(int? id)
        {
            throw new NotImplementedException();
        }
        public tbProductos Find(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbProductos> FindProdId(tbProductos? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbProductos>(ScriptsDataBase.Producto_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }
        public RequestStatus Insert(tbProductos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Descripcion", item.Prod_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Marc_Id", item.Marc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Modelo", item.Prod_Modelo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Cantidad", item.Prod_Cantidad, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_URLImg", item.Prod_URLImg, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Medi_Id", item.Medi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Producto_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbProductos> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Query<tbProductos>(ScriptsDataBase.Producto_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbProductos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Descripcion", item.Prod_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Marc_Id", item.Marc_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_URLImg", item.Prod_URLImg, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Medi_Id", item.Medi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Modelo", item.Prod_Modelo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Cantidad", item.Prod_Cantidad, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Producto_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
        public RequestStatus Delete(tbProductos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prod_Id", item.Prod_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Execute(ScriptsDataBase.Producto_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
