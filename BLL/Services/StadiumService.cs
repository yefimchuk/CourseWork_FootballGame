using System;
using System.Linq;

namespace BLL
{
    public class StadiumService : IServiceComponent
    {
        public void Change(FieldCollection doctorFields, FieldCollection newFields)
        {
            var doctors = Registry.Load<FootballStadium>().To<IFieldComparable>();
            var doctor = doctors.Where(entity => entity.IsMatch(doctorFields)).First() as FootballStadium;

            if (doctor == null)
                throw new Exception($"Doctor {doctorFields["Surname"]} {doctorFields["Name"]} is not exist...");

            if (CanBeChaged(doctor) == false)
                throw new Exception("Doctor has appointments...");

            ((IChangeable)doctor).Change(newFields);

            Registry.Save<FootballStadium>(doctors, false);
        }

        private bool CanBeChaged(FootballStadium doctor)
        {
            return true;
        }
    }
}
