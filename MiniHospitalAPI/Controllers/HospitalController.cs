using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniHospitalAPI.Models;
using MiniHospitalAPI.Services;

namespace MiniHospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalServices _hospitalServices;

        public HospitalController(HospitalServices hospitalServices)
        {
            _hospitalServices = hospitalServices;
        }

        //[HttpPost]
        //public IActionResult CreatePatient([FromBody] Patient pt)
        //{
        //    return Ok(_hospitalServices.CreatePatients(pt));
        //}
        //[HttpPost]
        //public IActionResult CreateDoctor([FromBody] Doctor dt)
        //{
        //    return Ok(_hospitalServices.CreateDoctor(dt));
        //}
        //[HttpPost]
        //public IActionResult CreateAppo([FromBody] Appointment at)
        //{
        //    return Ok(_hospitalServices.CreateAppointment(at));
        //}
        [HttpPost("patient")]
        public IActionResult CreatePatient([FromBody] Patient pt)
        {
            return Ok(_hospitalServices.CreatePatients(pt));
        }

        [HttpPost("doctor")]
        public IActionResult CreateDoctor([FromBody] Doctor dt)
        {
            return Ok(_hospitalServices.CreateDoctor(dt));
        }

        [HttpPost("appointment")]
        public IActionResult CreateAppo([FromBody] Appointment at)
        {
            return Ok(_hospitalServices.CreateAppointment(at));
        }



        [HttpPut("{id}")]
        public IActionResult UpdateAppo([FromBody] Appointment at, int id)
        {
            return Ok(_hospitalServices.EditAppointment(at, id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppo(int id)
        {
            return Ok(_hospitalServices.DeleteAppointment(id));
        }

        [HttpGet("appointment")]
        public IActionResult Get()
        {
            return Ok(_hospitalServices.GetAllAppointment());
        }

        [HttpGet("patient")]
        public IActionResult GetPatient()
        {
            return Ok(_hospitalServices.GetAllPatient());
        }

        [HttpGet("doctor")]
        public IActionResult GetDoctor()
        {
            return Ok(_hospitalServices.GetAllDoctor());
        }







    }
}
