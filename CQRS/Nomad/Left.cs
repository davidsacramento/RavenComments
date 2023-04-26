using System;

namespace Backend.Challenge.CQRS.Nomad
{
    public class Left<TLeft, TRight> : Either<TLeft, TRight> where TLeft : IAmAnError
    {
        public TLeft Value { get; }

        public Left(TLeft value)
        {
            Value = value;
        }

        public override Either<TNewLeft, TRight> MapLeft<TNewLeft>(Func<TLeft, TNewLeft> mapping) => new Left<TNewLeft, TRight>(mapping(Value));

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> mapping) => new Left<TLeft, TNewRight>(Value);

        public override TRight Reduce(Func<Either<TLeft, TRight>, TRight> reducer) => reducer(this);
        public override TLeft? GetLeft() => Value;

        public override TRight? GetRight() => default;

        public static implicit operator TLeft(Left<TLeft, TRight> obj) => obj.Value;
    }
}