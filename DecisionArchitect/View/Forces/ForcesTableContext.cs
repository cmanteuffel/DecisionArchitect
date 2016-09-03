/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mark Hoekstra (University of Groningen)
*/

namespace DecisionArchitect.View.Forces
{
    public static class ForcesTableContext
    {
        public const string EmptyCellValue = "-";

        public const int ForceGUIDColumnIndex = 0;
        public const int ConcernColumnIndex = 1;
        public const int ConcernGUIDColumnIndex = 2;
        public const int DecisionColumnIndex = 3;

        public const string ConcernHeader = "Concern";
        public const string ConcernGUIDHeader = "ConcernGUID";
        public const string ForceGUIDHeader = "ForceGUID";
        public const string DecisionGUIDHeader = "DecisionGUID";
    }
}