using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi_Callidryas.Data;
using WebApi_Callidryas.Interfaces;
using WebApi_Callidryas.Models;
using WebApi_Callidryas.Models.DTO;
using WebApi_Callidryas.Models.Response;

namespace WebApi_Callidryas.Repository
{
    public class DriverRepository : IDriverRepository {
        private readonly CallidryasDbContext _dbContext;
        private readonly IMapper _mapper;

        public DriverRepository(CallidryasDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Response> GetAsync() {
            Response oResponse = new Response();

            try {
                var list = await _dbContext.Drivers.OrderByDescending(d=>d.Id).ToListAsync();
                oResponse.Data = list;
                oResponse.Success = 1;
            }
            catch (Exception ex){
                oResponse.Message = ex.Message;
                oResponse.Success = 0;
            }

            return oResponse;
        }
        // public async Task<Response> GetAsync(int pageNumber = 1, int pageSize = 10) {
        //     var response = new Response();

        //     try {
        //         // Validación de parámetros de paginación
        //         pageNumber = pageNumber < 1 ? 1 : pageNumber;
        //         pageSize = pageSize < 1 ? 10 : pageSize;

        //         // Obtener la lista de Drivers con paginación y solo los campos necesarios
        //         var list = await _dbContext.Drivers
        //             .OrderBy(d => d.DriverName) // Ordenar por nombre, por ejemplo
        //             .Skip((pageNumber - 1) * pageSize)
        //             .Take(pageSize)
        //             .Select(d => new DriverDTO {
        //                 DriverName = d.DriverName,
        //                 DriverLastName = d.DriverLastName,
        //                 // Agregar solo los campos necesarios
        //             })
        //             .ToListAsync();

        //         // Asignar la lista de datos y el estado de éxito a la respuesta
        //         response.Data = list;
        //         response.Success = 1;
        //     }
        //     catch (DbUpdateException dbEx) {
        //         response.Message = $"Error en la base de datos al obtener los Drivers: {dbEx.Message}";
        //         response.Success = 0;
        //     }
        //     catch (Exception ex) {
        //         response.Message = $"Error inesperado al obtener los Drivers: {ex.Message}";
        //         response.Success = 0;
        //     }

        //     return response;
        // }

        public async Task<Response> GetOneAsync(int Id) {
            Response oResponse = new Response();

            try {
                // Filtramos por el Id recibido
                var driver = await _dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == Id);

                if (driver == null) {
                    oResponse.Message = "Driver not found.";
                    oResponse.Success = 0;
                } else {
                    oResponse.Data = driver;
                    oResponse.Success = 1;
                }
            } catch (DbUpdateException dbEx) {
                oResponse.Success = 0;
                oResponse.Message = $"Error en la base de datos al agregar el Driver: {dbEx.Message}";
            } catch (Exception ex) {
                oResponse.Success = 0;
                oResponse.Message = $"Error inesperado al agregar el Driver: {ex.Message}";
            }

            return oResponse;
        }


        public async Task<Response> AddAsync(DriverDTO model) {
            var oResponse = new Response();

            try {
                // Validación: Verifica si el modelo es nulo o si faltan campos requeridos
                if (model == null || string.IsNullOrWhiteSpace(model.DriverName) || string.IsNullOrWhiteSpace(model.DriverLastName)) {
                    oResponse.Success = 0;
                    oResponse.Message = "Datos inválidos: verifica que el modelo y los campos requeridos sean correctos.";
                    return oResponse;
                }

                // Mapea el DTO a la entidad Driver
                var driverEntity = _mapper.Map<Driver>(model);

                // Agregar la entidad y guardar cambios dentro de una transacción controlada
                await _dbContext.Drivers.AddAsync(driverEntity);
                await _dbContext.SaveChangesAsync();

                oResponse.Success = 1;
                oResponse.Message = "Driver agregado exitosamente.";
            } catch (DbUpdateException dbEx) {
                oResponse.Success = 0;
                oResponse.Message = $"Error en la base de datos al agregar el Driver: {dbEx.Message}";
            } catch (Exception ex) {
                oResponse.Success = 0;
                oResponse.Message = $"Error inesperado al agregar el Driver: {ex.Message}";
            }

            return oResponse;
        }


        public async Task<Response> UpdateAsync(DriverDTO model, int Id) {
            var oResponse = new Response();

            try {
                // Validación: Verificar modelo, ID 
                if (model == null || Id <= 0 ) {
                    oResponse.Success = 0;
                    oResponse.Message = "Datos inválidos: Verifica que el modelo e ID sean correctos.";
                    return oResponse;
                }

                // Buscar el registro existente
                var existingDriver = await _dbContext.Drivers.FindAsync(Id);
                if (existingDriver == null) {
                    oResponse.Success = 0;
                    oResponse.Message = "El registro especificado no existe.";
                    return oResponse;
                }

                // Mapear solo los cambios necesarios
                _mapper.Map(model, existingDriver);

                // Guardar los cambios solo si hubo modificaciones
                if (_dbContext.Entry(existingDriver).State == EntityState.Modified) {
                    await _dbContext.SaveChangesAsync();
                    oResponse.Success = 1;
                    oResponse.Message = "Driver actualizado exitosamente.";
                }else {
                    oResponse.Success = 1;
                    oResponse.Message = "No se detectaron cambios para actualizar.";
                }
            }catch (DbUpdateException dbEx) {
                oResponse.Success = 0;
                oResponse.Message = $"Error en la base de datos al actualizar el Drive {dbEx.Message}";
            }catch (Exception ex) {
                oResponse.Success = 0;
                oResponse.Message = $"Error inesperado al actualizar el Driver: {ex.Message}";
            }

            return oResponse;
        }


        // Método en el repositorio para eliminar un registro de Driver
        public async Task<Response> DeleteAsync(int Id) {
            var oResponse = new Response();
            try {
                // Verificar si el registro existe en la base de datos
                var existingDriver = await _dbContext.Drivers.FindAsync(Id);

                if (existingDriver == null) {
                    oResponse.Success = 0;
                    oResponse.Message = "El registro especificado no existe.";
                    return oResponse;
                }

                // Eliminar el registro en la base de datos
                _dbContext.Drivers.Remove(existingDriver);
                await _dbContext.SaveChangesAsync();

                oResponse.Success = 1;
                oResponse.Message = "Driver eliminado exitosamente.";
            } catch (Exception ex) {
                // En caso de error, log o manejo adicional
                oResponse.Success = 0;
                oResponse.Message = $"Error al eliminar el Driver: {ex.Message}";
            }

            return oResponse;
        }

    }
}
