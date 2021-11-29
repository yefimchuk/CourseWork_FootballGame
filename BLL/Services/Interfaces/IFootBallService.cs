
namespace BLL
{
    public interface IFootBallService : IService
    {
        void Change(FieldCollection doctorFields, FieldCollection newFields);
        FootballPlayer[] ReceiveAll();
    }
}
