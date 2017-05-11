namespace RMS.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Collections.Concurrent;

    /// <summary>
    /// 用于缓存数据类.
    /// </summary>
    /// <remarks>
    /// 缓存中的对象,不会永久贮存,过期后就会被删除,过期是指对象最后一次使用,加上对象存活时间（默认5秒.
    /// </remarks>
    public static class Cache
    {
        #region Event & Delegate

        #endregion


        #region Filed

        static Dictionary<string, CacheLabel> dictonary = new Dictionary<string, CacheLabel>();
        private static readonly object dicChangeLock = new object();
        static Timer timerForSetFade;
        static Timer timerForRemoveCacheElement;

        #endregion


        #region Constructor
        static Cache()
        {
            timerForSetFade = new Timer(p =>
            {
                lock (dicChangeLock)
                {
                    DateTime now = DateTime.Now;
                    foreach (var value in dictonary.Values)
                    {
                        var time = now - value.LastGetTime;
                        if (time.TotalSeconds > value.AliveSeconds)
                        {
                            value.Faded = true;
                        }
                    }
                }

            }, null, 0, 1000 * 5);

            timerForRemoveCacheElement =
                 new Timer(p =>
                 {
                     lock (dicChangeLock)
                     {
                         var toRemove = new List<string>();

                         var enumerator = dictonary.GetEnumerator();
                         while (enumerator.MoveNext())
                         {
                             if (enumerator.Current.Value.Faded)
                             {
                                 toRemove.Add(enumerator.Current.Key);
                             }
                         }
                         CacheLabel label = enumerator.Current.Value;
                         toRemove.ForEach(key => dictonary.Remove(key));
                     }

                 }, null, 0, 1000 * 60);
        }
        #endregion


        #region Public Properties
        /// <summary>
        /// 开启/关闭
        /// </summary>
        public static bool Enable { get; set; }

        public static int Count
        {
            get { return dictonary.Count; }
        }

        #endregion


        #region Public Method

        public static bool TryGet(string key, out object result)
        {
            if (!Enable)
            {
                result = null; return false;
            }

            CacheLabel cacheLabel;
            bool containsKey = dictonary.TryGetValue(key, out cacheLabel);
            if (containsKey)
            {
                result = cacheLabel.Faded ? null : cacheLabel.Value;
            }
            else
            {
                result = null;
            }

            return containsKey && !cacheLabel.Faded;
        }
        /// <summary>
        /// 添加到缓存
        /// </summary>
        /// <param name="key">键值。注意别和其他相同，起名要有特点，有意义</param>
        /// <param name="value"></param>
        public static void Set(string key, object value)
        {
            Set(key, value, 5);
        }
        /// <summary>
        /// 添加到缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="aliveSeconds">存活时间（秒）</param>
        public static void Set(string key, object value, int aliveSeconds)
        {
            if (!Enable)
            {
                return;
            }

            if (aliveSeconds == 0)
            {
                return;
            }
            if (aliveSeconds < 0)
            {
                throw new Exception("aliveSeconds should great than zero");
            }

            CacheLabel cacheLabel;
            if (dictonary.TryGetValue(key, out cacheLabel))
            {
                cacheLabel.Value = value;
            }
            else
            {
                cacheLabel = new CacheLabel(value);
                lock (dicChangeLock)
                {
                    if (!dictonary.ContainsKey(key))
                        dictonary.Add(key, cacheLabel);

                }
            }
            cacheLabel.AliveSeconds = aliveSeconds;
        }
        /// <summary>
        /// 从缓存中删除
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            CacheLabel obj;
            if (dictonary.TryGetValue(key, out obj))
            {
                obj.Faded = true;
            }
        }

        public static string PrintAllItems()
        {
            var sb = new StringBuilder();
            var enumerator = dictonary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                sb.Append(string.Format("{0}:{1}{2}", enumerator.Current.Key,
                                        enumerator.Current.Value.Value == null
                                        ? string.Empty
                                        : enumerator.Current.Value.Value.ToString(), Environment.NewLine));
            }

            return sb.ToString();
        }

        public static void RemoveAll()
        {
            dictonary.Clear();
        }

        #endregion


        #region Private Method

        #endregion

        class CacheLabel
        {
            private object v;
            private bool faded;

            public CacheLabel(object value)
            {
                LastGetTime = DateTime.Now;
                Faded = false;

                this.v = value;
            }

            public DateTime LastGetTime { get; set; }

            public object Value
            {
                get
                {
                    LastGetTime = DateTime.Now;
                    return v;
                }
                set
                {
                    this.v = value;
                    faded = false;
                }
            }

            public bool Faded
            {
                get
                {
                    return faded;
                }
                set
                {
                    faded = value;
                    if (faded)
                    {
                        v = null;
                    }
                }
            }

            public int AliveSeconds { get; set; }
        }
    }
}
