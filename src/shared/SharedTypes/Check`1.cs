using System;

namespace SharedTypes
{
    internal static class Check<T>
    {
        private static readonly Func<T, bool> _isNull = CreateIsNullChecker();

        public static bool IsNull(T value)
        {
            var checker = _isNull;
            if (checker == null)
            {
                return false;
            }

            return checker(value);
        }

        private static Func<T, bool> CreateIsNullChecker()
        {
            var type = typeof(T);
            if (!type.IsValueType)
            {
                return value => value == null;
            }

            if (type.IsConstructedGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                if (genericType == typeof(Nullable<>))
                {
                    return value => value.Equals(null);
                }

            }

            return null;
        }
    }
}
