using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

    public enum FindRange
    {
        Equal = 0,
        GreaterThan,
        LessThan
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class CollectionEx<T> : System.Collections.CollectionBase where T : ICollectionEx
    {
        private ArrayList _deletedList;
        private ArrayList _addedList;

        /// <summary>
        /// 
        /// </summary>
        public CollectionEx()
        {
            _deletedList = new ArrayList(5);
            _addedList = new ArrayList(5);
        }

        #region Over Ridden Methods
        protected override void OnInsert(int index, object value)
        {
            base.OnInsert(index, value);
        }

        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsertComplete(index, value);
        }

        protected override void OnSet(int index, object oldValue, object newValue)
        {
            base.OnSet(index, oldValue, newValue);
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            base.OnSetComplete(index, oldValue, newValue);
        }

        protected override void OnClear()
        {
            base.OnClear();
        }

        protected override void OnClearComplete()
        {
            base.OnClearComplete();
        }

        protected override void OnRemove(int index, object value)
        {
            base.OnRemove(index, value);
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            base.OnRemoveComplete(index, value);
        }

        protected override void OnValidate(object value)
        {
            base.OnValidate(value);
        }

        public override string ToString()
        {
            return base.ToString();
        }
        
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return base.List.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            return base.List.IndexOf(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            base.List.Insert(index, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return (T)base.List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual int Add(T value)
        {
            _addedList.Add(value);
            return base.List.Add(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            //  Was this item added to the original list
            if (_addedList.Contains(item))
            {
                _addedList.Remove(item);
            }
            else
            {
                if (List.Contains(item))
                    _deletedList.Add(item);
            }
            base.List.Remove(item);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            foreach (T obj in _addedList)
            {
                List.Remove(obj);
            }
            _addedList.Clear();

            foreach (T obj in _deletedList)
            {
                //_addedList.Add(obj);
                base.List.Add(obj);
            }
            _deletedList.Clear();
            _addedList.Clear();
            // give the children a bath?
            foreach (T obj in base.List)
            {
                if (obj.IsDirty)
                    obj.Reset();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDirty
        {
            get 
            {
                return (_addedList.Count != 0 || _deletedList.Count != 0 || IsDirtyChildren);
            }
            set
            {
                if (!value)
                    _addedList.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDirtyChildren
        {
            get
            {
                foreach (T obj in base.List)
                {
                    if (obj.IsDirty)
                        return true;
                }
                return false;
            }
        }

        public T[] ToArray()
        {
            return (T[])this.InnerList.ToArray(typeof(T));
        }

        public CollectionEx<T> Find(String PropertyName, Object ValueToFind)
        {
            return Find(PropertyName, ValueToFind, FindRange.Equal);
        }

        public CollectionEx<T> Find(String PropertyName, Object ValueToFind, 
            FindRange constraint)
        {
            CollectionEx<T> list = new CollectionEx<T>();

            foreach (T item in this)
            {
                Type itemType = item.GetType();
                PropertyInfo pi = item.GetType().GetProperty(PropertyName);
                object valueOfX = pi.GetValue(item, null);

                if (item.CompareValues(valueOfX, ValueToFind, constraint))
                {
                    list.Add(item);
                }
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CollectionEx<T> Copy()
        {
            CollectionEx<T> list = null;

            byte[] rawBytes = null;
            
            using (MemoryStream streamWriter = new MemoryStream())
            {
                BinaryFormatter serializerWriter = new BinaryFormatter();
                serializerWriter.Serialize(streamWriter, this);
                rawBytes = streamWriter.GetBuffer();
            }

            using (MemoryStream streamReader = new MemoryStream(rawBytes))
            {
                BinaryFormatter serializerReader = new BinaryFormatter();
                list = serializerReader.Deserialize(streamReader) as CollectionEx<T>;
            }

            return list;
        }

        #region Sort Methods
        public void Sort(String propertyName, ListSortDirection sortDirection)
        {
            InnerList.Sort(new Comparer(propertyName, sortDirection));
        }
        public void Sort(String propertyName)
        {
            InnerList.Sort(new Comparer(propertyName));
        }
        
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class Comparer : IComparer
    {
        string _SortPropertyName;
        ListSortDirection _SortDirection;

        public Comparer(string sortPropertyName)
        {
            _SortPropertyName = sortPropertyName;
            _SortDirection = ListSortDirection.Ascending;
        }

        public Comparer(string sortPropertyName, ListSortDirection sortDirection)
        {
            _SortPropertyName = sortPropertyName;
            _SortDirection = sortDirection;
        }

        public int Compare(object x, object y)
        {
            // Get the values of the relevant property on the x and y objects

            object valueOfX = x.GetType().GetProperty(_SortPropertyName).GetValue(x, null);
            object valueOfY = y.GetType().GetProperty(_SortPropertyName).GetValue(y, null);

            IComparable comp = valueOfY as IComparable;
            int valCompare = comp.CompareTo(valueOfX); ;

            if (_SortDirection == ListSortDirection.Ascending)
            {
                valCompare *= -1;
            }


            return valCompare;
        }
    }
