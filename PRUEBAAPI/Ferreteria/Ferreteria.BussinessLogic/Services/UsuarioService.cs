﻿using Ferreteria.DataAccess.Repositories;
using Ferreteria.Entities.Entities;
using FerreteriaEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.BussinessLogic.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(string connectionString)
        {
            _usuarioRepository = new UsuarioRepository(connectionString);
        }

        #region Usuarios
        public async Task<UsuarioLoginResponse> ValidarLogin(string usuario, string contrasena)
        {
            return await _usuarioRepository.IniciarSesion(usuario, contrasena);
        }

        public IEnumerable<tbUsuarios> BuscarUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.FindUsuaId(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbUsuarios> cate = null;
                return cate;
            }
        }

        public IEnumerable<tbUsuarios> ListUsuarios()
        {
            try
            {
                var list = _usuarioRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbUsuarios> cate = null;
                return cate;
            }
        }

        public ServiceResult InsertUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _usuarioRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _usuarioRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteUsuario(tbUsuarios item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _usuarioRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion Usuarios
    }
}
