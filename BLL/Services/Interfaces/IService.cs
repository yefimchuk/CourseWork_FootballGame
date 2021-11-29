
namespace BLL
{
    public interface IService
    {
        void Add<T>(FieldCollection parameters) where T : IInitializable;
        void Delete<T>(FieldCollection parameters) where T : IFieldComparable;
    }
}
