﻿using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace OS.Common.Helper
{
    internal static class TypeHelper
    {

        private static ConcurrentDictionary<string, object[]> attrDirs = new ConcurrentDictionary<string, object[]>();

        public static object[] GetPropertiAttributes( string typeName, PropertyInfo fd, Type attributeType )
        {
            string key = string.Concat( typeName, fd.Name );
            object[] attrs;
            attrDirs.TryGetValue( key, out attrs );
            if (attrs != null)
            {
                return attrs;
            }
            attrs = fd.GetCustomAttributes( attributeType, true );
            attrDirs.TryAdd( key, attrs );
            return attrs;
        }

        private static ConcurrentDictionary<string, PropertyInfo[]> proDictionaries =
            new ConcurrentDictionary<string, PropertyInfo[]>();

        public static PropertyInfo[] GetProperties( Type type )
        {
            PropertyInfo[] properties;
            proDictionaries.TryGetValue( type.FullName, out properties );
            if (properties != null)
            {
                return properties;
            }
            properties = type.GetProperties( BindingFlags.Public | BindingFlags.Instance );
            proDictionaries.TryAdd( type.FullName, properties );
            return properties;
        }

    }
}
