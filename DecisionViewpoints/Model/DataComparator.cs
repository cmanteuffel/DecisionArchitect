using System;
using System.Globalization;
using EAFacade;
using EAFacade.Model;

namespace DecisionViewpoints.Model
{
    public class DataComparator
    {
        public static int CompareByStateDateModified(IEAElement x, IEAElement y)
        {
            string oldestDateString = DateTime.MinValue.ToString(CultureInfo.InvariantCulture);
            string xDateString = x.GetTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate) ?? oldestDateString;
            string yDateString = y.GetTaggedValue(EATaggedValueKeys.DecisionStateModifiedDate) ?? oldestDateString;

            DateTime xModified = Utilities.TryParseDateTime(xDateString, DateTime.MinValue);
            DateTime yModified = Utilities.TryParseDateTime(yDateString, DateTime.MinValue);
            return DateTime.Compare(xModified, yModified);
        }
    }
}