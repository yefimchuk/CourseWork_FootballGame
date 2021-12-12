
namespace BLL
{
    public interface IStadiumService : IService
    {
        void ChangeStadium(FieldCollection doctorFields, FieldCollection newFields);
    }
}
