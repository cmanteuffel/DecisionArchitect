using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DecisionViewpoints.View
{
    public static class DecisionStateColor
    {
        enum States
        {
            IDEA,
            TENTATIVE,
            DECIDED,
            APPROVED,
            CHALLENGED,
            DISCARDED,
            REJECTED
        }


        public static Color ConvertStateToColor(string string_state)
        {
            States state = (States)Enum.Parse(typeof(States), string_state, true);
            return ConvertStateToColor(state);
            //Console.WriteLine("Today is a: " + c.ToString() + " And originaly a " + string_state);
            //return c;
        }

        private static Color ConvertStateToColor(States state)
        {
            switch (state)
            {
                case States.IDEA:
                    return Color.FromKnownColor(KnownColor.LightGoldenrodYellow);
                case States.TENTATIVE:
                    return Color.FromKnownColor(KnownColor.LightBlue);
                case States.DECIDED:
                    return Color.FromKnownColor(KnownColor.LightGreen);
                case States.APPROVED:
                    return Color.FromKnownColor(KnownColor.LawnGreen);
                case States.CHALLENGED:
                    return Color.FromKnownColor(KnownColor.IndianRed);
                case States.DISCARDED:
                    return Color.FromKnownColor(KnownColor.LightGray);
                default: // States.REJECTED:
                    return Color.FromKnownColor(KnownColor.DarkGray);
            }
        }
    }
}
