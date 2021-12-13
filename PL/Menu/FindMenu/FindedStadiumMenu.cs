using BLL;

namespace PL
{
    class FindedStadiumMenu : ShowMenu
    {
        private FieldCollection _findedPatientFields;

        protected override void Init(MenuInitArgs initArgs)
        {
            if (initArgs is InputParametersInitArgs args)
                _findedPatientFields = args.fields[0];
        }

        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects)
        {
            objects = Registry.Find<FootballStadium>(_findedPatientFields);
        }
    }
}

