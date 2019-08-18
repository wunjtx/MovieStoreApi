using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MovieStoreApi.Mvc.Infrastructure.IOC
{
    /// <summary>
    /// Resolves Dependencies Using Ninject
    /// </summary>
    public class NinjectResolver : IDependencyResolver
    {
        /// <summary>
        /// Represents the Core Kernel of the IOC Container
        /// </summary>
        public IKernel Kernel { get; private set; }

        /// <summary>
        /// Creates a new Instance of th Ninject Resolver with the modules Supplied
        /// </summary>
        /// <param name="modules">Modules to Load</param>
        public NinjectResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        /// <summary>
        /// Creates a new Instance of th Ninject Resolver by loading Modules
        /// from the Assembly Supplied
        /// </summary>
        /// <param name="assembly">Assembly to Load Modules</param>
        public NinjectResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        /// <summary>
        /// Creates an Instance of an Object based on the Type information Supplied
        /// </summary>
        /// <param name="serviceType">Type of Object to resolve</param>
        /// <returns>Instance of the Object</returns>
        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        /// <summary>
        /// Returns all the instance based on the bindings of that type
        /// </summary>
        /// <param name="serviceType">Type to create Instances of</param>
        /// <returns>Instances of the Objects based on the Bindings</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }
}