using Ferreteria.DataAccess.Repositories;
using FerreteriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic.Services
{

    public class GeneralServices
    {
        private readonly DepartamentoRepository _departamentoRepository;
        public GeneralServices(DepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        #region Departamento
        public IEnumerable<tbDepartamentos> ListDepartamentos()
        {
            
            try
            {
                var list = _departamentoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbDepartamentos> depa = null;
                return depa;
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
        #endregion
    }
}
