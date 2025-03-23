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

        #region Roles

        

        public IEnumerable<tbRoles> ListRoles()
        {
            try
            {
                var list = _rolRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbRoles> rol = null;
                return rol;
            }
        }

        // Insertar rol y asignar pantallas
        public ServiceResult InsertRoleWithScreens(tbRoles role, List<int> pantIds, int usuaCreacion)
        {
            var result = new ServiceResult();
            try
            {
                // Insertar rol
                var insertResult = _rolRepository.Insert(role);
                if (!insertResult.IsSuccess)
                {
                    return result.Error("Error al insertar el rol.");
                }

                // Asignar pantallas al rol
                foreach (var pantId in pantIds)
                {
                    var pantAsignResult = _rolRepository.AssignScreensToRole(new tbPantallasPorRol
                    {
                        Role_Id = role.Role_Id,
                        Pant_Id = pantId,
                        Usua_Creacion = usuaCreacion,
                        Feca_Creacion = DateTime.Now
                    });

                    if (!pantAsignResult.IsSuccess)
                    {
                        return result.Error($"Error al asignar la pantalla con ID {pantId} al rol.");
                    }
                }

                return result.Ok("Rol y pantallas asignadas correctamente.");
            }
            catch (Exception ex)
            {
                return result.Error($"Ocurrió un error: {ex.Message}");
            }
        }



        #endregion Roles
    }
}
