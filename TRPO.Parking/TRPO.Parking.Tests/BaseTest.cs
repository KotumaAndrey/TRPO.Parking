using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TRPO.Parking.Logic.Implementations;
using TRPO.Parking.Repositories.Implementations;

namespace TRPO.Parking.Tests
{
    public abstract class BaseTest
    {
        protected ContainerBuilder autofacContainerBuilder;
        protected IContainer autofacContainer;

        [TestInitialize]
        public void Initialize()
        {
            InitAutofacContainerBuilder();
            InitAutofacContainer();
        }

        protected void InitAutofacContainerBuilder()
        {
            autofacContainerBuilder = new ContainerBuilder();
            autofacContainerBuilder.RegisterRepositories();
            autofacContainerBuilder.RegisterLogics();
        }

        protected void InitAutofacContainer()
        {
            autofacContainer = autofacContainerBuilder.Build();
        }

        protected void RegisterType<TImplementation, TInterface>()
        {
            autofacContainerBuilder.RegisterType<TImplementation>().As<TInterface>();
        }

        protected Mock<T> RegisterMock<T>() where T : class
        {
            var mock = new Mock<T>();
            autofacContainerBuilder.RegisterInstance(mock.Object).As<T>();
            return mock;
        }
    }
}
