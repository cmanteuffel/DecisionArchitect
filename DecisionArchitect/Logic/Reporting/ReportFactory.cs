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

using System.IO;

namespace DecisionArchitect.Logic.Reporting
{
    public enum ReportType
    {
        Word,
        Excel,
        PowerPoint
    }

    public static class ReportFactory
    {
        public static IReportDocument Create(ReportType type, string filename)
        {
            IReportDocument reportDocument = null;
            try
            {
                switch (type)
                {
                    case ReportType.Word:
                        reportDocument = new WordDocument(filename);
                        break;
                    case ReportType.Excel:
                        reportDocument = new ExcelDocument(filename);
                        break;
                    case ReportType.PowerPoint:
                        reportDocument = new PowerPointDocument(filename);
                        break;
                }
            }
            catch (IOException)
            {
                return null;
            }
            return reportDocument;
        }
    }
}