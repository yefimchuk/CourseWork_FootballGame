using BLL;

namespace PL
{
    class FindedPlayerShowMenu : ShowMenu
    {
        private FieldCollection _findedDoctorFields;

        protected override void Init(MenuInitArgs initArgs)
        {
            if (initArgs is InputParametersInitArgs args)
                _findedDoctorFields = args.fields[0];
        }

        protected override void InitDemonstrationObjects(ref IDemonstrated[] objects)
        {
            objects = Registry.Find<FootballPlayer>(_findedDoctorFields);
        }
    }
}
