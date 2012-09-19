// -----------------------------------------------------------------------
// <copyright file="CustomSerializationBinder.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace IronFoundry.Utilities
{
    public class CustomSerializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            ResolveEventHandler handler = new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            AppDomain.CurrentDomain.AssemblyResolve += handler;

            Type returnedType;
            try
            {
                AssemblyName asmName = new AssemblyName(assemblyName);
                var assembly = Assembly.Load(asmName);
                returnedType = assembly.GetType(typeName);
            }
            catch
            {
                returnedType = null;
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= handler;
            }

            return returnedType;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string truncatedAssemblyName = args.Name.Split(',')[0];
            Assembly assembly = Assembly.Load(truncatedAssemblyName);
            return assembly;
        }
    }
}
