using System;
using System.Linq;

namespace BLL
{
    public class GameService : IServiceComponent
    {
        public void Change(FieldCollection doctorFields, FieldCollection newFields)
        {
            var doctors = Registry.Load<FootballGame>().To<IFieldComparable>();
            var doctor = doctors.Where(entity => entity.IsMatch(doctorFields)).First() as FootballGame;

            if (doctor == null)
                throw new Exception($"Doctor {doctorFields["Surname"]} {doctorFields["Name"]} is not exist...");

            if (CanBeChaged(doctor) == false)
                throw new Exception("Doctor has appointments...");

            ((IChangeable)doctor).Change(newFields);

            Registry.Save<FootballGame>(doctors, false);
        }

        private bool CanBeChaged(FootballGame doctor)
        {
            return true;
        }
    }
}
