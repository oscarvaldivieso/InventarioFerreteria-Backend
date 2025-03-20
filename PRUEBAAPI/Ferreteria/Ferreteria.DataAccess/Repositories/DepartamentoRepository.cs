using Dapper;
using FerreteriaEntities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.DataAccess.Repositories
{
    public class DepartamentoRepository : IRepository<tbDepartamentos>
    {
        FerreteriaContext db = new FerreteriaContext();
        public tbDepartamentos FindDepa(string? id)
        {
            throw new NotImplementedException();
        }
        public tbDepartamentos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbDepartamentos> FindCodigo(tbDepartamentos? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbDepartamentos>(ScriptsDataBase.Departamento_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();


            return result;
        }

        public RequestStatus Insert(tbDepartamentos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_Descripcion", item.Depa_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Departamento_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            
            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbDepartamentos> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Query<tbDepartamentos>(ScriptsDataBase.Departamento_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);
            
            return result;
        }

        public RequestStatus Update(tbDepartamentos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Depa_Descripcion", item.Depa_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Departamento_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actuzalizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public RequestStatus Delete(tbDepartamentos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Depa_Codigo", item.Depa_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Departamento_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
