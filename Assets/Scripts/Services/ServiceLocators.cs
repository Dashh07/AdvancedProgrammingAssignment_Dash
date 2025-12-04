using System;
using System.Collections.Generic;

public class ServiceLocators
{
    private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    public void Register<T>(T service)
    {
        services[typeof(T)] = service;
    }

    public T Get<T>()
    {
        if (services.TryGetValue(typeof(T), out var service))
            return (T)service;

        throw new Exception($"Service of type {typeof(T)} not registered.");
    }
}
