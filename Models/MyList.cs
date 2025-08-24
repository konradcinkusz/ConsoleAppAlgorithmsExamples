using System.Collections;

namespace ConsoleAppAlgorithmsExamples.Models;

/// <summary>
/// A minimal dynamic array similar to List<T>, backed by T[].
/// </summary>
public class MyList<T> : IList<T>, IReadOnlyList<T>
{
    private const int DefaultCapacity = 4;

    private T[] _items;
    private int _count;
    private int _version; // used to detect modifications during enumeration

    public MyList()
    {
        _items = Array.Empty<T>();
    }

    public MyList(int capacity)
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        _items = capacity == 0 ? Array.Empty<T>() : new T[capacity];
    }

    /// <summary>Number of elements actually contained.</summary>
    public int Count => _count;

    /// <summary>Current array length (auto-grows). You can also shrink/grow manually.</summary>
    public int Capacity
    {
        get => _items.Length;
        set
        {
            if (value < _count) throw new ArgumentOutOfRangeException(nameof(value), "Capacity must be >= Count.");
            if (value == _items.Length) return;
            if (value == 0)
            {
                _items = Array.Empty<T>();
                return;
            }
            var newArr = new T[value];
            if (_count > 0) Array.Copy(_items, 0, newArr, 0, _count);
            _items = newArr;
        }
    }

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            if ((uint)index >= (uint)_count) throw new ArgumentOutOfRangeException(nameof(index));
            return _items[index];
        }
        set
        {
            if ((uint)index >= (uint)_count) throw new ArgumentOutOfRangeException(nameof(index));
            _items[index] = value;
            _version++;
        }
    }

    public void Add(T item)
    {
        EnsureCapacity(_count + 1);
        _items[_count++] = item;
        _version++;
    }

    public void AddRange(IEnumerable<T> collection)
    {
        if (collection == null) throw new ArgumentNullException(nameof(collection));

        // Pre-grow if we can cheaply know the count
        if (collection is ICollection<T> coll)
        {
            EnsureCapacity(_count + coll.Count);
            foreach (var x in coll) _items[_count++] = x;
            _version++;
            return;
        }

        foreach (var x in collection)
        {
            Add(x); // uses EnsureCapacity incrementally
        }
    }

    public void Insert(int index, T item)
    {
        if ((uint)index > (uint)_count) throw new ArgumentOutOfRangeException(nameof(index));
        EnsureCapacity(_count + 1);
        if (index < _count)
        {
            Array.Copy(_items, index, _items, index + 1, _count - index);
        }
        _items[index] = item;
        _count++;
        _version++;
    }

    public bool Remove(T item)
    {
        int idx = IndexOf(item);
        if (idx >= 0)
        {
            RemoveAt(idx);
            return true;
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if ((uint)index >= (uint)_count) throw new ArgumentOutOfRangeException(nameof(index));
        _count--;
        if (index < _count)
        {
            Array.Copy(_items, index + 1, _items, index, _count - index);
        }
        _items[_count] = default!; // clear last slot
        _version++;
    }

    public void Clear()
    {
        if (_count > 0)
        {
            Array.Clear(_items, 0, _count);
            _count = 0;
            _version++;
        }
    }

    public int IndexOf(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        for (int i = 0; i < _count; i++)
        {
            if (comparer.Equals(_items[i], item)) return i;
        }
        return -1;
    }

    public bool Contains(T item) => IndexOf(item) >= 0;

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (arrayIndex + _count > array.Length) throw new ArgumentException("Destination array is not long enough.");
        Array.Copy(_items, 0, array, arrayIndex, _count);
    }

    public T[] ToArray()
    {
        if (_count == 0) return Array.Empty<T>();
        var arr = new T[_count];
        Array.Copy(_items, 0, arr, 0, _count);
        return arr;
    }

    /// <summary>Shrink capacity to fit Count (with a small 10% slack rule, like List.TrimExcess).</summary>
    public void TrimExcess()
    {
        int threshold = (int)(Capacity * 0.9);
        if (_count < threshold)
        {
            Capacity = _count;
        }
    }

    public Enumerator GetEnumerator() => new Enumerator(this);

    IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator(this);
    IEnumerator IEnumerable.GetEnumerator() => new Enumerator(this);

    private void EnsureCapacity(int min)
    {
        if (_items.Length >= min) return;
        int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
        if (newCapacity < min) newCapacity = min;
        // Optionally, cap to a max length here if you need to guard against huge arrays.
        Capacity = newCapacity;
    }

    /// <summary>
    /// Value-type enumerator to avoid allocations. Detects modifications via _version.
    /// </summary>
    public struct Enumerator : IEnumerator<T>
    {
        private readonly MyList<T> _list;
        private readonly int _version;
        private int _index;
        private T _current;

        internal Enumerator(MyList<T> list)
        {
            _list = list;
            _version = list._version;
            _index = 0;
            _current = default!;
        }

        public T Current => _current;
        object IEnumerator.Current => _current!;

        public bool MoveNext()
        {
            if (_version != _list._version)
                throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");

            if ((uint)_index < (uint)_list._count)
            {
                _current = _list._items[_index++];
                return true;
            }

            _index = _list._count + 1; // end
            _current = default!;
            return false;
        }

        public void Reset()
        {
            if (_version != _list._version)
                throw new InvalidOperationException("Collection was modified; enumeration operation may not execute.");
            _index = 0;
            _current = default!;
        }

        public void Dispose() { /* nothing to release */ }
    }
}