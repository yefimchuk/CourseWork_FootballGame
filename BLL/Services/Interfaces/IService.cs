
namespace BLL
{
    public interface IService
    {

        void Add<T>(FieldInitializer parameters) where T : IInitializable;
        void Delete<T>(T entity);
    }
}
