using BLL;

namespace PL
{
    public class ShowStadiumMenu : ShowMenu
    {
        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects)
        {
            objects = Registry.Load<FootballStadium>();
        }
    }
}

