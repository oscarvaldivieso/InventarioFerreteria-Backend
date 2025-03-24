using Ferreteria.DataAccess.Repositories;
using FerreteriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic.Services
{
    public class CompraServices
    {
        private readonly ProveedorRepository _proveedorRepository;

        public CompraServices(ProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        #region Proveedor

        public IEnumerable<tbProveedores> BuscarProveedor(tbProveedores item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _proveedorRepository.FindProvId(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbProveedores> prov = null;
                return prov;
            }
        }

        public IEnumerable<tbProveedores> ListProveedores()
        {
            try
            {
                var list = _proveedorRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbProveedores> prov = null;
                return prov;
            }
        }

        public ServiceResult InsertProveedor(tbProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _proveedorRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateProveedor(tbProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _proveedorRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteProveedor(tbProveedores item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _proveedorRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Proveedor
    }
}
