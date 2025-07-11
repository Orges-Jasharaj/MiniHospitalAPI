using MiniHospitalAPI.Models;
using MiniHospitalAPI.Dtos;

namespace MiniHospitalAPI.Services
{
    public class HospitalServices
    {
        public List<Patient> Patients { get; } = new();
        public List<Doctor> Doctors { get; } = new();
        public List<Appointment> Appointments { get; } = new();

        //public bool CreatePatients(Patient patient)
        //{
        //    Patient p = new Patient();
        //    p.Id=patient.Id;
        //    p.FullName=patient.FullName;
        //    p.Diagnosis=patient.Diagnosis;
        //    Patients.Add(p);
        //    return true;
        //}

        public bool CreatePatients(PatientDto patient)
        {
            Patient p = new Patient();
            p.Id = Patients.Count + 1;
            p.FullName = patient.FullName;
            p.Diagnosis = patient.Diagnosis;
            Patients.Add(p);
            return true;
        }


        public bool CreateDoctor(DoctorDto doctor)
        {
            Doctor d = new Doctor();
            d.Id = Doctors.Count + 1; 
            d.FullName = doctor.FullName;
            d.Specialty = doctor.Specialty;
            Doctors.Add(d);
            return true;
        }

        //public bool CreateDoctor(Doctor doctor)
        //{
        //    Doctor d = new Doctor();
        //    d.Id=doctor.Id;
        //    d.FullName = doctor.FullName;
        //    d.Specialty = doctor.Specialty;
        //    Doctors.Add(d);
        //    return true;    
        //}

        public bool CreateAppointment(AppointmentDto appointment)
        {
            var doctor = Doctors.FirstOrDefault(x => x.Id == appointment.DoctorId);
            if (doctor == null)
                return false;
            var patient = Patients.FirstOrDefault(x => x.Id == appointment.PatientId);
            if (patient == null)
                return false;
            Appointment a = new Appointment();
            a.Id = Appointments.Count + 1;
            a.DoctorId = appointment.DoctorId;
            a.PatientId = appointment.PatientId;
            a.Date = appointment.Date;
            Appointments.Add(a);
            return true;
        }


        //public bool CreateAppointment(Appointment appointment)
        //{
        //    var doctor = Doctors.FirstOrDefault(x => x.Id == appointment.DoctorId);
        //    if (doctor == null)
        //        return false;

        //    var patient = Patients.FirstOrDefault(x => x.Id == appointment.PatientId);
        //    if (patient == null)
        //        return false;

        //    Appointment a = new Appointment();
        //    a.Id = appointment.Id;
        //    a.DoctorId = appointment.DoctorId;
        //    a.PatientId = appointment.PatientId;
        //    a.Date = appointment.Date;

        //    Appointments.Add(a);
        //    return true;
        //}


        public bool EditPatient(PatientDto patient, int id)
        {
            var pat = Patients.Where(x => x.Id == id).FirstOrDefault();
            if (pat != null)
            {
                pat.FullName = patient.FullName;
                pat.Diagnosis = patient.Diagnosis;
                return true;
            }
            return false;
        }

        public bool EditDoctor(DoctorDto doctor, int id)
        {
            var doc = Doctors.Where(x => x.Id == id).FirstOrDefault();
            if (doc != null)
            {
                doc.FullName = doctor.FullName;
                doc.Specialty = doctor.Specialty;
                return true;
            }
            return false;
        }

        public bool EditAppointment(AppointmentDto appointment, int id)
        {
            var appo = Appointments.Where(x => x.Id == id).FirstOrDefault();
            if (appo != null)
            {
                appo.DoctorId = appointment.DoctorId;
                appo.PatientId = appointment.PatientId;
                appo.Date = appointment.Date;
                return true;
            }
            return false;
        }

        //public bool EditAppointment(Appointment appointment, int id)
        //{
        //    var appo = Appointments.Where(x=> x.Id == id).FirstOrDefault();
        //    if (appo != null)
        //    {
        //        appo.Id = appointment.Id;
        //        appo.DoctorId = appointment.DoctorId;
        //        appo.PatientId = appointment.PatientId;
        //        appo.Date = appointment.Date;
        //        return true;
        //    }
        //    return false;
        //}

        public bool DeleteAppointment(int id)
        {
            var appo = Appointments.Where(x => x.Id == id).FirstOrDefault();
            if (appo != null)
            {
                Appointments.Remove(appo);
                return true;
            }
            return false;
        }

        public List<AppointmentDto> GetAllAppointment()
        {
            return Appointments.Select(x => new AppointmentDto
            {
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
                Date = x.Date
            }).ToList();
        }

        public List<PatientDto> GetAllPatient()
        {
            return Patients.Select(x => new PatientDto
            {
                FullName = x.FullName,
                Diagnosis = x.Diagnosis
            }).ToList();
        }

        public List<DoctorDto> GetAllDoctor()
        {
            return Doctors.Select(x => new DoctorDto
            {
                FullName = x.FullName,
                Specialty = x.Specialty
            }).ToList();
        }

    }
}
