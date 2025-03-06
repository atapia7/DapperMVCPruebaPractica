using Dapper;
using DapperMVC.Data.DataAccess;
using DapperMVC.Data.Models.Domain;
using DapperMVC.Data.Models.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DapperMVC.Data.Repository;

    public class AsignaturaRepository : IAsignaturaRepository
    {
        private readonly ISqlDataAccess _db;

        public AsignaturaRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(TAsignatura asignatura)
        {
            try
            {
               await _db.SaveData("sp_create", new {asignatura.Asignatura});

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(TAsignatura asignatura) 
        {
            try
            {
                await _db.SaveData("sp_update", asignatura);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<TAsignatura?> GetByIdAsync(int id)
        {
            IEnumerable<TAsignatura> result = await _db.GetData<TAsignatura, dynamic>("sp_getById", new { id });
            return result.FirstOrDefault();
        }

        //public async Task<IEnumerable<TAsignatura>> GetAllAsync(int pageNumber=1, int pageSize=10)
        //{
        //    if (pageNumber < 1 || pageSize < 1)
        //        throw new ArgumentException("Los valores de paginación deben ser mayores a 0.");

        //    try
        //    {
        //        return await _db.GetData<TAsignatura, dynamic>("sp_GetAsignaturasEnfermeria", new { PageNumber = pageNumber, PageSize = pageSize });
        //    }
        //    catch (SqlException ex)
        //    {
        //        return Enumerable.Empty<TAsignatura>();
        //    }
        //}

    public async Task<PagedResult<AsignaturaDto>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
    {
        if (pageNumber < 1 || pageSize < 1)
            throw new ArgumentException("Los valores de paginación deben ser mayores a 0.");

        try
        {
            using var connection = _db.GetConnection(); // Asegúrate de tener este método en `ISqlDataAccess`

            var parameters = new { PageNumber = pageNumber, PageSize = pageSize };

            using var multi = await connection.QueryMultipleAsync("sp_GetAsignaturasEnfermeria", parameters, commandType: CommandType.StoredProcedure);

            var asignaturas = await multi.ReadAsync<AsignaturaDto>();
            var totalRecords = await multi.ReadFirstOrDefaultAsync<int>();

            return new PagedResult<AsignaturaDto>
            {
                Data = asignaturas,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        catch (SqlException)
        {
            return new PagedResult<AsignaturaDto>(); // Retorna un objeto vacío en caso de error
        }
    }




}