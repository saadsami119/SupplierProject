using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Builder;
using Infrastructure.DbContext;
using Infrastructure.Repository;
using System.Data.Entity;
using Repository;
using Services;
using Infrastructure.Service;
using Repository.Context;
namespace Web.Configurations
{
    public class AutofacConfiguration : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {   
           builder = new Autofac.ContainerBuilder();

           
            builder.RegisterType(typeof(DataContext)).As(typeof(IContext)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>)).InstancePerLifetimeScope().InstancePerDependency();

            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>)).InstancePerLifetimeScope().InstancePerDependency();

            builder.RegisterType(typeof(UserService))
               .As(typeof(IUserService)).InstancePerLifetimeScope().InstancePerDependency();
        }
    }
}