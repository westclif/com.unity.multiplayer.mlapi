﻿using System;

namespace MLAPI.Internal
{
    internal static class TypeExtensions
    {
        internal static bool HasInterface(this Type type, Type interfaceType)
        {
            Type[] interfaces = type.GetInterfaces();
            for (int i = 0; i < interfaces.Length; i++)
            {
                if (interfaces[i] == interfaceType)
                    return true;
            }
            return false;
        }
        
        internal static bool IsNullable<T>(this T obj)
        {
            if (obj == null) return true;
            
            return typeof(T).IsNullable();
        }

        internal static bool IsNullable(this Type type)
        {
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }
    }
}
