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
    public class ClienteRepository : IRepository<tbClientes>
    {
        public tbClientes FindClie(int? id)
        {
            throw new NotImplementedException();
        }

        public tbClientes Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbClientes item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_DNI", item.Clie_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Nombre", item.Clie_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Apellido", item.Clie_Apellido, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Sexo", item.Clie_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Direccion", item.Clie_Direccion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Execute(ScriptsDataBase.Cliente_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbClientes> List()
        {
            var parameter = new DynamicParameters();

            var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Query<tbClientes>(ScriptsDataBase.Cliente_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Update(tbClientes item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_Id", item.Clie_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_DNI", item.Clie_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Nombre", item.Clie_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Apellido", item.Clie_Apellido, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Sexo", item.Clie_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Clie_Direccion", item.Clie_Direccion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Execute(ScriptsDataBase.Cliente_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public RequestStatus Delete(tbClientes item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Clie_DNI", item.Clie_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Execute(ScriptsDataBase.Cliente_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}