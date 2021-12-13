using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public sealed class Registry
    {
        private static readonly DataContext _context;
        private static readonly Dictionary<Type, string> _pathes;
        private static ISet<IServiceComponent> _services;

        static Registry()
        {
            _context = new DataContext();

            _services = new HashSet<IServiceComponent>(3)
            {
                new PlayerSevice(),
                new GameService(),
                new StadiumService()
            };

            _pathes = new Dictionary<Type, string>(3)
            {
                { typeof(FootballPlayer), "footballPlayer.txt" },
                { typeof(FootballGame), "footballGame.txt" },
                { typeof(FootballStadium), "footballStadium.txt" }
            };
        }

        public static T GetService<T>() where T : class, IServiceComponent
        {
            foreach (var service in _services)
                if (service is T res)
                    return res;

            throw new Exception($"Service with {typeof(T).Name} is not exist...");
        }

        public static void Add<T>(FieldCollection parameters) where T : IInitializable
        {
            var newEntity = Activator.CreateInstance(typeof(T)) as IInitializable;

            if (newEntity != null)
            {
                newEntity.Initialize(parameters);
                Save<T>(newEntity);
            }
        }

        public static void Delete<T>(FieldCollection parameters) where T : IFieldComparable
        {
            var entities = _context.Deserialize(_pathes[typeof(T)]).To<IFieldComparable>();
            var newEntitiesArray = entities.Delete(parameters);

            _context.Serialize(_pathes[typeof(T)], newEntitiesArray, false);
        }

        public static T[] Find<T>(FieldCollection parameters) where T : IFieldComparable
        {
            var loaded = Load<T>();
            return loaded.Where(obj => obj.IsMatch(parameters))
                .ToArray();
        }

        public static void Save<T>(object data, bool append = true)
        {
            string path = GetPath<T>();
            _context.Serialize(path, data, append);
        }

        public static T[] Load<T>()
        {
            string path = GetPath<T>();
            return _context.Deserialize(path).To<T>();
        }

        public static string GetPath<T>()
        {
            Type type = typeof(T);

            if (_pathes.ContainsKey(type))
                return _pathes[type];

            throw new Exception($"Path for {type.Name} is not exist...");
        }

        public static void DeleteAllAppointments()
        {
            _context.Serialize(_pathes[typeof(Appointment)], new Appointment[] { }, false);
        }
    }
}
