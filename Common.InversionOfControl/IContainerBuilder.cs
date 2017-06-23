using System;

namespace Common.InversionOfControl
{
    public interface IContainerBuilder
    {
        IDisposableContainer Build();

        IContainerBuilder RegisterSingleton<T>(T instance) where T : class;
        IContainerBuilder RegisterSingleton<T>(T instance, string name) where T : class;
        IContainerBuilder Register<T>() where T : class;
        IContainerBuilder Register<T>(string name) where T : class;
        IContainerBuilder Register<T>(Scope scope) where T : class;
        IContainerBuilder Register<T>(string name, Scope scope) where T : class;

        IContainerBuilder Register<TInterface, TImplementation>() where TInterface : class where TImplementation : class, TInterface;
        IContainerBuilder Register<TInterface, TImplementation>(string name) where TInterface : class where TImplementation : class, TInterface;
        IContainerBuilder Register<TInterface, TImplementation>(Scope scope) where TInterface : class where TImplementation : class, TInterface;
        IContainerBuilder Register<TInterface, TImplementation>(string name, Scope scope) where TInterface : class where TImplementation : class, TInterface;

        IContainerBuilder Register<T>(Func<IContainerIOC, T> factory) where T : class;
        IContainerBuilder Register<T>(Func<IContainerIOC, T> factory, string name) where T : class;
        IContainerBuilder Register<T>(Func<IContainerIOC, T> factory, Scope scope) where T : class;
        IContainerBuilder Register<T>(Func<IContainerIOC, T> factory, string name, Scope scope) where T : class;

        T Resolve<T>() where T : class;

        IContainerBuilder RegisterInstance<TInterface>(TInterface instance) where TInterface : class;

        IContainerBuilder RegisterGeneric(Type t1, Type t2);

        //IContainerBuilder GetContainerBuilder();
    }

    public enum Scope
    {
        Singleton,
        Transient
    }
}