using Business.Abstract;
using Entities.Dtos.ContactUsDtos;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsesController : ControllerBase
    {
        IContactUsService _contactUsService;
        public ContactUsesController(IContactUsService ContactUsService)
        {
            _contactUsService = ContactUsService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetAllContactUs()
        {
            var result = await _contactUsService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewContactUs(ContactUsCreateDto ContactUsAddDto)
        {
            var result = await _contactUsService.AddAsync(ContactUsAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("[action]/{ContactUsId:int}")]
        public async Task<IActionResult> GetContactUsById(int ContactUsId)
        {
            var result = await _contactUsService.GetByIdAsync(ContactUsId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }




        [HttpDelete]
        [Route("[action]/{ContactUsId:int}")]
        public async Task<IActionResult> DeleteContactUs(int ContactUsId)
        {
            var result = await _contactUsService.DeleteAsync(ContactUsId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }
    }
}
