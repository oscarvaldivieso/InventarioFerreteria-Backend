using Ferreteria.DataAccess.Repositories;
using FerreteriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic.Services
{
    public class AccesoServices
    {
        private readonly RolRepository _rolRepository;

        public AccesoServices(RolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        #region Rol

        public IEnumerable<tbRoles> ListRoles()
        {
            try
            {
                return _rolRepository.List();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ServiceResult InsertRol(tbRoles item, List<int> pantIds)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _rolRepository.InsertWithScreens(item, pantIds);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }


        public ServiceResult UpdateRol(tbRoles item, List<int> pantIds)
        {
            var result = new ServiceResult();
            try
            {
                var update = _rolRepository.UpdateWithScreens(item, pantIds);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _rolRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult FindRolById(int roleId)
        {
            var result = new ServiceResult();
            try
            {
                var rol = _rolRepository.FindRolById(roleId);
                return result.Ok(rol);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult PantallasPorRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var pantallas = _rolRepository.PantallasPorRol(item);
                return result.Ok(pantallas);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Rol
    }
}
