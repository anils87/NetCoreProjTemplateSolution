using Microsoft.Extensions.DependencyInjection;
using ProjTemplateCommon.BaseClasses;
using ProjTemplateCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection RegisterFromAssemblies(this IServiceCollection services, InjectionLifetime injectionLifetime, params Assembly[] assemblies)
        {
            List<Type> baseTypes = (from x in assemblies.SelectMany((Assembly x) => x.GetTypes()).ToList()
                                    where x.IsInterface
                                    select x
                                    ).ToList();
            return services.RegisterFromAssemblies(injectionLifetime, assemblies, baseTypes);
        }
        public static IServiceCollection RegisterFromAssemblies<TBase>(this IServiceCollection services, InjectionLifetime injectionLifetime, params Assembly[] assemblies)
        {
            return services.RegisterFromAssemblies(injectionLifetime, assemblies, new List<Type> { typeof(TBase) });
        }
        public static IServiceCollection RegisterFromAssemblies(this IServiceCollection services,InjectionLifetime injectionLifetime, IEnumerable<Assembly> assemblies,IEnumerable<Type> baseTypes)
        {
            if (assemblies == null)
                throw new ArgumentNullException("assemblies");

            if ( baseTypes == null)
                throw new ArgumentNullException("baseTypes");
            

            List<Type> source = (from x in assemblies.SelectMany((Assembly x) => x.GetTypes()).ToList()
                                 where x.IsClass && !x.IsAbstract
                                 select x).ToList();
            foreach(Type interfaceType in baseTypes.Where((Type x)=>x.IsInterface).ToList())
            {
                foreach(Type item in source.Where((Type x) => x.GetInterfaces().Any((Type y)=>y == interfaceType)))
                {
                    if(item.GetCustomAttribute<InjectibleAttribute>() != null)
                    {
                        switch (injectionLifetime)
                        {
                            case InjectionLifetime.Singleton:
                                services.AddSingleton(interfaceType,item);
                                break;
                            case InjectionLifetime.Scoped:
                                services.AddScoped(interfaceType,item);
                                break;
                            default:
                                services.AddTransient(interfaceType, item);
                                break;
                        }
                    }
                }
            }                               

            return services;
        }
        

    }
}
