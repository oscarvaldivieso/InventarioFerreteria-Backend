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
    public class CompraRepository
    {
        private FerreteriaContext db = new FerreteriaContext();

        public tbCompras FindComp(int? id)
        {
            throw new NotImplementedException();
        }

        public tbCompras Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbCompras> FindCompId(tbCompras? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Comp_Id", item.Comp_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbCompras>(ScriptsDataBase.Compra_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Insert(tbCompras item)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbCompras> InsertEncabezado(tbCompras? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Comp_Fecha", item.Comp_Fecha, System.Data.DbType.Date, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", item.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbCompras>(ScriptsDataBase.CompraEncabezado_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }
        public RequestStatus InsertDetalle(tbComprasDetalles cpde)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Comp_Id", cpde.Comp_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Id", cpde.Prod_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@CpDe_Cantidad", cpde.CpDe_Cantidad, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@CpDe_Precio", cpde.CpDe_Precio, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", cpde.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Creacion", cpde.Feca_Creacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.CompraDetalle_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al insertar" : "Insertar correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbCompras> List()
        {
            var parameter = new DynamicParameters();

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbCompras>(ScriptsDataBase.Compra_Listar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }

        public RequestStatus Update(tbCompras item)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<tbCompras> UpdateEncabezado(tbCompras? item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Comp_Id", item.Comp_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prov_Id", item.Prov_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Comp_Fecha", item.Comp_Fecha, System.Data.DbType.Date, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", item.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Query<tbCompras>(ScriptsDataBase.CompraEncabezado_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return result;
        }
        public RequestStatus UpdateDetalle(tbComprasDetalles cpde)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Comp_Id", cpde.Comp_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Prod_Id", cpde.Prod_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@CpDe_Cantidad", cpde.CpDe_Cantidad, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@CpDe_Precio", cpde.CpDe_Precio, System.Data.DbType.Double, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", cpde.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Feca_Modificacion", cpde.Feca_Modificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.CompraDetalle_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizar correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public RequestStatus Delete(tbCompras item, tbComprasDetalles cpde)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Comp_Id", item.Comp_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@CpDe_Id", cpde.CpDe_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(FerreteriaContext.ConnectionString);
            var result = db.Execute(ScriptsDataBase.Compra_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al actualizar" : "Actualizar correctamente";

            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}