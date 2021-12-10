using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class Registry : IFootBallService, IGameService
    {
        private DataContext _context;

        // temp pathes
        private Dictionary<Type, string> _pathes;

        public Registry()
        {
            _context = new DataContext();

            _pathes = new Dictionary<Type, string>();
            _pathes.Add(typeof(FootballPlayer), "footballPlayer.txt");
            _pathes.Add(typeof(FootballGame), "footballGame.txt");
        }

        public void Add<T>(FieldCollection parameters) where T : IInitializable
        {
            var newEntity = Activator.CreateInstance(typeof(T)) as IInitializable;

            if (newEntity != null)
            {
                newEntity.Initialize(parameters);
                _context.Serialize(_pathes[typeof(T)], newEntity);
            }
        }

        public FootballPlayer[] GetAllDoctors() => _context.Deserialize(_pathes[typeof(FootballPlayer)]).ToArray<FootballPlayer>();

        public void Delete<T>(FieldCollection parameters) where T : IFieldComparable
        {
            var entities = _context.Deserialize(_pathes[typeof(T)]).ToArray<IFieldComparable>();
            var newEntitiesArray = Delete(entities, parameters);

            _context.Serialize(_pathes[typeof(T)], newEntitiesArray, false);
        }

        public FootballGame[] GetAllGame() => _context.Deserialize(_pathes[typeof(FootballGame)]).ToArray<FootballGame>();

        public void Change(FieldCollection parameters, FieldCollection newParameters)
        {
            var entities = _context.Deserialize(_pathes[typeof(FootballPlayer)]).ToArray<IFieldComparable>();
            var footballPlayer = FindFirst<FootballPlayer>(entities, parameters);

            if (CanBeChaged(footballPlayer) == false)
                throw new Exception(); // TODO создать кастомное исключение

            Change(footballPlayer, newParameters);

            Delete<FootballPlayer>(parameters);
            _context.Serialize(_pathes[typeof(FootballPlayer)], footballPlayer);
        }

        public void ChangeGames(FieldCollection parameters, FieldCollection newParameters)
        {
            var entities = _context.Deserialize(_pathes[typeof(FootballGame)]).ToArray<IFieldComparable>();
            var footballPlayer2 = FindFirst<FootballGame>(entities, parameters);

            if (CanBeChaged(footballPlayer2) == false)
                throw new Exception(); // TODO создать кастомное исключение

            Change(footballPlayer2, newParameters);

            Delete<FootballGame>(parameters);
            _context.Serialize(_pathes[typeof(FootballGame)], footballPlayer2);
        }

        private bool CanBeChaged(FootballGame footballPlayer2)
        {
            return true;
        }

        public FootballPlayer[] ReceiveAll() => _context.Deserialize(_pathes[typeof(FootballPlayer)]).ToArray<FootballPlayer>();

        private object[] Delete(IFieldComparable[] from, FieldCollection parameters)
        {
            List<object> newEntities = new List<object>();

            foreach (var entity in from)
                if (entity.IsMatch(parameters) == false)
                    newEntities.Add(entity);

            return newEntities.ToArray();
        }

        public void DeleteDoctors()
        {
            throw new NotImplementedException();
        }

        private T FindFirst<T>(IFieldComparable[] from, FieldCollection parameters) where T : IFieldComparable
        { 
            foreach (var entity in from)
                if (entity.IsMatch(parameters))
                    return (T)entity;

            return default;
        }

        private void Change(in IChangeable initializable, FieldCollection parameters)
        {
            initializable.Change(parameters);
        }

        private bool CanBeChaged(FootballPlayer footballPlayer)
        {
            // TODO проверить нет ли записае, если есть то данные нельзя поменять 
            //throw new NotImplementedException();

            return true;
        }
    }
}
