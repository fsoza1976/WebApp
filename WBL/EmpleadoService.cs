using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IEmpleadoService
    {
        Task<DBEntity> Create(EmpleadoEntity entity);
        Task<DBEntity> Delete(EmpleadoEntity entity);
        Task<IEnumerable<EmpleadoEntity>> Get();
        Task<EmpleadoEntity> GetById(EmpleadoEntity entity);
        Task<DBEntity> Update(EmpleadoEntity entity);
    }

    public class EmpleadoService : IEmpleadoService
    {
        private readonly IDataAccess sql;

        public EmpleadoService(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region MetodosCRUD

        //Método GET
        public async Task<IEnumerable<EmpleadoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<EmpleadoEntity, TipoIdentificacionEntity>("exp.EmpleadoObtener", "IdEmpleado, IdTipoIdentificacion");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método GET ID
        public async Task<EmpleadoEntity> GetById(EmpleadoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<EmpleadoEntity>("exp.EmpleadoObtener", new { entity.IdEmpleado });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método CREATE
        public async Task<DBEntity> Create(EmpleadoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.EmpleadoInsertar", new
                {
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.Edad,
                    entity.FechaNacimiento,
                    entity.TipoIdentificacion,
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
        public async Task<DBEntity> Update(EmpleadoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.EmpleadoActualizar", new
                {
                    entity.IdEmpleado,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.Edad,
                    entity.FechaNacimiento,
                    entity.TipoIdentificacion,
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
        public async Task<DBEntity> Delete(EmpleadoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.EmpleadoEliminar", new
                {
                    entity.IdEmpleado
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
