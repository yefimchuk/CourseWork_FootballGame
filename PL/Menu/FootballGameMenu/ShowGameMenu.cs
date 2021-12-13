using BLL;

namespace PL
{
    public class ShowGameMenu : ShowMenu
    {
        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects)
        {
            objects = Registry.Load<FootballGame>();
        }
    }
}
