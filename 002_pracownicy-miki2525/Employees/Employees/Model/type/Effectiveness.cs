using System.ComponentModel;

namespace Employees.type
{
    public enum Effectiveness
    {
        [Description("NISKA")]
        NISKA = 60,
        [Description("ŚREDNIA")]
        ŚREDNIA = 90,
        [Description("WYSOKA")]
        WYSOKA = 120
    }

    static class EffectivenessMethods
    {

        public static int GetEffectivenessValue(this Effectiveness e)
        {
            switch (e)
            {
                case Effectiveness.NISKA:
                    return 60;
                case Effectiveness.ŚREDNIA:
                    return 90;
                case Effectiveness.WYSOKA:
                    return 120;
                default: 
                    return 0;
            }
        }
    }
}
