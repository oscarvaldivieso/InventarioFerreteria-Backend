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
    }
}