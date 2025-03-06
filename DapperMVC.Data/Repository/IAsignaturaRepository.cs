using DapperMVC.Data.Models.Domain;
using DapperMVC.Data.Models.DTOs;

namespace DapperMVC.Data.Repository
{
    public interface IAsignaturaRepository
    {
        Task<bool> AddAsync(TAsignatura asignatura);
        Task<bool> UpdateAsync(TAsignatura asignatura);
        Task<TAsignatura?> GetByIdAsync(int id);
        Task<PagedResult<AsignaturaDto>> GetAllAsync(int pageNumber = 1, int pageSize = 10);
    }
}