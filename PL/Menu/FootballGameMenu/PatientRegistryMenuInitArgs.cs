using BLL;

namespace PL
{
    public class PatientRegistryMenuInitArgs : MenuInitArgs
    {
        public readonly IGameService service;

        public PatientRegistryMenuInitArgs(IGameService service) => this.service = service;
    }
}
