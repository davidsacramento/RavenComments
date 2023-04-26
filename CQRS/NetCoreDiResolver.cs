using System;
using System.Collections.Generic;

namespace Backend.Challenge.CQRS
{
    public class NetCoreDiResolver : IResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public NetCoreDiResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetObjectOfType(Type type)
        {
            return ResolveOptional(type) ?? throw new NotImplementedException($"Could not resolve type {type.Name}");
        }

        public IEnumerable<object> GetObjectsOfType(Type type)
        {
            var generic = typeof(IEnumerable<>);
            Type[] extra = { type };
            var resolveMe = generic.MakeGenericType(extra);

            var results = (IEnumerable<object>?)_serviceProvider.GetService(resolveMe);
            return results ?? Array.Empty<object>();
        }

        public object? ResolveOptional(Type type) => _serviceProvider.GetService(type);

        public object Resolve(Type type) => GetObjectOfType(type);

        public IEnumerable<object> ResolveMany(Type type) => GetObjectsOfType(type);
    }
}
