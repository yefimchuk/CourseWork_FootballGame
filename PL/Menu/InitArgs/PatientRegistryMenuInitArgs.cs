using BLL;

namespace PL
{
    class PatientRegistryMenuInitArgs : MenuInitArgs
    {
        public readonly IPatientService service;

        public PatientRegistryMenuInitArgs(IPatientService service) => this.service = service;
    }
}
