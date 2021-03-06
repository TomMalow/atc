﻿using System;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AutoRegistrateServices(
            this IServiceCollection services,
            Assembly interfaceAssembly,
            Assembly implementationAssembly)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (interfaceAssembly == null)
            {
                throw new ArgumentNullException(nameof(interfaceAssembly));
            }

            if (implementationAssembly == null)
            {
                throw new ArgumentNullException(nameof(implementationAssembly));
            }

            var implementationInterfaces = interfaceAssembly
                .DefinedTypes
                .Where(x => x.IsInterface)
                .ToArray();

            var implementationTypes = implementationAssembly
                .DefinedTypes
                .ToArray();

            foreach (var implementationInterface in implementationInterfaces)
            {
                foreach (var implementationType in implementationTypes)
                {
                    if (implementationType
                        .GetInterfaces()
                        .FirstOrDefault(x => x.FullName == implementationInterface.FullName) == null)
                    {
                        continue;
                    }

                    if (!IsImplementationTypeRegistered(services, implementationType))
                    {
                        services.AddTransient(implementationInterface, implementationType);
                    }

                    break;
                }
            }
        }

        public static void ValidateServiceRegistrations(
            this IServiceCollection services,
            Assembly apiAssembly)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (apiAssembly == null)
            {
                throw new ArgumentNullException(nameof(apiAssembly));
            }

            var notRegistered = apiAssembly
                .DefinedTypes
                .Where(x => x.IsInterface)
                .Where(typeInfo => services
                    .All(x => x.ServiceType != typeInfo))
                .ToList();

            if (notRegistered.Count <= 0)
            {
                return;
            }

            var missingRegistrations = notRegistered.Select(typeInfo => typeInfo.Name).ToArray();
            throw new ItemNotFoundException($"Missing registrations for {apiAssembly.GetName().Name}: {string.Join(", ", missingRegistrations)}");
        }

        private static bool IsImplementationTypeRegistered(IServiceCollection services, Type type)
        {
            return services.Any(item => item.ImplementationType == type);
        }
    }
}