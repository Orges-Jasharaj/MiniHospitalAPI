using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniHospitalAPI.Dtos;
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
        public IActionResult CreatePatient([FromBody] PatientDto pt)
        {
            return Ok(_hospitalServices.CreatePatients(pt));
        }


        [HttpPost("doctor")]
        public IActionResult CreateDoctor([FromBody] DoctorDto dt)
        {
            return Ok(_hospitalServices.CreateDoctor(dt));
        }

        [HttpPost("appointment")]
        public IActionResult CreateAppo([FromBody] AppointmentDto at)
        {
            return Ok(_hospitalServices.CreateAppointment(at));
        }



        [HttpPut("appointment/{id}")]
        public IActionResult UpdateAppo([FromBody] AppointmentDto at, int id)
        {
            return Ok(_hospitalServices.EditAppointment(at, id));
        }


        [HttpPut("patient/{id}")]
        public IActionResult UpdatePatient([FromBody] PatientDto pt, int id)
        {
            return Ok(_hospitalServices.EditPatient(pt, id));
        }

        [HttpPut("doctor/{id}")]
        public IActionResult UpdateDoctor([FromBody] DoctorDto dt, int id)
        {
            return Ok(_hospitalServices.EditDoctor(dt, id));
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
