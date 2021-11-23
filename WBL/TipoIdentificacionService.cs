using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface ITipoIdentificacionService
    {
        Task<DBEntity> Create(TipoIdentificacionEntity entity);
        Task<DBEntity> Delete(TipoIdentificacionEntity entity);
        Task<IEnumerable<TipoIdentificacionEntity>> Get();
        Task<IEnumerable<TipoIdentificacionEntity>> GetLista();
        Task<TipoIdentificacionEntity> GetById(TipoIdentificacionEntity entity);
        Task<DBEntity> Update(TipoIdentificacionEntity entity);
    }

    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly IDataAccess sql;

        public TipoIdentificacionService(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region MetodosCRUD

        //Método GET
        public async Task<IEnumerable<TipoIdentificacionEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<TipoIdentificacionEntity>("exp.IdentificacionObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Método GET Lista
        public async Task<IEnumerable<TipoIdentificacionEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<TipoIdentificacionEntity>("exp.IdentificacionLista");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Método GET ID
        public async Task<TipoIdentificacionEntity> GetById(TipoIdentificacionEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<TipoIdentificacionEntity>("exp.IdentificacionObtener", new { entity.IdTipoIdentificacion });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método CREATE
        public async Task<DBEntity> Create(TipoIdentificacionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.IdentificacionInsertar", new
                {
                    entity.Identificacion
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método UPDATE
        public async Task<DBEntity> Update(TipoIdentificacionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.IdentificacionActualizar", new
                {
                    entity.IdTipoIdentificacion,
                    entity.Identificacion
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método ELIMINAR
        public async Task<DBEntity> Delete(TipoIdentificacionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.IdentificacionEliminar", new
                {
                    entity.IdTipoIdentificacion
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion

    }
}

