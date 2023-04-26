using System;
using System.Collections.Generic;

namespace Backend.Challenge.CQRS
{

    /// <summary>
    ///     Implement me please
    /// </summary>
    public interface IResolver
    {
        /// <summary>
        ///     Resolves exactly 1 object of the type. Throws an exception if none or more than one are found.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        ///     Resolves exactly one or no objects of the type. Does not throw an exception if no objects are found.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object? ResolveOptional(Type type);

        /// <summary>
        ///     Resolves all objects of the type. Will return empty IEnumerable if none are found.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<object> ResolveMany(Type type);
    }
}