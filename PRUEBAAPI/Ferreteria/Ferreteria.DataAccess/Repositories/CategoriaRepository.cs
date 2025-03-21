using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FerreteriaEntities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ferreteria.DataAccess.Repositories
{
    public class CategoriaRepository : IRepository<tbCategorias>
    {
        public tbCategorias FindCate(int? id)
        {
            throw new NotImplementedException();
        }
        public tbCategorias Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbCategorias> FindCateId(tbCategorias? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbCategorias>(ScriptsDataBase.Categoria_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Insert(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Descripcion", item.Cate_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Categoria_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbCategorias> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);

            var result = db.Query<tbCategorias>(ScriptsDataBase.Categoria_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Update(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_Descripcion", item.Cate_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Categoria_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public RequestStatus Delete(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Categoria_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
