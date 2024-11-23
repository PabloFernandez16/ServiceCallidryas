

using WebApi_Callidryas.Models.DTO;
using WebApi_Callidryas.Models.Response;

namespace WebApi_Callidryas.Interfaces;

public interface IDriverRepository{

    // Task<Response> GetAsync(int pageNumber = 1, int pageSize = 10);
    Task<Response> GetAsync();
    Task<Response> GetOneAsync(int Id);
    Task<Response> AddAsync(DriverDTO model);
    Task<Response> UpdateAsync(DriverDTO model, int Id);
    Task<Response> DeleteAsync(int Id);
}