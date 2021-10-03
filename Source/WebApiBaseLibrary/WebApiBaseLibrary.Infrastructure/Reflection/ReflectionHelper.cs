﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WebApiBaseLibrary.Infrastructure.Reflection
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetAllTypesWithAttribute<TAttribute>()
            where TAttribute : Attribute
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes().Where(t => t.GetCustomAttribute<TAttribute>() != null);

            return types;
        }
    }
}