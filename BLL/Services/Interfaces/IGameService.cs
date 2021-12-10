
namespace BLL
{
    public interface IGameService : IService
    {
        void ChangeGames(FieldCollection doctorFields, FieldCollection newFields);
    }
}
