/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
*/

using System;
using System.ComponentModel;
using EAFacade;
using EAFacade.Model;

namespace DecisionArchitect.Model
{
    public interface IStakeholder : IPersistableModel, INotifyPropertyChanged
    {
        string Name { get; set; }
        string Role { get; set; }
        string GUID { get; }
    }

    public class Stakeholder : Entity, IStakeholder
    {
        private string _name;
        private string _role;

        private Stakeholder()
        {
        }

        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, "Name"); }
        }

        public string Role
        {
            get { return _role; }
            set { SetField(ref _role, value, "Role"); }
        }

        public string GUID { get; private set; }

        public bool Changed { get; private set; }

        public bool SaveChanges()
        {
            if (null == GUID && "".Equals(GUID)) throw new Exception();

            IEAElement element = EAMain.Repository.GetElementByGUID(GUID);
            element.Name = Name;
            element.Stereotype = Role;
            element.Update();
            EAMain.Repository.AdviseElementChanged(element.ID);
            return true;
        }

        public void DiscardChanges()
        {
            if (null == GUID && "".Equals(GUID)) return;

            IEAElement element = EAMain.Repository.GetElementByGUID(GUID);
            Name = element.Name;
            Role = element.Stereotype;
        }

        public static IStakeholder Load(IEAElement element)
        {
            if (null == element || !EAMain.IsStakeholder(element))
            {
                throw new ArgumentException("Argument null or not a stakeholder");
            }
            var stakeholder = new Stakeholder {Name = element.Name, Role = element.Stereotype, GUID = element.GUID};
            return stakeholder;
        }
    }
}