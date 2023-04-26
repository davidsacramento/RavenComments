using System;

namespace Backend.Challenge.CQRS.Nomad
{

    public class Right<TLeft, TRight> : Either<TLeft, TRight> where TLeft : IAmAnError
    {
        public TRight Value { get; }

        public Right(TRight value)
        {
            Value = value;
        }

        public override Either<TNewLeft, TRight> MapLeft<TNewLeft>(Func<TLeft, TNewLeft> mapping) => new Right<TNewLeft, TRight>(Value);

        public override Either<TLeft, TNewRight> MapRight<TNewRight>(Func<TRight, TNewRight> mapping) => new Right<TLeft, TNewRight>(mapping(Value));

        public override TRight Reduce(Func<Either<TLeft, TRight>, TRight> reducer) => Value;
        public override TLeft? GetLeft() => default;

        public override TRight? GetRight() => Value;

        public static implicit operator TRight(Right<TLeft, TRight> obj) => obj.Value;
    }
}