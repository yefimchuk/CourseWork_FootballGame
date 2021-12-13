using System;
using System.Linq;

namespace BLL
{
    public class PlayerSevice : IServiceComponent
    {
        public void Change(FieldCollection doctorFields, FieldCollection newFields)
        {
            var doctors = Registry.Load<FootballPlayer>().To<IFieldComparable>();
            var doctor = doctors.Where(entity => entity.IsMatch(doctorFields)).First() as FootballPlayer;

            if (doctor == null)
                throw new Exception($"Doctor {doctorFields["Surname"]} {doctorFields["Name"]} is not exist...");

            if (CanBeChaged(doctor) == false)
                throw new Exception("Doctor has appointments...");

            ((IChangeable)doctor).Change(newFields);

            Registry.Save<FootballPlayer>(doctors, false);
        }

        private bool CanBeChaged(FootballPlayer doctor)
        {
            return true;
        }
    }
}
