using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Registry : IDoctorService, IPatientService
    {
        private DataContext _context;

        // temp pathes
        private Dictionary<Type, string> _pathes;

        public Registry()
        {
            _context = new DataContext();

            _pathes = new Dictionary<Type, string>();
            _pathes.Add(typeof(FootballPlayer),"footballPlayer.txt");
          
        }

        public void Add<T>(FieldInitializer parameters) where T : IInitializable
        {
            var newEntity = Activator.CreateInstance(typeof(T)) as IInitializable;

            if (newEntity != null)
            {
                newEntity.Initialize(parameters);
                _context.Serialize(_pathes[typeof(T)], newEntity);
            }
        }

        public void Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void Chande(FootballPlayer doctor)
        {
            throw new NotImplementedException();
        }

      /*  public void ChangeCard(Patient patient)
        {
            throw new NotImplementedException();
        }*/
    }
}
