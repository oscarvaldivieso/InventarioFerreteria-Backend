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
    public class CargoRepository : IRepository<tbCargos>
    {
        private FerreteriaContext db = new FerreteriaContext();

        public tbCargos FindCarg(int? id)
        {
            throw new NotImplementedException();
        }

        public tbCargos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbCargos> FindCargId(tbCargos? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbCargos>(ScriptsDataBase.Cargo_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Insert(tbCargos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Carg_Descripcion", item.Carg_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Cargo_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbCargos> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Query<tbCargos>(ScriptsDataBase.Cargo_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbCargos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_Descripcion", item.Carg_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Cargo_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public RequestStatus Delete(tbCargos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Cargo_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}