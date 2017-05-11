
namespace RMS.Logging
{
    using System;
    using System.Collections;

    /// <summary>
    /// 一个强类型的IAppender<see cref="IAppender"/> 集合.
    /// </summary>
    public class AppenderCollection : ICollection, IList, IEnumerable, ICloneable
    {
        #region 支持类型安全的枚举器.

        /// <summary>
        /// 支持类型安全的枚举AppenderCollection<see cref="AppenderCollection"/>集合.
        /// </summary>
        /// <exclude/>
        public interface IAppenderCollectionEnumerator
        {
            /// <summary>
            /// 获取集合中的当前元素
            /// </summary>
            IAppender Current { get; }

            /// <summary>
            /// 取集合中的下一个元素.
            /// </summary>
            /// <returns>
            /// <c>true</c> 如果存在下一个元素. 
            /// <c>false</c>当前元素是最后一个元素.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            /// 集合元素被个性在枚举器创建后.
            /// </exception>
            bool MoveNext();

            /// <summary>
            /// 重置枚举器到初始位置.在集合中第一个元素之前.
            /// </summary>
            void Reset();
        }

        #endregion 支持类型安全的枚举器

        #region 常量

        private const int DEFAULT_CAPACITY = 16;

        #endregion 常量

        #region 私有字段(data)

        private IAppender[] m_array;
        private int m_count = 0;
        private int m_version = 0;

        #endregion

        #region 静态只读包装集合

        /// <summary>
        /// Creates a read-only wrapper for a <c>AppenderCollection</c> instance.
        /// </summary>
        /// <param name="list">list to create a readonly wrapper arround</param>
        /// <returns>
        /// An <c>AppenderCollection</c> wrapper that is read-only.
        /// </returns>
        public static AppenderCollection ReadOnly(AppenderCollection list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            return new ReadOnlyAppenderCollection(list);
        }

        #endregion 静态只读包装集合

        #region 静态包装字段

        /// <summary>
        /// An empty readonly static AppenderCollection
        /// </summary>
        public static readonly AppenderCollection EmptyCollection = ReadOnly(new AppenderCollection(0));

        #endregion 静态包装字段

        #region 构造函数

        /// <summary>
        /// 初始化默认容量的IAppender数组.
        /// </summary>
        public AppenderCollection()
        {
            m_array = new IAppender[DEFAULT_CAPACITY];
        }

        /// <summary>
        /// 初始化指定容量大小的IAppender数组.
        /// </summary>
        /// <param name="capacity"></param>
        public AppenderCollection(int capacity)
        {
            m_array = new IAppender[capacity];
        }

        /// <summary>
        /// 初始化IAppender数组,使用AppenderCollection集合.
        /// </summary>
        /// <param name="c"></param>
        public AppenderCollection(AppenderCollection c)
        {
            m_array = new IAppender[c.Count];
            AddRange(c);
        }

        /// <summary>
        /// 初始化IAppender数组,使用IAppender数组初始化.
        /// </summary>
        /// <param name="a"></param>
        public AppenderCollection(IAppender[] a)
        {
            m_array = new IAppender[a.Length];
            AddRange(a);
        }

        /// <summary>
        /// 初始化IAppender数组,使用IAppender集合接口初始化
        /// </summary>
        /// <param name="col"></param>
        public AppenderCollection(ICollection col)
        {
            m_array = new IAppender[col.Count];
            AddRange(col);
        }

        /// <summary>
        /// 仅仅对子类可见.
        /// 用于访问保护的构造函数.
        /// </summary>
        /// <exclude/>
        internal protected enum Tag
        {
            /// <summary>
            /// A value
            /// </summary>
            Default
        }

        /// <summary>
        /// 允许子类不实现默认构造函数
        /// </summary>
        /// <param name="tag"></param>
        /// <exclude/>
        internal protected AppenderCollection(Tag tag)
        {
            m_array = null;
        }

        #endregion 构造函数

        #region 操作实现(类型安全集合 ICollection)

        /// <summary>
        /// 获取<c>AppenderCollection</c>集合中实际包含的元素数量.
        /// </summary>
        public virtual int Count
        {
            get { return m_count; }
        }

        /// <summary>
        /// 复制整个集合<c>AppenderCollection</c>到一维元素数组.
        /// <see cref="IAppender"/>
        /// </summary>
        /// <param name="array">要复制的一维数组<see cref="IAppender"/>.</param>
        public virtual void CopyTo(IAppender[] array)
        {
            this.CopyTo(array, 0);
        }

        /// <summary>
        /// 复制整个集合<c>AppenderCollection</c>到一维元素数组,从目标数组中指定的位置.
        /// <see cref="IAppender"/>
        /// </summary>
        /// <param name="array">要复制的一维数组<see cref="IAppender"/>.</param>
        /// <param name="start">基于0的数组的开始位置.</param>
        public virtual void CopyTo(IAppender[] array, int start)
        {
            if (m_count > array.GetUpperBound(0) + 1 - start)
            {
                throw new System.ArgumentException("Destination array was not long enough.");
            }

            Array.Copy(m_array, 0, array, start, m_count);
        }

        /// <summary>
        /// 获取一个值，指出是否能访问是同步的(thread-safe).
        /// </summary>
        /// <returns>true if access to the ICollection is synchronized (thread-safe); otherwise, false.</returns>
        public virtual bool IsSynchronized
        {
            get { return m_array.IsSynchronized; }
        }

        /// <summary>
        /// 获取一个对象，能够被用来同步访问的集合.
        /// </summary>
        public virtual object SyncRoot
        {
            get { return m_array.SyncRoot; }
        }

        #endregion 操作实现(类型安全集合 ICollection)

        #region 操作实现(类型安全 IList)

        /// <summary>
        /// 获取或设置IAppender<see cref="IAppender"/> 在指定的位置.
        /// </summary>
        /// <param name="index">用来获取或设置基于0的索引</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///		<para><paramref name="index"/>小于0</para>
        ///		<para>或者</para>
        ///		<para><paramref name="index"/>大于或等于集合数量<see cref="AppenderCollection.Count"/>.</para>
        /// </exception>
        public virtual IAppender this[int index]
        {
            get
            {
                ValidateIndex(index); // throws
                return m_array[index];
            }
            set
            {
                ValidateIndex(index); // throws
                ++m_version;
                m_array[index] = value;
            }
        }

        /// <summary>
        /// 添加一个IAppender到AppenderCollection集合末尾.
        /// </summary>
        /// <param name="item">要添加到集合中的IAppender元素.</param>
        /// <returns>添加元素的索引</returns>
        public virtual int Add(IAppender item)
        {
            if (m_count == m_array.Length)
            {
                EnsureCapacity(m_count + 1);
            }

            m_array[m_count] = item;
            m_version++;

            return m_count++;
        }

        /// <summary>
        /// 删除集合 <c>AppenderCollection</c>中的所有元素
        /// </summary>
        public virtual void Clear()
        {
            ++m_version;
            m_array = new IAppender[DEFAULT_CAPACITY];
            m_count = 0;
        }

        /// <summary>
        /// 创建一个集合<see cref="AppenderCollection"/>的浅拷贝.
        /// </summary>
        /// <returns>一个新的集合来自<see cref="AppenderCollection"/>的浅拷贝.</returns>
        public virtual object Clone()
        {
            AppenderCollection newCol = new AppenderCollection(m_count);
            Array.Copy(m_array, 0, newCol.m_array, 0, m_count);
            newCol.m_count = m_count;
            newCol.m_version = m_version;

            return newCol;
        }

        /// <summary>
        /// 判断指定的元素<see cref="IAppender"/>是否在集合中<c>AppenderCollection</c>.
        /// </summary>
        /// <param name="item">要检查的元素.</param>
        /// <returns><c>true</c> 如果 <paramref name="item"/>元素找到在集合<c>AppenderCollection</c>中; 否则,<c>false</c>.</returns>
        public virtual bool Contains(IAppender item)
        {
            for (int i = 0; i != m_count; ++i)
            {
                if (m_array[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the zero-based index of the first occurrence of a <see cref="IAppender"/>
        /// in the <c>AppenderCollection</c>.
        /// </summary>
        /// <param name="item">The <see cref="IAppender"/> to locate in the <c>AppenderCollection</c>.</param>
        /// <returns>
        /// The zero-based index of the first occurrence of <paramref name="item"/> 
        /// in the entire <c>AppenderCollection</c>, if found; otherwise, -1.
        /// </returns>
        public virtual int IndexOf(IAppender item)
        {
            for (int i = 0; i != m_count; ++i)
            {
                if (m_array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Inserts an element into the <c>AppenderCollection</c> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The <see cref="IAppender"/> to insert.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="index"/> is less than zero</para>
        /// <para>-or-</para>
        /// <para><paramref name="index"/> is equal to or greater than <see cref="AppenderCollection.Count"/>.</para>
        /// </exception>
        public virtual void Insert(int index, IAppender item)
        {
            ValidateIndex(index, true); // throws

            if (m_count == m_array.Length)
            {
                EnsureCapacity(m_count + 1);
            }

            if (index < m_count)
            {
                Array.Copy(m_array, index, m_array, index + 1, m_count - index);
            }

            m_array[index] = item;
            m_count++;
            m_version++;
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="IAppender"/> from the <c>AppenderCollection</c>.
        /// </summary>
        /// <param name="item">The <see cref="IAppender"/> to remove from the <c>AppenderCollection</c>.</param>
        /// <exception cref="ArgumentException">
        /// The specified <see cref="IAppender"/> was not found in the <c>AppenderCollection</c>.
        /// </exception>
        public virtual void Remove(IAppender item)
        {
            int i = IndexOf(item);
            if (i < 0)
            {
                throw new ArgumentException("Cannot remove the specified item because it was not found in the specified Collection.");
            }

            ++m_version;
            RemoveAt(i);
        }

        /// <summary>
        /// Removes the element at the specified index of the <c>AppenderCollection</c>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="index"/> is less than zero</para>
        /// <para>-or-</para>
        /// <para><paramref name="index"/> is equal to or greater than <see cref="AppenderCollection.Count"/>.</para>
        /// </exception>
        public virtual void RemoveAt(int index)
        {
            ValidateIndex(index); // throws

            m_count--;

            if (index < m_count)
            {
                Array.Copy(m_array, index + 1, m_array, index, m_count - index);
            }

            // We can't set the deleted entry equal to null, because it might be a value type.
            // Instead, we'll create an empty single-element array of the right type and copy it 
            // over the entry we want to erase.
            IAppender[] temp = new IAppender[1];
            Array.Copy(temp, 0, m_array, m_count, 1);
            m_version++;
        }

        /// <summary>
        /// Gets a value indicating whether the collection has a fixed size.
        /// </summary>
        /// <value>true if the collection has a fixed size; otherwise, false. The default is false</value>
        public virtual bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether the IList is read-only.
        /// </summary>
        /// <value>true if the collection is read-only; otherwise, false. The default is false</value>
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region 操作实现 (类型安全 IEnumerable)

        /// <summary>
        /// Returns an enumerator that can iterate through the <c>AppenderCollection</c>.
        /// </summary>
        /// <returns>An <see cref="Enumerator"/> for the entire <c>AppenderCollection</c>.</returns>
        public virtual IAppenderCollectionEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        #endregion

        #region 公共帮助

        /// <summary>
        /// Gets or sets the number of elements the <c>AppenderCollection</c> can contain.
        /// </summary>
        public virtual int Capacity
        {
            get
            {
                return m_array.Length;
            }
            set
            {
                if (value < m_count)
                {
                    value = m_count;
                }

                if (value != m_array.Length)
                {
                    if (value > 0)
                    {
                        IAppender[] temp = new IAppender[value];
                        Array.Copy(m_array, 0, temp, 0, m_count);
                        m_array = temp;
                    }
                    else
                    {
                        m_array = new IAppender[DEFAULT_CAPACITY];
                    }
                }
            }
        }

        /// <summary>
        /// Adds the elements of another <c>AppenderCollection</c> to the current <c>AppenderCollection</c>.
        /// </summary>
        /// <param name="x">The <c>AppenderCollection</c> whose elements should be added to the end of the current <c>AppenderCollection</c>.</param>
        /// <returns>The new <see cref="AppenderCollection.Count"/> of the <c>AppenderCollection</c>.</returns>
        public virtual int AddRange(AppenderCollection x)
        {
            if (m_count + x.Count >= m_array.Length)
            {
                EnsureCapacity(m_count + x.Count);
            }

            Array.Copy(x.m_array, 0, m_array, m_count, x.Count);
            m_count += x.Count;
            m_version++;

            return m_count;
        }

        /// <summary>
        /// Adds the elements of a <see cref="IAppender"/> array to the current <c>AppenderCollection</c>.
        /// </summary>
        /// <param name="x">The <see cref="IAppender"/> array whose elements should be added to the end of the <c>AppenderCollection</c>.</param>
        /// <returns>The new <see cref="AppenderCollection.Count"/> of the <c>AppenderCollection</c>.</returns>
        public virtual int AddRange(IAppender[] x)
        {
            if (m_count + x.Length >= m_array.Length)
            {
                EnsureCapacity(m_count + x.Length);
            }

            Array.Copy(x, 0, m_array, m_count, x.Length);
            m_count += x.Length;
            m_version++;

            return m_count;
        }

        /// <summary>
        /// Adds the elements of a <see cref="IAppender"/> collection to the current <c>AppenderCollection</c>.
        /// </summary>
        /// <param name="col">The <see cref="IAppender"/> collection whose elements should be added to the end of the <c>AppenderCollection</c>.</param>
        /// <returns>The new <see cref="AppenderCollection.Count"/> of the <c>AppenderCollection</c>.</returns>
        public virtual int AddRange(ICollection col)
        {
            if (m_count + col.Count >= m_array.Length)
            {
                EnsureCapacity(m_count + col.Count);
            }

            foreach (object item in col)
            {
                Add((IAppender)item);
            }

            return m_count;
        }

        /// <summary>
        /// Sets the capacity to the actual number of elements.
        /// </summary>
        public virtual void TrimToSize()
        {
            this.Capacity = m_count;
        }

        /// <summary>
        /// Return the collection elements as an array
        /// </summary>
        /// <returns>the array</returns>
        public virtual IAppender[] ToArray()
        {
            IAppender[] resultArray = new IAppender[m_count];
            if (m_count > 0)
            {
                Array.Copy(m_array, 0, resultArray, 0, m_count);
            }
            return resultArray;
        }

        #endregion 公共帮助 (类型安全 IEnumerable)

        #region 实现帮助 (helpers)

        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="index"/> is less than zero</para>
        /// <para>-or-</para>
        /// <para><paramref name="index"/> is equal to or greater than <see cref="AppenderCollection.Count"/>.</para>
        /// </exception>
        private void ValidateIndex(int i)
        {
            ValidateIndex(i, false);
        }

        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="index"/> is less than zero</para>
        /// <para>-or-</para>
        /// <para><paramref name="index"/> is equal to or greater than <see cref="AppenderCollection.Count"/>.</para>
        /// </exception>
        private void ValidateIndex(int i, bool allowEqualEnd)
        {
            int max = (allowEqualEnd) ? (m_count) : (m_count - 1);
            if (i < 0 || i > max)
            {
                InternalLogger.Log("Index was out of range. Must be non-negative and less than the size of the collection. [" + (object)i + "] Specified argument was out of the range of valid values.");
            }
        }

        private void EnsureCapacity(int min)
        {
            int newCapacity = ((m_array.Length == 0) ? DEFAULT_CAPACITY : m_array.Length * 2);
            if (newCapacity < min)
            {
                newCapacity = min;
            }

            this.Capacity = newCapacity;
        }

        #endregion 实现帮助

        #region 实现操作 (ICollection)

        void ICollection.CopyTo(Array array, int start)
        {
            if (m_count > 0)
            {
                Array.Copy(m_array, 0, array, start, m_count);
            }
        }

        #endregion 实现操作 (ICollection)

        #region 实现操作 (IList)

        object IList.this[int i]
        {
            get { return (object)this[i]; }
            set { this[i] = (IAppender)value; }
        }

        int IList.Add(object x)
        {
            return this.Add((IAppender)x);
        }

        bool IList.Contains(object x)
        {
            return this.Contains((IAppender)x);
        }

        int IList.IndexOf(object x)
        {
            return this.IndexOf((IAppender)x);
        }

        void IList.Insert(int pos, object x)
        {
            this.Insert(pos, (IAppender)x);
        }

        void IList.Remove(object x)
        {
            this.Remove((IAppender)x);
        }

        void IList.RemoveAt(int pos)
        {
            this.RemoveAt(pos);
        }

        #endregion 实现操作 (IList)

        #region 实现操作(IEnumerable)

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)(this.GetEnumerator());
        }

        #endregion 实现操作(IEnumerable)

        #region 内嵌枚举类

        /// <summary>
        /// Supports simple iteration over a <see cref="AppenderCollection"/>.
        /// </summary>
        /// <exclude/>
        private sealed class Enumerator : IEnumerator, IAppenderCollectionEnumerator
        {
            #region Implementation (data)

            private readonly AppenderCollection m_collection;
            private int m_index;
            private int m_version;

            #endregion

            #region Construction

            /// <summary>
            /// Initializes a new instance of the <c>Enumerator</c> class.
            /// </summary>
            /// <param name="tc"></param>
            internal Enumerator(AppenderCollection tc)
            {
                m_collection = tc;
                m_index = -1;
                m_version = tc.m_version;
            }

            #endregion

            #region Operations (type-safe IEnumerator)

            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            public IAppender Current
            {
                get { return m_collection[m_index]; }
            }

            /// <summary>
            /// Advances the enumerator to the next element in the collection.
            /// </summary>
            /// <returns>
            /// <c>true</c> if the enumerator was successfully advanced to the next element; 
            /// <c>false</c> if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="InvalidOperationException">
            /// The collection was modified after the enumerator was created.
            /// </exception>
            public bool MoveNext()
            {
                if (m_version != m_collection.m_version)
                {
                    throw new System.InvalidOperationException("Collection was modified; enumeration operation may not execute.");
                }

                ++m_index;
                return (m_index < m_collection.Count);
            }

            /// <summary>
            /// Sets the enumerator to its initial position, before the first element in the collection.
            /// </summary>
            public void Reset()
            {
                m_index = -1;
            }
            #endregion

            #region Implementation (IEnumerator)

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            #endregion
        }

        #endregion 内嵌枚举类

        #region 内嵌只读封装类

        /// <exclude/>
        private sealed class ReadOnlyAppenderCollection : AppenderCollection, ICollection
        {
            #region 只读集合(data)

            private readonly AppenderCollection m_collection;

            #endregion 只读集合(data)

            #region 构造函数

            internal ReadOnlyAppenderCollection(AppenderCollection list)
                : base(Tag.Default)
            {
                m_collection = list;
            }

            #endregion 构造函数

            #region 类型安全 ICollection

            public override void CopyTo(IAppender[] array)
            {
                m_collection.CopyTo(array);
            }

            public override void CopyTo(IAppender[] array, int start)
            {
                m_collection.CopyTo(array, start);
            }

            void ICollection.CopyTo(Array array, int start)
            {
                ((ICollection)m_collection).CopyTo(array, start);
            }

            public override int Count
            {
                get { return m_collection.Count; }
            }

            public override bool IsSynchronized
            {
                get { return m_collection.IsSynchronized; }
            }

            public override object SyncRoot
            {
                get { return this.m_collection.SyncRoot; }
            }

            #endregion 类型安全 ICollection

            #region 类型安全 IList

            public override IAppender this[int i]
            {
                get { return m_collection[i]; }
                set { throw new NotSupportedException("This is a Read Only Collection and can not be modified"); }
            }

            public override int Add(IAppender x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override void Clear()
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override bool Contains(IAppender x)
            {
                return m_collection.Contains(x);
            }

            public override int IndexOf(IAppender x)
            {
                return m_collection.IndexOf(x);
            }

            public override void Insert(int pos, IAppender x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override void Remove(IAppender x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override void RemoveAt(int pos)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override bool IsFixedSize
            {
                get { return true; }
            }

            public override bool IsReadOnly
            {
                get { return true; }
            }

            #endregion 类型安全 IList

            #region 类型安全 IEnumerable

            public override IAppenderCollectionEnumerator GetEnumerator()
            {
                return m_collection.GetEnumerator();
            }

            #endregion 类型安全 IEnumerable

            #region 公共方法

            // (just to mimic some nice features of ArrayList)
            public override int Capacity
            {
                get { return m_collection.Capacity; }
                set { throw new NotSupportedException("This is a Read Only Collection and can not be modified"); }
            }

            public override int AddRange(AppenderCollection x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            public override int AddRange(IAppender[] x)
            {
                throw new NotSupportedException("This is a Read Only Collection and can not be modified");
            }

            #endregion 公共方法
        }

        #endregion 内嵌只读封装类
    }
}
