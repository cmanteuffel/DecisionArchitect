using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using EA;
using EAFacade.Model;

namespace EAFacade
{
    public class EAUtilities
    {
        public static int ParseToInt32(string value, int valueOnFailure)
        {
            int number;
            if (!Int32.TryParse(value, out number))
            {
                number = valueOnFailure;
            }
            return number;
        }

        public static long ParseToLong(string value, long valueOnFailure)
        {
            long number;
            if (!Int64.TryParse(value, out number))
            {
                number = valueOnFailure;
            }
            return number;
        }

        public static NativeType Translate(ObjectType nativeOt)
        {
            switch (nativeOt)
            {
                case ObjectType.otElement:
                    return NativeType.Element;
                case ObjectType.otConnector:
                    return NativeType.Connector;
                case ObjectType.otDiagram:
                    return NativeType.Diagram;
                case ObjectType.otPackage:
                    return NativeType.Package;
                case ObjectType.otRepository:
                    return NativeType.Repository;
                case ObjectType.otNone:
                    //FIX: model returns for some reason otNone, translated to otModel. Might cause problems. 
                    return NativeType.Model;
                default:
                    //MessageBox.Show("" + nativeOt);
                    return NativeType.Unspecified;
            }
        }
    }
}