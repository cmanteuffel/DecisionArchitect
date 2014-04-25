/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
*/

using System;
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

        public static EANativeType Translate(ObjectType nativeOt)
        {
            switch (nativeOt)
            {
                case ObjectType.otElement:
                    return EANativeType.Element;
                case ObjectType.otConnector:
                    return EANativeType.Connector;
                case ObjectType.otDiagram:
                    return EANativeType.Diagram;
                case ObjectType.otPackage:
                    return EANativeType.Package;
                case ObjectType.otRepository:
                    return EANativeType.Repository;
                case ObjectType.otNone:
                    //FIX: model returns for some reason otNone, translated to otModel. Might cause problems. 
                    return EANativeType.Model;
                default:
                    //MessageBox.Show("" + nativeOt);
                    return EANativeType.Unspecified;
            }
        }
    }
}