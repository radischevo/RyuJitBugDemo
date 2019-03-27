using System.Collections;
using System.Collections.Generic;

namespace SharedTypes
{
    public struct Option : IEnumerable<Item>
    {
        private readonly Item _value;
        private readonly bool _hasValue;

        public Option(Item value)
        {
            _value = value;
            _hasValue = value != null;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            if (_hasValue)
            {
                yield return _value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
