using BLL;

namespace PL
{
    public class FootballPlayerRegistryMenuInitArgs : MenuInitArgs
    {
        public readonly IFootBallService service;

        public FootballPlayerRegistryMenuInitArgs(IFootBallService service) => this.service = service;
    }
}
