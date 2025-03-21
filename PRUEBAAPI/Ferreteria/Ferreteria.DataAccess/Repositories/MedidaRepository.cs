using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FerreteriaEntities.Entities;
using Microsoft.Data.SqlClient;

namespace Ferreteria.DataAccess.Repositories
{
    public class MedidaRepository : IRepository<tbMedidas>
    {
        public tbMedidas FindMedi(int? id)
        {
            throw new NotImplementedException();
        }
        public tbMedidas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbMedidas> FindMediId(tbMedidas? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Medi_Id", item.Medi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbMedidas>(ScriptsDataBase.Medida_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Insert(tbMedidas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Medi_Descripcion", item.Medi_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Medida_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbMedidas> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbMedidas>(ScriptsDataBase.Medida_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result.ToList();
        }

        public RequestStatus Update(tbMedidas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Medi_Id", item.Medi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Medi_Descripcion", item.Medi_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Medida_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
        public RequestStatus Delete(tbMedidas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Medi_Id", item.Medi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Medida_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
