using BLL;

namespace PL
{
    class InputParametersInitArgs : MenuInitArgs
    {
        public readonly FieldCollection[] fields;

        public InputParametersInitArgs(params FieldCollection[] fields)
        {
            this.fields = fields;
        }
    }
}
