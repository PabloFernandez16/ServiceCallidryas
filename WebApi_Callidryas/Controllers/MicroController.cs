using Microsoft.AspNetCore.Mvc;
using WebApi_Callidryas.Interfaces;
using WebApi_Callidryas.Models.DTO;

namespace WebApi_Callidryas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicroController : ControllerBase
    {
        private readonly IMicroRepository _MicroRepository;

        public MicroController(IMicroRepository MicroRepository)
        {
            _MicroRepository = MicroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _MicroRepository.GetAsync();
            return Ok(list);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOne(int Id)
        {
            var model = await _MicroRepository.GetOneAsync(Id);
            return Ok(model);
        }

        // Método para agregar un registro de Micro de forma asincrónica
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MicroDTO model)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var response = await _MicroRepository.AddAsync(model);
            if (response.Success == 1) {
                return Ok(response);
            }
            return BadRequest(response);
        }
        // Método para agregar un registro de Micro de forma asincrónica
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] MicroDTO model, int Id){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var response = await _MicroRepository.UpdateAsync(model, Id);
            if (response.Success == 1) {
                return Ok(response);
            }
            return BadRequest(response);
        }

        // Método para Eliminar un registro de Micro de forma asincrónica
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            try
            {
                var response = await _MicroRepository.DeleteAsync(Id);

                // Verificar si la operación fue exitosa
                if (response.Success == 1)
                {
                    return Ok(response);
                }else{
                    return NotFound(response); // Retorna 404 si no se encontró el registro
                }
            } catch (Exception ex) {
                return StatusCode(500, new { Success = 0, Message = $"Error interno: {ex.Message}" });
            }
        }
    }
}