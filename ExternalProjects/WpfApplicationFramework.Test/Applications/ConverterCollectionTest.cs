using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Waf.Foundation;
using System.Waf.Applications;
using System.Collections.ObjectModel;
using System.Waf.UnitTesting;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Test.Waf.Applications
{
    [TestClass]
    public class ConverterCollectionTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            List<MyModel> originalCollection = new List<MyModel>();
            
            AssertHelper.ExpectedException<ArgumentNullException>(() => new ConverterCollection<MyDataModel, MyModel>(
                null, null));
            AssertHelper.ExpectedException<ArgumentNullException>(() =>  new ConverterCollection<MyDataModel, MyModel>(
                originalCollection, null));
        }

        [TestMethod]
        public void ObservableCollectionTest()
        {
            ObservableCollection<MyModel> originalCollection = new ObservableCollection<MyModel>()
            {
                new MyModel(),
                new MyModel(),
                new MyModel()
            };

            ConverterCollection<MyDataModel, MyModel> converterCollection = new ConverterCollection<MyDataModel, MyModel>(
                originalCollection, m => new MyDataModel(m));
            Assert.IsTrue(originalCollection.SequenceEqual(converterCollection.Select(dm => dm.Model)));

            // Check add operation with collection changed event.
            bool handlerCalled = false;
            NotifyCollectionChangedEventHandler handler = (sender, e) => 
            {
                handlerCalled = true;
                Assert.AreEqual(converterCollection, sender);
                Assert.AreEqual(NotifyCollectionChangedAction.Add, e.Action);
                Assert.AreEqual(3, e.NewStartingIndex);
                Assert.AreEqual(originalCollection.Last(), e.NewItems.Cast<MyDataModel>().Single().Model);
            };
            converterCollection.CollectionChanged += handler;
            originalCollection.Add(new MyModel());
            converterCollection.CollectionChanged -= handler;
            Assert.IsTrue(handlerCalled);

            // Check insert at index 0 operation with collection changed event.
            handlerCalled = false;
            handler = (sender, e) =>
            {
                handlerCalled = true;
                Assert.AreEqual(converterCollection, sender);
                Assert.AreEqual(NotifyCollectionChangedAction.Add, e.Action);
                Assert.AreEqual(0, e.NewStartingIndex);
                Assert.AreEqual(originalCollection.First(), e.NewItems.Cast<MyDataModel>().Single().Model);
            };
            converterCollection.CollectionChanged += handler;
            originalCollection.Insert(0, new MyModel());
            converterCollection.CollectionChanged -= handler;
            Assert.IsTrue(handlerCalled);

            // Compare the collections
            Assert.IsTrue(originalCollection.SequenceEqual(converterCollection.Select(dm => dm.Model)));

            // Check remove operation with collection changed event.
            MyModel itemToRemove = originalCollection[2];
            handlerCalled = false;
            handler = (sender, e) =>
            {
                handlerCalled = true;
                Assert.AreEqual(converterCollection, sender);
                Assert.AreEqual(NotifyCollectionChangedAction.Remove, e.Action);
                Assert.AreEqual(2, e.OldStartingIndex);
                Assert.AreEqual(itemToRemove, e.OldItems.Cast<MyDataModel>().Single().Model);
            };
            converterCollection.CollectionChanged += handler;
            originalCollection.Remove(itemToRemove);
            converterCollection.CollectionChanged -= handler;
            Assert.IsTrue(handlerCalled);

            // Check replace operation with collection changed event.
            MyModel itemToReplace = originalCollection[1];
            handlerCalled = false;
            handler = (sender, e) =>
            {
                handlerCalled = true;
                Assert.AreEqual(converterCollection, sender);
                Assert.AreEqual(NotifyCollectionChangedAction.Replace, e.Action);
                Assert.AreEqual(1, e.NewStartingIndex);
                Assert.AreEqual(1, e.OldStartingIndex);
                Assert.AreEqual(originalCollection[1], e.NewItems.Cast<MyDataModel>().Single().Model);
                Assert.AreEqual(itemToReplace, e.OldItems.Cast<MyDataModel>().Single().Model);
            };
            converterCollection.CollectionChanged += handler;
            originalCollection[1] = new MyModel();
            converterCollection.CollectionChanged -= handler;
            Assert.IsTrue(handlerCalled);

            // Check move operation with collection changed event.
            handlerCalled = false;
            handler = (sender, e) =>
            {
                handlerCalled = true;
                Assert.AreEqual(converterCollection, sender);
                Assert.AreEqual(NotifyCollectionChangedAction.Move, e.Action);
                Assert.AreEqual(0, e.OldStartingIndex);
                Assert.AreEqual(2, e.NewStartingIndex);
            };
            converterCollection.CollectionChanged += handler;
            originalCollection.Move(0, 2);
            converterCollection.CollectionChanged -= handler;
            Assert.IsTrue(handlerCalled);

            // Check clear operation with collection changed event.
            handlerCalled = false;
            handler = (sender, e) =>
            {
                handlerCalled = true;
                Assert.AreEqual(converterCollection, sender);
                Assert.AreEqual(NotifyCollectionChangedAction.Reset, e.Action);                
            };
            converterCollection.CollectionChanged += handler;
            originalCollection.Clear();
            converterCollection.CollectionChanged -= handler;
            Assert.IsTrue(handlerCalled);
            Assert.IsFalse(converterCollection.Any());
        }

        [TestMethod]
        public void CustomCollectionTest()
        {
            CustomCollection<MyModel> originalCollection = new CustomCollection<MyModel>(true)
            {
                new MyModel(),
                new MyModel(),
                new MyModel()
            };

            ConverterCollection<MyDataModel, MyModel> converterCollection = new ConverterCollection<MyDataModel, MyModel>(
                originalCollection, m => new MyDataModel(m));
            Assert.IsTrue(originalCollection.SequenceEqual(converterCollection.Select(dm => dm.Model)));

            // Check add operation with collection changed event.
            bool handlerCalled = false;
            NotifyCollectionChangedEventHandler handler = (sender, e) =>
            {
                handlerCalled = true;
                Assert.AreEqual(converterCollection, sender);
                Assert.AreEqual(NotifyCollectionChangedAction.Add, e.Action);
                Assert.AreEqual(3, e.NewStartingIndex);
                Assert.AreEqual(originalCollection.Last(), e.NewItems.Cast<MyDataModel>().Single().Model);
            };
            converterCollection.CollectionChanged += handler;
            originalCollection.Add(new MyModel());
            converterCollection.CollectionChanged -= handler;
            Assert.IsTrue(handlerCalled);

            // Compare the collections
            Assert.IsTrue(originalCollection.SequenceEqual(converterCollection.Select(dm => dm.Model)));

            // Check remove operation with collection changed event.
            MyModel itemToRemove = originalCollection[2];
            handlerCalled = false;
            handler = (sender, e) =>
            {
                handlerCalled = true;
                Assert.AreEqual(converterCollection, sender);
                Assert.AreEqual(NotifyCollectionChangedAction.Remove, e.Action);
                Assert.AreEqual(2, e.OldStartingIndex);
                Assert.AreEqual(itemToRemove, e.OldItems.Cast<MyDataModel>().Single().Model);
            };
            converterCollection.CollectionChanged += handler;
            originalCollection.Remove(itemToRemove);
            converterCollection.CollectionChanged -= handler;
            Assert.IsTrue(handlerCalled);

            // Check replace operation with collection changed event.
            MyModel itemToReplace = originalCollection[1];
            int handlerCalledCount = 0;
            handler = (sender, e) =>
            {
                Assert.AreEqual(converterCollection, sender);
                if (handlerCalledCount == 0)
                {
                    Assert.AreEqual(NotifyCollectionChangedAction.Remove, e.Action);
                    Assert.AreEqual(itemToReplace, e.OldItems.Cast<MyDataModel>().Single().Model);
                }
                else
                {
                    Assert.AreEqual(NotifyCollectionChangedAction.Add, e.Action);
                    Assert.AreEqual(originalCollection[1], e.NewItems.Cast<MyDataModel>().Single().Model);
                }
                handlerCalledCount++;
            };
            converterCollection.CollectionChanged += handler;
            originalCollection[1] = new MyModel();
            converterCollection.CollectionChanged -= handler;
            Assert.AreEqual(2, handlerCalledCount);

            // Check reset operation with collection changed event.
            List<MyModel> newItems = new List<MyModel>()
            {
                new MyModel(),
                new MyModel()
            };
            handlerCalledCount = 0;
            handler = (sender, e) =>
            {
                Assert.AreEqual(converterCollection, sender);
                if (handlerCalledCount == 0)
                {
                    Assert.AreEqual(NotifyCollectionChangedAction.Reset, e.Action);
                }
                else
                {
                    Assert.AreEqual(NotifyCollectionChangedAction.Add, e.Action);
                }
                handlerCalledCount++;
            };
            converterCollection.CollectionChanged += handler;
            originalCollection.Reset(newItems);
            converterCollection.CollectionChanged -= handler;
            Assert.AreEqual(3, handlerCalledCount);
            Assert.IsTrue(newItems.SequenceEqual(converterCollection.Select(dm => dm.Model)));
        }

        [TestMethod]
        public void PropertyChangedTest()
        {
            ObservableCollection<MyModel> originalCollection = new ObservableCollection<MyModel>();
            
            ConverterCollection<MyDataModel, MyModel> converterCollection = new ConverterCollection<MyDataModel, MyModel>(
                originalCollection, m => new MyDataModel(m));
            
            // Check that the PropertyChanged event for Count is raised.
            bool handlerCalled = false;
            PropertyChangedEventHandler handler = (sender, e) =>
            {
                Assert.AreEqual(converterCollection, sender);
                if (e.PropertyName == "Count")
                {
                    handlerCalled = true;
                }
            };
            converterCollection.PropertyChanged += handler;
            originalCollection.Add(new MyModel());
            converterCollection.PropertyChanged -= handler;
            Assert.IsTrue(handlerCalled);

            // Check that after unwiring the event the handler is not called anymore.
            handlerCalled = false;
            originalCollection.Add(new MyModel());
            Assert.IsFalse(handlerCalled);
        }

        [TestMethod]
        public void GarbageCollectorTest()
        {
            ObservableCollection<MyModel> originalCollection = new ObservableCollection<MyModel>();

            ConverterCollection<MyDataModel, MyModel> converterCollection = new ConverterCollection<MyDataModel, MyModel>(
                originalCollection, m => new MyDataModel(m));
            WeakReference weakConverterCollection = new WeakReference(converterCollection);

            originalCollection.Add(new MyModel());
            Assert.IsTrue(weakConverterCollection.IsAlive);

            converterCollection = null;
            GC.Collect();
            Assert.IsNotNull(originalCollection);
            Assert.IsFalse(weakConverterCollection.IsAlive);
        }



        private class MyDataModel : DataModel
        {
            private readonly MyModel model;


            public MyDataModel(MyModel model)
            {
                this.model = model;
            }


            public MyModel Model { get { return model; } }
        }
        
        private class MyModel : Model { }

        private class CustomCollection<T> : ObservableCollection<T>
        {
            private readonly bool withoutIndex;
            private bool suppressNotifications;

            
            public CustomCollection(bool withoutIndex)
            {
                this.withoutIndex = withoutIndex;
            }


            public void Reset(IEnumerable<T> newItems)
            {
                try
                {
                    suppressNotifications = true;
                    Clear();
                    if (newItems != null)
                    {
                        foreach (T item in newItems)
                        {
                            Add(item);
                        }
                    }
                }
                finally
                {
                    suppressNotifications = false;
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }


            protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
            {
                if (suppressNotifications) { return; }
                
                if (withoutIndex)
                {
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            e = new NotifyCollectionChangedEventArgs(e.Action, e.NewItems);
                            break;
                        case NotifyCollectionChangedAction.Remove:
                            e = new NotifyCollectionChangedEventArgs(e.Action, e.OldItems);
                            break;
                        case NotifyCollectionChangedAction.Replace:
                            e = new NotifyCollectionChangedEventArgs(e.Action, e.NewItems, e.OldItems);
                            break;
                        case NotifyCollectionChangedAction.Reset:
                            e = new NotifyCollectionChangedEventArgs(e.Action);
                            break;
                    }
                    
                }
                base.OnCollectionChanged(e);
            }
        }
    }
}
