
using BLL;

namespace PL
{
    class StadiumChangeMenuInitArgs : StadiumRegistryMenuInitArgs
    {
        public readonly FieldCollection fields;

        public StadiumChangeMenuInitArgs(IStadiumService service, FieldCollection fields)
            : base(service)
        {
            this.fields = fields;
        }
    }
}
