using BLL;

namespace PL
{
    public class ShowFootballPlayerMenu : ShowMenu
    {
        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects)
        {
            objects = Registry.Load<FootballPlayer>();
        }
    }
}
