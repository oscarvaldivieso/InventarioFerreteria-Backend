using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferreteria.DataAccess.Repositories;
using FerreteriaEntities.Entities;

namespace Ferreteria.BussinessLogic.Services
{
    public class ProductoServices
    {
        private readonly CategoriaRepository _categoriaRepository;
        private readonly MarcaRepository _marcaRepository;
        private readonly MedidaRepository _medidaRepository;

        public ProductoServices(CategoriaRepository categoriaRepository, MarcaRepository marcaRepository, MedidaRepository medidaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _marcaRepository = marcaRepository;
            _medidaRepository = medidaRepository;
        }

        #region Categorias

        public IEnumerable<tbCategorias> BuscarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _categoriaRepository.FindCateId(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCategorias> cate = null;
                return cate;
            }
        }

        public IEnumerable<tbCategorias> ListCategorias()
        {
            try
            {
                var list = _categoriaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCategorias> cate = null;
                return cate;
            }
        }

        public ServiceResult InsertCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _categoriaRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _categoriaRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _categoriaRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Categorias

        #region Marcas

        public IEnumerable<tbMarcas> BuscarMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _marcaRepository.FindMarcId(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMarcas> marc = null;
                return marc;
            }
        }

        public IEnumerable<tbMarcas> ListMarcas()
        {
            try
            {
                var list = _marcaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMarcas> marc = null;
                return marc;
            }
        }

        public ServiceResult InsertMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _marcaRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _marcaRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteMarca(tbMarcas item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _marcaRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Marcas

        #region Medidas

        public IEnumerable<tbMedidas> BuscarMedida(tbMedidas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _medidaRepository.FindMediId(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMedidas> med = null;
                return med;
            }
        }

        public IEnumerable<tbMedidas> ListMedidas()
        {
            try
            {
                var list = _medidaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMedidas> med = null;
                return med;
            }
        }

        public ServiceResult InsertMedida(tbMedidas item)
        {
            var result = new ServiceResult();
            try
            {
                var insert = _medidaRepository.Insert(item);
                return result.Ok(insert);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateMedida(tbMedidas item)
        {
            var result = new ServiceResult();
            try
            {
                var update = _medidaRepository.Update(item);
                return result.Ok(update);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteMedida(tbMedidas item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _medidaRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Medidas
    }
}
