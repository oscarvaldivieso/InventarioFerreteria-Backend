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
    public class EmpleadoRepository : IRepository<tbEmpleados>
    {
        private FerreteriaContext db = new FerreteriaContext();
        public tbEmpleados FindEmpl(int? id)
        {
            throw new NotImplementedException();
        }
        public tbEmpleados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEmpleados> FindEmplDNI(tbEmpleados? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Empl_DNI", item.Empl_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbEmpleados>(ScriptsDataBase.Empleado_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Empl_DNI", item.Empl_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Nombre", item.Empl_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Apellido", item.Empl_Apellido, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Sexo", item.Empl_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Direccion", item.Empl_Direccion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Empleado_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbEmpleados> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbEmpleados>(ScriptsDataBase.Empleado_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbEmpleados item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Empl_Id", item.Empl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_DNI", item.Empl_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Nombre", item.Empl_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Apellido", item.Empl_Apellido, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Sexo", item.Empl_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCv_Id", item.EsCv_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Empl_Direccion", item.Empl_Direccion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Empleado_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizar correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
        public RequestStatus Delete(tbEmpleados item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Empl_Id", item.Empl_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Empleado_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
