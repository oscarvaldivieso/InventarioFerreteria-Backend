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

        public FerreteriaServices(CargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        #region Cargos

        public IEnumerable<tbCargos> BuscarCargo(tbCargos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _cargoRepository.FindCargId(item.Carg_Id);
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

        public ServiceResult InsertDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _departamentoRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _departamentoRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _departamentoRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Cargos
    }
}