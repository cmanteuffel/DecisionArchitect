/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Mathieu Kalksma (University of Groningen)
*/

namespace EAFacade.Model
{
    public interface IEAFile
    {
        string FileDate { get; set; }
        string Notes { get; set; }
        string Size { get; set; }
        string Type { get; set; }
        string FullPath { get; set; }
    }
}