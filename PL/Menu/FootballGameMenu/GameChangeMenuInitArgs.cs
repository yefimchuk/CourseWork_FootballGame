
using BLL;

namespace PL
{
    class GameChangeMenuInitArgs : GameRegistryMenuInitArgs
    {
        public readonly FieldCollection fields;

        public GameChangeMenuInitArgs(IGameService service, FieldCollection fields)
            : base(service)
        {
            this.fields = fields;
        }
    }
}
