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
    public class SucursalRepository : IRepository<tbSucursales>
    {
        private FerreteriaContext db = new FerreteriaContext();
        public tbSucursales FindSucu(int? id)
        {
            throw new NotImplementedException();
        }
        public tbSucursales Find(int? id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbSucursales> FindSucuId(tbSucursales? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbSucursales>(ScriptsDataBase.Sucursal_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }
        public RequestStatus Insert(tbSucursales item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Nombre", item.Sucu_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_DireccionExacta", item.Sucu_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Sucursal_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbSucursales> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Query<tbSucursales>(ScriptsDataBase.Sucursal_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbSucursales item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_Nombre", item.Sucu_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Sucu_DireccionExacta", item.Sucu_DireccionExacta, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Sucursal_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
        public RequestStatus Delete(tbSucursales item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Sucu_Id", item.Sucu_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Sucursal_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
