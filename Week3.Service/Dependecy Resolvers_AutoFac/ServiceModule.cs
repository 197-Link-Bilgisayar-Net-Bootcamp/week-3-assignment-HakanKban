using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Week3.Data.Abstract;
using Week3.Data.Concrete;
using Week3.Data.Context;
using Module = Autofac.Module;

namespace Week3.Service.Dependecy_Resolvers_AutoFac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var serviceAsembly = Assembly.GetExecutingAssembly(); // bulunduğumuz asemmbyl iyi aldık.
            var dataAsembly = Assembly.GetAssembly(typeof(MyContext)); // Data katmanının assembyl ini aldık.

            // bulundukları asembly i işaret ederek oradaki interface ve sınıflarım
            // arasında dependecy ınjectionu tek seferde endwith metodu ile sağlıyorum.
            builder.RegisterAssemblyTypes(serviceAsembly,dataAsembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(serviceAsembly,dataAsembly).Where(x => x.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope(); 
          

        }
    }
}
