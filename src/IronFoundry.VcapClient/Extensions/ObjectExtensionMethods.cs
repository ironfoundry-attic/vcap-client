// -----------------------------------------------------------------------
// <copyright file="ObjectExtensionMethods.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace System
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using IronFoundry.Utilities;

    public static class ObjectExtensionMethods
    {
        public static T DeepCopy<T>(this T obj)
        {
            Object result = null;

            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Binder = new CustomSerializationBinder();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                result = (T)formatter.Deserialize(ms);
                ms.Close();
            }

            return (T)result;
        }        
    }
}
