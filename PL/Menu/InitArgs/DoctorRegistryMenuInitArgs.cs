using BLL;

namespace PL
{
    public class DoctorRegistryMenuInitArgs : MenuInitArgs
    {
        public readonly IDoctorService service;

        public DoctorRegistryMenuInitArgs(IDoctorService service) => this.service = service;
    }
}
