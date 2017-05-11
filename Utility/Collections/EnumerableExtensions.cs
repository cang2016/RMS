using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Utility
{
    /// <summary>
    /// 提供实现<see cref="IEnumberable(T)"/>接口的扩展.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 遍历每个元素<pararef name="sequence">执行<pararef name="action"/>方法.
        /// </summary>
        /// <typeparam name="T">序列中的元素类型.</typeparam>
        /// <param name="sequence">要遍历的序列.</param>
        /// <param name="action">每个元素要调用的方法.</param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            sequence.NotNull("sequence");

            foreach (T item in sequence)
            {
                action(item);
            }
        }

        /// <summary>
        /// 同两个序列并通过调用zipper委托组成的序列.
        /// </summary>
        /// <typeparam name="T1">第一个序列元素类型</typeparam>
        /// <typeparam name="T2">第二个序列元素类型</typeparam>
        /// <typeparam name="TResult">返回的结果类型</typeparam>
        /// <param name="sequence1">第一个序列</param>
        /// <param name="sequence2">第二个序列</param>
        /// <param name="zipper">创建序列的委托</param>
        /// <returns>可枚举序列</returns>
        public static IEnumerable<TResult> Zip<T1, T2, TResult>(this IEnumerable<T1> sequence1, IEnumerable<T2> sequence2, Func<T1, T2, TResult> zipper)
        {
            sequence1.NotNull("sequence1");
            sequence2.NotNull("sequence2");

            IEnumerator<T1> enumerator1 = sequence1.GetEnumerator();
            IEnumerator<T2> enumerator2 = sequence2.GetEnumerator();

            while (enumerator1.MoveNext())
            {
                if (!enumerator2.MoveNext())
                {
                    yield break;
                }

                yield return zipper(enumerator1.Current, enumerator2.Current);
            }
        }

        /// <summary>
        /// 由两个序列组成的一个KeyValuePair类型的对象.
        /// </summary>
        /// <typeparam name="T1">第一个序列元素类型</typeparam>
        /// <typeparam name="T2">第二个序列元素类型</typeparam>
        /// <param name="sequence1">第一个序列</param>
        /// <param name="sequence2">第二个序列</param>
        /// <returns>KeyValuePair类型的对象</returns>
        public static IEnumerable<KeyValuePair<T1, T2>> Zip<T1, T2>(this IEnumerable<T1> sequence1, IEnumerable<T2> sequence2)
        {
            sequence1.NotNull("sequence1");
            sequence2.NotNull("sequence2");

            return sequence1.Zip(sequence2, (t1, t2) => new KeyValuePair<T1, T2>(t1, t2));
        }

        /// <summary>
        /// 返回由第一个序列到键，第二个序列到值的字典.
        /// </summary>
        /// <typeparam name="TKey">第一个序列类型</typeparam>
        /// <typeparam name="TValue">第二个序列类型</typeparam>
        /// <param name="keys">第一个序列</param>
        /// <param name="values">第二个序列</param>
        /// <returns>组成的字典</returns>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            keys.NotNull("keys");
            values.NotNull("values");

            return keys.Zip(values).ToDictionary(k => k.Key, k => k.Value);
        }
    }
}
