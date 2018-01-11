﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Mmu.Sms.Application.Infrastructure.Ioc.Handlers
{
    internal static class AssemblyHandler
    {
        internal static IReadOnlyCollection<Type> GetProfileTypes()
        {
            var assemblies = GetApplicationAssemblies();
            var profileType = typeof(Profile);
            var result = assemblies.SelectMany(f => f.GetTypes().Where(t => profileType.IsAssignableFrom(t))).ToList();
            return result;
        }

        private static IEnumerable<Assembly> GetApplicationAssemblies()
        {
            var filesInCurrentDirectory = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
            var assemblyFilePaths = filesInCurrentDirectory.Where(IsRelevantAssembly);

            var result = assemblyFilePaths.Select(Assembly.LoadFile).ToList();
            return result;
        }

        private static bool IsRelevantAssembly(string assemblyFilePath)
        {
            var result = Path.GetFileName(assemblyFilePath).ToUpperInvariant().StartsWith("MMU.SMS", StringComparison.OrdinalIgnoreCase);
            var fileExtensionLower = Path.GetExtension(assemblyFilePath).ToUpperInvariant();
            result = result && (fileExtensionLower == ".DLL" || fileExtensionLower == ".EXE");
            return result;
        }
    }
}