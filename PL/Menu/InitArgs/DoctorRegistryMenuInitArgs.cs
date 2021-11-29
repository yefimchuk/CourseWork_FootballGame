using BLL;

namespace PL
{
    public class DoctorRegistryMenuInitArgs : MenuInitArgs
    {
        public readonly IFootBallService service;

        public DoctorRegistryMenuInitArgs(IFootBallService service) => this.service = service;
    }
}
