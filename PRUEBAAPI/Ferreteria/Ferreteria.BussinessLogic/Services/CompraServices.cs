using Ferreteria.DataAccess.Repositories;
using FerreteriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic.Services
{
    public class CompraServices
    {
        private readonly ProveedorRepository _proveedorRepository;
        private readonly CompraRepository _compraRepository;

        public CompraServices(ProveedorRepository proveedorRepository, CompraRepository compraRepository)
        {
            _proveedorRepository = proveedorRepository;
            _compraRepository = compraRepository;
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

        #region Compras

        public IEnumerable<tbCompras> BuscarCompra(tbCompras item)
        {
            var result = new ServiceResult();

            try
            {
                var list = _compraRepository.FindCompId(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCompras> comp = null;
                return comp;
            }
        }

        public IEnumerable<tbCompras> BuscarFecha(tbCompras item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _compraRepository.FindFechas(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCompras> comp = null;
                return comp;
            }
        }

        public IEnumerable<tbCompras> ListCompras()
        {
            try
            {
                var list = _compraRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCompras> comp = null;
                return comp;
            }
        }

        public IEnumerable<tbCompras> InsertCompra(tbCompras item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _compraRepository.InsertEncabezado(item).ToList();
                return insert;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCompras> comp = null;
                return comp;
            }
        }

        public ServiceResult InsertCompraDetalle(tbComprasDetalles item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _compraRepository.InsertDetalle(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateCompra(tbCompras item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _compraRepository.UpdateEncabezado(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult UpdateCompraDetalle(tbComprasDetalles item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _compraRepository.UpdateDetalle(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteCompra(tbCompras item, tbComprasDetalles cpde)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _compraRepository.Delete(item, cpde);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Compras
    }
}
