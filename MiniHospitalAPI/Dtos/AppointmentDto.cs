namespace MiniHospitalAPI.Dtos
{
    public class AppointmentDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }

    }
}
