using BLL;

namespace PL
{
    class GameMenuInitArg : MenuInitArgs
    {
        public readonly IGameService service;

        public GameMenuInitArg(IGameService service) => this.service = service;
    }
}
