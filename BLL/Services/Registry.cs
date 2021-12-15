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
      /*  public void AddBookToReader(FieldCollection parameters, Book book)
        {
            IFieldComparable[] readers = ReceiveAll<Reader>(); //         checked is null
            var finded = FindFirst<Reader>(readers, parameters);
            finded.AddOffer(book);
            _context.Serialize(_pathes[typeof(Reader)], readers, false);
        }

        public Book[] ShowBookFromReader(FieldCollection parameters)
        {
            IFieldComparable[] readers = ReceiveAll<Reader>(); //         checked is null
            var finded = FindFirst<Reader>(readers, parameters);
            return new List<Book>(finded.Books).ToArray();
        }*/
        public static void AddGamePlayer(FieldCollection parameters, FootballPlayer book)
        {


            FootballGame[] games = Load<FootballGame>();
            var finded = games.Where(game => game.IsMatch(parameters)).ToArray();

            for (int i = 0; i < finded.Length; i++)
            {
                finded[i].AddOffer(book);
            }
  
            _context.Serialize(_pathes[typeof(FootballGame)], games, false);
        }
        public static void DeleteGamePlayer(FieldCollection parameters, FootballPlayer book)
        {


            FootballGame[] games = Load<FootballGame>();
            var finded = games.Where(game => game.IsMatch(parameters)).ToArray();
            for (int i = 0; i < finded.Length; i++)
            {
                finded[i].DeleteOffer(book);
            }

            _context.Serialize(_pathes[typeof(FootballGame)], games, false);
        }

        public static FootballGame[] ShowBookFromReader(FieldCollection parameters)
        {
            IFieldComparable[] readers = Load<FootballPlayer>(); //checked is null
            FootballGame[] finded = Find<FootballGame>(parameters);
            return new List<FootballGame>(finded).ToArray();
        }
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
