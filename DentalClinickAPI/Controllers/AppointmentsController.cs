using Business.Abstract;
using Core.Results;
using Entities.Dtos.AppointmentDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService AppointmentService)
        {
            _appointmentService = AppointmentService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAppointment()
        {
            var result = await _appointmentService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAppointmentByDateAndDoctor(string date,int doctorId)
        {
            var result = await _appointmentService.GetListAsync(x =>x.Date == date && x.DoctorId == doctorId);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddNewAppointment(AppointmentCreateDto AppointmentAddDto)
        {
            var result = await _appointmentService.AddAsync(AppointmentAddDto);
            if (result != null && result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("[action]/{AppointmentId:int}")]
        public async Task<IActionResult> GetAppointmentById(int AppointmentId)
        {
            var result = await _appointmentService.GetByIdAsync(AppointmentId);
            if (result != null && result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }




        [HttpDelete]
        [Route("[action]/{AppointmentId:int}")]
        public async Task<IActionResult> DeleteAppointment(int AppointmentId)
        {
            var result = await _appointmentService.DeleteAsync(AppointmentId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAppointment([FromForm] AppointmentUpdateDto AppointmentUpdateDto)
        {
            var result = await _appointmentService.UpdateAsync(AppointmentUpdateDto);

            if (result != null && result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPut]
        [Route("[action]/{AppointmentId:int}")]
        public async Task<IActionResult> VerificationAppointment(int AppointmentId, string verificationCode)
        {
            var result = await _appointmentService.VerificationByIdAsync(AppointmentId,verificationCode);

            if (result != null && result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]/{AppointmentId:int}")]
        public async Task<IActionResult> CancelAppointment(int AppointmentId)
        {
            var result = await _appointmentService.DeleteAsync(AppointmentId);

            if (result != null && result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> ChangeAppointment(string token)
        {
            var result = await _appointmentService.ChangeAppointmentAsync(token);

            if (result != null && result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        

    }
}
