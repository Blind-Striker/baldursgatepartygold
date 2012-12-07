using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.ComponentModel;

namespace System.Waf.Applications
{
    /// <summary>
    /// Represents a collection that converts all elements of an original collection into converted elements. 
    /// When the original collection notifies a change via the <see cref="INotifyCollectionChanged"/> interface then
    /// this collection synchronizes it's converted elements with the original one.
    /// </summary>
    /// <typeparam name="TNew">The type of the converted elements in the collection.</typeparam>
    /// <typeparam name="TOld">The type of elements in the original collection.</typeparam>
    public sealed class ConverterCollection<TNew, TOld> : ReadOnlyObservableCollection<TNew>, IWeakEventListener
    {
        private readonly ObservableCollection<TNew> innerCollection;
        private readonly List<Tuple<TOld, TNew>> mapping;
        private readonly IEnumerable<TOld> originalCollection;
        private readonly Func<TOld, TNew> converter;
        private readonly IEqualityComparer<TNew> newItemComparer;
        private readonly IEqualityComparer<TOld> oldItemComparer;


        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterCollection&lt;TNew, TOld&gt;"/> class.
        /// </summary>
        /// <param name="originalCollection">The original collection.</param>
        /// <param name="converter">The converter used to create the elements in this collection.</param>
        /// <exception cref="ArgumentNullException">The argument originalCollection must not be null.</exception>
        /// <exception cref="ArgumentNullException">The argument converter must not be null.</exception>
        public ConverterCollection(IEnumerable<TOld> originalCollection, Func<TOld, TNew> converter)
            : base(new ObservableCollection<TNew>())
        {
            if (originalCollection == null) { throw new ArgumentNullException("originalCollection"); }
            if (converter == null) { throw new ArgumentNullException("converter"); }

            this.mapping = new List<Tuple<TOld, TNew>>();
            this.originalCollection = originalCollection;
            this.converter = converter;
            this.newItemComparer = EqualityComparer<TNew>.Default;
            this.oldItemComparer = EqualityComparer<TOld>.Default;

            INotifyCollectionChanged collectionChanged = originalCollection as INotifyCollectionChanged;
            if (collectionChanged != null)
            {
                CollectionChangedEventManager.AddListener(collectionChanged, this);
            }

            innerCollection = (ObservableCollection<TNew>)this.Items;
            foreach (TOld item in originalCollection)
            {
                innerCollection.Add(ConvertItem(item));
            }
        }


        /// <summary>
        /// Occurs when the collection changes.
        /// </summary>
        public new event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { base.CollectionChanged += value; }
            remove { base.CollectionChanged -= value; }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public new event PropertyChangedEventHandler PropertyChanged
        {
            add { base.PropertyChanged += value; }
            remove { base.PropertyChanged -= value; }
        }


        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            if (managerType == typeof(CollectionChangedEventManager))
            {
                OriginalCollectionChanged(sender, (NotifyCollectionChangedEventArgs)e);
                return true;
            }

            return false;
        }

        private TNew ConvertItem(TOld oldItem)
        {
            TNew newItem = converter(oldItem);
            mapping.Add(new Tuple<TOld, TNew>(oldItem, newItem));
            return newItem;
        }

        private bool RemoveCore(TOld oldItem)
        {
            Tuple<TOld, TNew> tuple = mapping.First(t => oldItemComparer.Equals(t.Item1, oldItem));
            mapping.Remove(tuple);
            return innerCollection.Remove(tuple.Item2);
        }

        private void RemoveAtCore(int index)
        {
            TNew newItem = this[index];
            Tuple<TOld, TNew> tuple = mapping.First(t => newItemComparer.Equals(t.Item2, newItem));
            mapping.Remove(tuple);
            innerCollection.RemoveAt(index);
        }

        private void ClearCore()
        {
            innerCollection.Clear();
            mapping.Clear();
        }

        private void OriginalCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewStartingIndex >= 0)
                {
                    int i = e.NewStartingIndex;
                    foreach (TOld item in e.NewItems)
                    {
                        innerCollection.Insert(i, ConvertItem(item));
                        i++;
                    }
                }
                else
                {
                    foreach (TOld item in e.NewItems)
                    {
                        innerCollection.Add(ConvertItem(item));
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                if (e.OldStartingIndex >= 0)
                {
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        RemoveAtCore(e.OldStartingIndex);
                    }
                }
                else
                {
                    foreach (TOld item in e.OldItems)
                    {
                        RemoveCore(item);
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                if (e.NewStartingIndex >= 0)
                {
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        innerCollection[i + e.NewStartingIndex] = ConvertItem((TOld)e.NewItems[i]);
                    }
                }
                else
                {
                    foreach (TOld item in e.OldItems) { RemoveCore(item); }
                    foreach (TOld item in e.NewItems) { innerCollection.Add(ConvertItem(item)); }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Move)
            {
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    innerCollection.Move(e.OldStartingIndex + i, e.NewStartingIndex + i);
                }
            }
            else // Reset
            {
                ClearCore();
                foreach (TOld item in originalCollection)
                {
                    innerCollection.Add(ConvertItem(item));
                }
            }
        }
    }
}
