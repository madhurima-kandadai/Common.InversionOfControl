using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Common.InversionOfControl.CastleWindsor
{
    public class WindsorContainerBuilder : IContainerBuilder
    {
        private readonly WindsorContainer _container;

        public WindsorContainerBuilder()
        {
            _container = new WindsorContainer();
        }

        public IDisposableContainer Build()
        {
            return new WindsorReadOnlyContainer(_container.Kernel);
        }

        public IWindsorContainer GetWindsorContainer()
        {
            return _container;
        }

        public IContainerBuilder RegisterSingleton<T>(T instance) where T : class
        {
            _container.Register(Component.For<T>().Instance(instance).LifestyleSingleton());
            return this;
        }

        public IContainerBuilder RegisterSingleton<T>(T instance, string name) where T : class
        {
            _container.Register(Component.For<T>().Instance(instance).LifestyleSingleton().Named(name));
            return this;
        }

        public IContainerBuilder Register<T>() where T : class
        {
            _container.Register(Component.For<T>().ImplementedBy<T>().LifestyleTransient());
            return this;
        }

        public IContainerBuilder Register<T>(string name) where T : class
        {
            _container.Register(Component.For<T>().ImplementedBy<T>().LifestyleTransient().Named(name));
            return this;
        }

        public IContainerBuilder Register<T>(Scope scope) where T : class
        {
            switch (scope)
            {
                case Scope.Singleton:
                    _container.Register(Component.For<T>().ImplementedBy<T>().LifestyleSingleton());
                    break;
                case Scope.Transient:
                    _container.Register(Component.For<T>().ImplementedBy<T>().LifestyleTransient());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }

        public IContainerBuilder Register<T>(string name, Scope scope) where T : class
        {
            switch (scope)
            {
                case Scope.Singleton:
                    _container.Register(Component.For<T>().ImplementedBy<T>().LifestyleSingleton().Named(name));
                    break;
                case Scope.Transient:
                    _container.Register(Component.For<T>().ImplementedBy<T>().LifestyleTransient().Named(name));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }

        public IContainerBuilder Register<TInterface, TImplementation>() where TInterface : class where TImplementation : class, TInterface
        {
            _container.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleTransient());
            return this;
        }

        public IContainerBuilder Register<TInterface, TImplementation>(string name) where TInterface : class where TImplementation : class, TInterface
        {
            _container.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleTransient().Named(name));
            return this;
        }

        public IContainerBuilder Register<TInterface, TImplementation>(Scope scope) where TInterface : class where TImplementation : class, TInterface
        {
            switch (scope)
            {
                case Scope.Singleton:
                    _container.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleSingleton());
                    break;
                case Scope.Transient:
                    _container.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleTransient());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }

        public IContainerBuilder Register<TInterface, TImplementation>(string name, Scope scope) where TInterface : class where TImplementation : class, TInterface
        {
            switch (scope)
            {
                case Scope.Singleton:
                    _container.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleSingleton().Named(name));
                    break;
                case Scope.Transient:
                    _container.Register(Component.For<TInterface>().ImplementedBy<TImplementation>().LifestyleTransient().Named(name));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }

        public IContainerBuilder Register<T>(Func<IContainerIOC, T> factory) where T : class
        {
            _container.Register(Component.For<T>().UsingFactoryMethod<T>(x => factory(new WindsorReadOnlyContainer(x))).LifestyleTransient());
            return this;
        }

        public IContainerBuilder Register<T>(Func<IContainerIOC, T> factory, string name) where T : class
        {
            _container.Register(Component.For<T>().UsingFactoryMethod<T>(x => factory(new WindsorReadOnlyContainer(x))).LifestyleTransient().Named(name));
            return this;
        }

        public IContainerBuilder Register<T>(Func<IContainerIOC, T> factory, Scope scope) where T : class
        {
            switch (scope)
            {
                case Scope.Singleton:
                    _container.Register(Component.For<T>().UsingFactoryMethod<T>(x => factory(new WindsorReadOnlyContainer(x))).LifestyleSingleton());
                    break;
                case Scope.Transient:
                    _container.Register(Component.For<T>().UsingFactoryMethod<T>(x => factory(new WindsorReadOnlyContainer(x))).LifestyleTransient());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }

        public IContainerBuilder Register<T>(Func<IContainerIOC, T> factory, string name, Scope scope) where T : class
        {
            switch (scope)
            {
                case Scope.Singleton:
                    _container.Register(Component.For<T>().UsingFactoryMethod<T>(x => factory(new WindsorReadOnlyContainer(x))).LifestyleSingleton().Named(name));
                    break;
                case Scope.Transient:
                    _container.Register(Component.For<T>().UsingFactoryMethod<T>(x => factory(new WindsorReadOnlyContainer(x))).LifestyleTransient().Named(name));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public IContainerBuilder RegisterInstance(Type t, object instance)
        {
            throw  new NotImplementedException();
        }

        public IContainerBuilder RegisterInstance<TInterface>(TInterface instance) where TInterface : class
        {
            _container.Register(Component.For<TInterface>().Instance(instance));
            return this;
        }
        public IContainerBuilder RegisterGeneric(Type t1, Type t2)
        {
            _container.Register(Component.For(t1, t2));
            return this;
        }
    }
}