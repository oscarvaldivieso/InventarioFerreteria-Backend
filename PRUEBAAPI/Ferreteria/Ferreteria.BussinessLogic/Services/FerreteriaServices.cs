using Ferreteria.DataAccess.Repositories;
using FerreteriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic.Services
{
    public class FerreteriaServices
    {
        private readonly CargoRepository _cargoRepository;
        private readonly EmpleadoRepository _empleadoRepository;
        private readonly SucursalRepository _sucursalRepository;

        public FerreteriaServices(CargoRepository cargoRepository, EmpleadoRepository empleadoRepository, SucursalRepository sucursalRepository)
        {
            _cargoRepository = cargoRepository;
            _empleadoRepository = empleadoRepository;
            _sucursalRepository = sucursalRepository;
        }

        #region Cargos

        public IEnumerable<tbCargos> BuscarCargo(tbCargos item)
        {  
            var result = new ServiceResult();
            try
            {
                var list = _cargoRepository.FindCargId(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCargos> carg = null;
                return carg;
            }
        }

        public IEnumerable<tbCargos> ListCargos() 
        {
            try
            {
                var list = _cargoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCargos> carg = null;
                return carg;
            }
        }

        public ServiceResult InsertCargo(tbCargos item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _cargoRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateCargo(tbCargos item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _cargoRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteCargo(tbCargos item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _cargoRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Cargos

        #region Empleados

        public IEnumerable<tbEmpleados> BuscarEmpleado(tbEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _empleadoRepository.FindEmplDNI(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbEmpleados> empl = null;
                return empl;
            }
        }

        public IEnumerable<tbEmpleados> ListEmpleados()
        {
            try
            {
                var list = _empleadoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbEmpleados> empl = null;
                return empl;
            }
        }

        public ServiceResult InsertEmpleado(tbEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _empleadoRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateEmpleado(tbEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _empleadoRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteEmpleado(tbEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _empleadoRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Empleados

        #region Sucursales

        public IEnumerable<tbSucursales> BuscarSucursal(tbSucursales item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _sucursalRepository.FindSucuId(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbSucursales> sucu = null;
                return sucu;
            }
        }

        public IEnumerable<tbSucursales> ListSucursales()
        {
            try
            {
                var list = _sucursalRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbSucursales> sucu = null;
                return sucu;
            }
        }

        public ServiceResult InsertSucursak(tbSucursales item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _sucursalRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateSucursal(tbSucursales item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _sucursalRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteSucursal(tbSucursales item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _sucursalRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Sucursales
    }
}