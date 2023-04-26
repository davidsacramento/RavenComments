using System;

namespace Backend.Challenge.CQRS.Nomad
{
    public abstract class Either<TLeft, TRight> where TLeft : IAmAnError
    {
        /// <summary>
        /// Converts the left track to a new type
        /// </summary>
        /// <typeparam name="TNewLeft"></typeparam>
        /// <param name="mapping"></param>
        /// <returns></returns>
        public abstract Either<TNewLeft, TRight> MapLeft<TNewLeft>(Func<TLeft, TNewLeft> mapping) where TNewLeft : IAmAnError;

        /// <summary>
        /// Converts the right track to a new type
        /// </summary>
        /// <typeparam name="TNewRight"></typeparam>
        /// <param name="mapping"></param>
        /// <returns></returns>
        public abstract Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> mapping);

        /// <summary>
        /// Performs error handling using the left track as input and returns the right track
        /// </summary>
        /// <param name="reducer"></param>
        /// <returns></returns>
        public abstract TRight Reduce(Func<Either<TLeft, TRight>, TRight> reducer);

        public abstract TLeft? GetLeft();
        public abstract TRight? GetRight();

        public static implicit operator Either<TLeft, TRight>(TRight obj) => new Right<TLeft, TRight>(obj);
        public static implicit operator Either<TLeft, TRight>(TLeft obj) => new Left<TLeft, TRight>(obj);
    }
}