﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using NUnit.Framework;
using Repository.Context;
using Services;
using Infrastructure.Repository;
using Infrastructure.Models;
using Repository;
using System.Reflection;
using System.Data.Entity;
using Infrastructure.Service;
using Infrastructure.DbContext;

namespace Test
{
    [TestFixture]
    class ServiceTest
    {
        private ContainerBuilder _builder;
        private IContainer _container;
        private static IContainer Container { get; set; }

        [Test]
        public void RunTest()
        {
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterType(typeof(DataContext)).As(typeof(IContext)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>)).InstancePerLifetimeScope().InstancePerDependency();

            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>)).InstancePerLifetimeScope().InstancePerDependency();

            builder.RegisterType(typeof(UserService))
               .As(typeof(IUserService)).InstancePerLifetimeScope().InstancePerDependency();

            var container = builder.Build();

            IUserService dc = container.Resolve<IUserService>();
            Users u = new Users();
            u.Email = "d12";
            u.FirstName = "d12";
            u.LastName = "d12";
            u.UserName = "d21";
            u.Password = "d21";
           Roles r = new Roles();
            r.Name = "r1";
            u.Roles.Add(r);
            dc.RegisterUser(u);

        }


    }
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            

            builder.RegisterAssemblyTypes(Assembly.Load("Services"))

                           .Where(t => t.Name.EndsWith("Service"))

                           

                           .InstancePerLifetimeScope();

        }

    }

    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(DataContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
        }
    }

}
