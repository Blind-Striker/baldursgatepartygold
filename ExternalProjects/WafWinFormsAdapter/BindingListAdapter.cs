using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.ObjectModel;

namespace System.Waf.Presentation.WinForms
{
    public sealed class BindingListAdapter<T> : IList<T>, IBindingList
    {
        private readonly IList<T> innerList;
        private readonly INotifyCollectionChanged innerNotificationProvider;


        public BindingListAdapter(object list)
        {
            if (list == null) { throw new ArgumentNullException("list"); }

            if (list is IList<T>)
            {
                innerList = (IList<T>)list;
            }
            else if (list is IEnumerable<T>)
            {
                innerList = new ReadOnlyCollection<T>(((IEnumerable<T>)list).ToList());
            }
            else
            {
                throw new ArgumentException("The argument 'list' must be a collection.");
            }

            innerNotificationProvider = list as INotifyCollectionChanged;
            if (innerNotificationProvider != null)
            {
                innerNotificationProvider.CollectionChanged += InnerCollectionChanged;
                foreach (object item in innerList)
                {
                    StartListeningToPropertyChanged(item);
                }
            }
        }


        public bool IsReadOnly { get { return innerList.IsReadOnly; } }

        public int Count { get { return innerList.Count; } }

        public T this[int index]
        {
            get { return innerList[index]; }
            set { innerList[index] = value; }
        }

        bool ICollection.IsSynchronized { get { return false; } }

        object ICollection.SyncRoot { get { return null; } }

        bool IList.IsFixedSize { get { return false; } }

        object IList.this[int index]
        {
            get { return innerList[index]; }
            set { innerList[index] = (T)value; }
        }

        bool IBindingList.AllowNew { get { return false; } }

        bool IBindingList.AllowEdit { get { return true; } }

        bool IBindingList.AllowRemove { get { return !IsReadOnly; } }

        bool IBindingList.SupportsChangeNotification { get { return true; } }

        bool IBindingList.SupportsSorting { get { return false; } }

        bool IBindingList.IsSorted { get { return false; } }

        ListSortDirection IBindingList.SortDirection { get { return ListSortDirection.Ascending; } }

        PropertyDescriptor IBindingList.SortProperty { get { return null; } }

        bool IBindingList.SupportsSearching { get { return false; } }


        public event ListChangedEventHandler ListChanged;


        public bool Contains(T item) { return innerList.Contains(item); }

        public int IndexOf(T item) { return innerList.IndexOf(item); }

        public void Add(T item) { innerList.Add(item); }

        public void Insert(int index, T item) { innerList.Insert(index, item); }

        public bool Remove(T item) { return innerList.Remove(item); }

        public void RemoveAt(int index) { innerList.RemoveAt(index); }

        public void Clear() { innerList.Clear(); }

        public void CopyTo(T[] array, int arrayIndex) { innerList.CopyTo(array, arrayIndex); }

        public IEnumerator<T> GetEnumerator() { return innerList.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        void ICollection.CopyTo(Array array, int index) { CopyTo((T[])array, index); }

        bool IList.Contains(object value) { return Contains((T)value); }

        int IList.IndexOf(object value) { return IndexOf((T)value); }

        int IList.Add(object value)
        {
            Add((T)value);
            return Count - 1;
        }

        void IList.Insert(int index, object value) { Insert(index, (T)value); }

        void IList.Remove(object value) { Remove((T)value); }

        object IBindingList.AddNew() { throw new NotSupportedException(); }

        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) { throw new NotSupportedException(); }

        void IBindingList.RemoveSort() { throw new NotSupportedException(); }

        int IBindingList.Find(PropertyDescriptor property, object key) { throw new NotSupportedException(); }

        void IBindingList.AddIndex(PropertyDescriptor property) { }

        void IBindingList.RemoveIndex(PropertyDescriptor property) { }

        private void OnListChanged(ListChangedEventArgs e)
        {
            if (ListChanged != null) { ListChanged(this, e); }
        }

        private void InnerCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        StartListeningToPropertyChanged(e.NewItems[i]);
                        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, e.NewStartingIndex + i));
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        StopListeningToPropertyChanged(e.OldItems[i]);
                        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, e.OldStartingIndex + i));
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        OnListChanged(new ListChangedEventArgs(ListChangedType.ItemMoved, e.NewStartingIndex + i,
                            e.OldStartingIndex + i));
                    }
                    break;
                default:
                    foreach (object item in e.OldItems)
                    {
                        StopListeningToPropertyChanged(item);
                    }
                    foreach (object item in e.NewItems)
                    {
                        StartListeningToPropertyChanged(item);
                    }
                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
                    break;
            }
        }

        private void StartListeningToPropertyChanged(object item)
        {
            INotifyPropertyChanged observable = item as INotifyPropertyChanged;
            if (observable != null)
            {
                observable.PropertyChanged += ItemPropertyChanged;
            }
        }

        private void StopListeningToPropertyChanged(object item)
        {
            INotifyPropertyChanged observable = item as INotifyPropertyChanged;
            if (observable != null)
            {
                observable.PropertyChanged -= ItemPropertyChanged;
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, IndexOf((T)sender)));
        }
    }
}
