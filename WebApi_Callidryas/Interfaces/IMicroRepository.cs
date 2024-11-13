

using WebApi_Callidryas.Models.DTO;
using WebApi_Callidryas.Models.Response;

namespace WebApi_Callidryas.Interfaces;

public interface IMicroRepository{

    // Task<Response> GetAsync(int pageNumber = 1, int pageSize = 10);
    Task<Response> GetAsync();
    Task<Response> GetOneAsync(int Id);
    Task<Response> AddAsync(MicroDTO model);
    Task<Response> UpdateAsync(MicroDTO model, int Id);
    Task<Response> DeleteAsync(int Id);

}