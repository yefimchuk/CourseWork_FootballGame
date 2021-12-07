
    using BLL;

namespace PL
{
    class FootballPlayerChangeMenuInitArgs : DoctorRegistryMenuInitArgs
    {
        public readonly FieldCollection fields;

        public FootballPlayerChangeMenuInitArgs(IFootBallService service, FieldCollection fields)
            : base(service)
        {
            this.fields = fields;
        }
    }
}
