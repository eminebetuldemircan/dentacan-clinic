using Business.Abstract;
using Entities.Dtos.DoctorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        IDoctorService _doctorService;
        public DoctorsController(IDoctorService DoctorService)
        {
            _doctorService = DoctorService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllDoctor()
        {
            var result = await _doctorService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewDoctor(DoctorCreateDto DoctorAddDto)
        {
            var result = await _doctorService.AddAsync(DoctorAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("[action]/{DoctorId:int}")]
        public async Task<IActionResult> GetDoctorById(int DoctorId)
        {
            var result = await _doctorService.GetByIdAsync(DoctorId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }




        [HttpDelete]
        [Route("[action]/{DoctorId:int}")]
        public async Task<IActionResult> DeleteDoctor(int DoctorId)
        {
            var result = await _doctorService.DeleteAsync(DoctorId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateDoctor([FromBody] DoctorUpdateDto DoctorUpdateDto)
        {
            var result = await _doctorService.UpdateAsync(DoctorUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
