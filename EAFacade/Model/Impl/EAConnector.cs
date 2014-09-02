/*
 Copyright (c) 2014 ABB Group
 All rights reserved. This program and the accompanying materials
 are made available under the terms of the Eclipse Public License v1.0
 which accompanies this distribution, and is available at
 http://www.eclipse.org/legal/epl-v10.html
 
 Contributors:
    Christian Manteuffel (University of Groningen)
    Spyros Ioakeimidis (University of Groningen)
    Mark Hoekstra (University of Groningen)
*/

using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<IEAConnectorTag> TaggedValues
        {
            get
            {
                return _native.TaggedValues.Cast<ConnectorTag>()
                              .Select(EAConnectorTag.Wrap).ToList();
            }
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
            if (null == native)
            {
                throw new ArgumentNullException("native");
            }
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

        /// <summary>
        /// Implements IEAConnector.TaggedValueExists(string name)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool TaggedValueExists(string name)
        {
            return _native.TaggedValues.Cast<ConnectorTag>().Any(tv => tv.Name.Equals(name));
        }

        /// <summary>
        /// Implements IEAConnector.TaggedValueExists(string name, string data)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool TaggedValueExists(string name, string data)
        {
            return _native.TaggedValues.Cast<ConnectorTag>().Any(tv => tv.Name.Equals(name) && tv.Value.Equals(data));
        }

        public void AddTaggedValue(string name, string data)
        {
            ConnectorTag taggedValue = _native.TaggedValues.AddNew(name, "");
            taggedValue.Value = data;
            taggedValue.Update();
            _native.TaggedValues.Refresh();
            _native.Update();
        }

        /// <summary>
        /// Implements IEAConnector.RemoveTaggedValue(string name, string data)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public void RemoveTaggedValue(string name, string data)
        {
            for (short i = 0; i < TaggedValues.Count; i++)
            {
                IEAConnectorTag tv = TaggedValues[i];

                if (tv.Name.Equals(name) && tv.Value.Equals(data))
                {
                    _native.TaggedValues.Delete(i);
                    _native.TaggedValues.Refresh();
                    _native.Update();
                    return; // Only delete one ConnectorTag
                }
            }
        }
    }
}
