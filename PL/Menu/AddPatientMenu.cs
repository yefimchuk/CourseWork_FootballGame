using System;
using BLL;

namespace PL
{
    public class AddPatientMenu : InitializationMenu
    {
        private IPatientService _service;

        protected override void Init(MenuInitArgs initArgs)
        {
            base.Init(initArgs);

            if (initArgs is PatientRegistryMenuInitArgs)
            {
                var args = (PatientRegistryMenuInitArgs)initArgs;
                _service = args.service;
            }
        }

        protected override void SetupViewQueue()
        {
            AddView("========== Add ==========");
            AddView("Name: ", true);
            AddView("Surname: ", true);
            AddView("Age: ", true);
        }

        protected override void OnInputFilled(string[] inputs)
        {
            FieldInitializer parameters = new FieldInitializer(3);

            parameters.Add("Name", inputs[0]);
            parameters.Add("Surname", inputs[1]);
            parameters.Add("Age", Convert.ToInt32(inputs[2]));
/*
            _service.Add<Patient>(parameters);*/
        }
    }
}
