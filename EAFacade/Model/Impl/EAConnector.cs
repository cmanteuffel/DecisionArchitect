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

using EA;

namespace EAFacade.Model.Impl
{
    internal sealed class EAConnector : IEAConnector
    {
        private readonly Connector _native;

        private EAConnector(Connector native)
        {
            _native = native;
        }

        public string Type
        {
            get { return _native.Type; }
            set { _native.Type = value; }
        }

        public string Stereotype
        {
            get { return _native.Stereotype; }
            set { _native.Stereotype = value; }
        }

        public int SupplierId
        {
            get { return _native.SupplierID; }
        }

        public int ClientId
        {
            get { return _native.ClientID; }
        }

        public string MetaType
        {
            get { return _native.MetaType; }
            set { _native.MetaType = value; }
        }

        public string GUID
        {
            get { return _native.ConnectorGUID; }
        }

        public int ID
        {
            get { return _native.ConnectorID; }
        }


        public EANativeType EANativeType
        {
            get { return EANativeType.Connector; }
        }

        public string Name
        {
            get { return _native.Name; }
            set { _native.Name = value; }
        }

        public string Notes
        {
            get { return _native.Notes; }
            set { _native.Notes = value; }
        }

        internal static IEAConnector Wrap(Connector native)
        {
            return new EAConnector(native);
        }

        public IEAElement GetSupplier()
        {
            return EARepository.Instance.GetElementByID(_native.SupplierID);
        }

        public IEAElement GetClient()
        {
            return EARepository.Instance.GetElementByID(_native.ClientID);
        }

        public IEADiagram GetDiagram()
        {
            IEADiagram diagram = null;
            if (_native.DiagramID > 0)
                diagram = EARepository.Instance.GetDiagramByID(_native.DiagramID);
            return diagram;
        }

        public bool IsRelationship()
        {
            return EAConstants.RelationMetaType.Equals(MetaType);
        }

        public bool IsAction()
        {
            return EAConstants.ActionMetaType.Equals(MetaType);
        }
    }
}
