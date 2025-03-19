using FerreteriaEntities.Entities;
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
        }

        public IEnumerable<tbClientes> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbClientes item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Delete(tbClientes item)
        {
            throw new NotImplementedException();
        }
    }
}