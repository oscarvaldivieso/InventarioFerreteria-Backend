﻿using Ferreteria.DataAccess.Repositories;
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
        private readonly EstadoCivilRepository _estadoCivilRepository;
        private readonly MunicipioRepository _municipioRepository;

        public readonly GeneralServices(DepartamentoRepository departamentoRepository,
                                EstadoCivilRepository estadoCivilRepository,
                                MunicipioRepository municipioRepository)
        {
            _departamentoRepository = departamentoRepository;
            _estadoCivilRepository = estadoCivilRepository;
            _municipioRepository = municipioRepository;
        }

        #region Departamento

        public IEnumerable<tbDepartamentos> BuscarDepartamento(tbDepartamentos item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository.FindCodigo(item.Depa_Codigo);
                return list;
            }
            catch (Exception ex)
            {

                IEnumerable<tbDepartamentos> depa = null;
                return depa;
            }
        }


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

        #endregion Departamento

        #region EstadoCivil

        public ServiceResult ListEstadoCivil()
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoCivilRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertEstadoCivil(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _estadoCivilRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateEstadoCivil(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _estadoCivilRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteEstadoCivil(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _estadoCivilRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion EstadoCivil

        #region Municipio

        public ServiceResult ListMunicipio()
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertMunicipio(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _municipioRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateMunicipio(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _municipioRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteMunicipio(tbMunicipios item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _municipioRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Municipio
    }
}