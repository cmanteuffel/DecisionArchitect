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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using DecisionArchitect.Logic;
using DecisionArchitect.Logic.EventHandler;
using DecisionArchitect.Utilities;
using EA;
using EAFacade;
using EAFacade.Events;
using log4net;
using log4net.Config;

namespace DecisionArchitect
{
    [ComVisible(true)]
    public partial class MainApplication : EAEventAdapter
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IList<IRepositoryListener> _listeners = new List<IRepositoryListener>();

        //init repository listener
        public MainApplication()
        {
            if (!LogManager.GetRepository().Configured)
            {
                // assume that logger.config is located in the assembly folder
                var configFile = new FileInfo(AssemblyDirectory + "\\logger.config");
                if (!configFile.Exists)
                {
                    throw new FileNotFoundException($"{configFile} could not be found");
                }
                XmlConfigurator.Configure(configFile);
            }

            Log.Info("Starting Decision Architect add-in");
            _listeners.Add(new DecisionStateChangeEventHandler());
            _listeners.Add(DetailViewHandler.Instance);
            _listeners.Add(new ValidationHandler());
            _listeners.Add(new ChronologicalViewpointHandler());
            _listeners.Add(new ForcesHandler());
            _listeners.Add(new StakeholderInvolvementHandler());
            _listeners.Add(SynchronizationManager.Instance);
        }

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase).Uri;
                var path = Uri.UnescapeDataString(uri.LocalPath);
                var assemblyDirectory = new DirectoryInfo(path).Parent?.FullName;
                return assemblyDirectory;
            }
        }

        public override object EA_OnInitializeTechnologies(Repository repository)
        {            
            EAMain.UpdateRepository(repository);
            const string resource = "DecisionArchitect." + "DecisionArchitectMDG.xml";
            Log.Debug($"Initialize MDG Technology {resource}");
            return Utils.GetResourceContents(resource);
        }

        public override string EA_OnRetrieveModelTemplate(Repository repository, string location)
        {
            EAMain.UpdateRepository(repository);
            var resource = "DecisionArchitect.Templates." + location;
            return Utils.GetResourceContents(resource);
        }
    }
}