using System;
using System.Globalization;
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

            DateTime xModified = DateTime.Parse(xDateString);
            DateTime yModified = DateTime.Parse(yDateString);
            return DateTime.Compare(xModified, yModified);
        }
    }
}