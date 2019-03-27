using System;
using System.Collections;
using System.Collections.Generic;

namespace SharedTypes
{
    public struct Option<TValue> : IEquatable<Option<TValue>>, IEnumerable<TValue>
    {
        private static readonly EqualityComparer<TValue> _equalityComparer = EqualityComparer<TValue>.Default;

        private readonly TValue _value;
        private readonly bool _some;

        public Option(TValue value)
        {
            _value = value;
            _some = !Check<TValue>.IsNull(value);
        }

        public static implicit operator Option<TValue>(TValue value)
            => new Option<TValue>(value);

        public static explicit operator TValue(Option<TValue> value)
        {
            if (value._some)
            {
                return value._value;
            }

            throw new InvalidOperationException("Optional objects must have a value.");
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return !_some;
            }

            if (obj is Option<TValue>)
            {
                return Equals((Option<TValue>)obj);
            }

            return false;
        }

        public override int GetHashCode()
            => _some ? _equalityComparer.GetHashCode(_value) : -1;

        public bool Equals(Option<TValue> other)
        {
            var equals = _some
                ? other._some && _equalityComparer.Equals(_value, other._value)
                : !other._some;

            return equals;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            if (_some)
            {
                yield return _value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
