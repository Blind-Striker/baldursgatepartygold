﻿using System;
using System.Linq;
using System.Waf.Applications;
using System.Waf.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.IO;

namespace Test.Waf.Applications
{
    [TestClass]
    public class RecentFileListTest
    {
        [TestMethod]
        public void SetMaxFilesNumber()
        {
            RecentFileList recentFileList = new RecentFileList();
            recentFileList.AddFile("Doc4");
            recentFileList.AddFile("Doc3");
            recentFileList.AddFile("Doc2");
            recentFileList.AddFile("Doc1");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new [] { "Doc1", "Doc2", "Doc3", "Doc4" }));
            
            // Set a lower number than items are in the list => expect that the list is truncated.
            recentFileList.MaxFilesNumber = 3;
            Assert.AreEqual(3, recentFileList.MaxFilesNumber);
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc1", "Doc2", "Doc3" }));

            AssertHelper.ExpectedException<ArgumentException>(() => recentFileList.MaxFilesNumber = -3);
        }

        [TestMethod]
        public void AddFiles()
        {
            RecentFileList recentFileList = new RecentFileList();
            recentFileList.MaxFilesNumber = 3;

            AssertHelper.ExpectedException<ArgumentException>(() => recentFileList.AddFile(null));

            // Add files to an empty list
            recentFileList.AddFile("Doc3");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc3" }));
            recentFileList.AddFile("Doc2");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc2", "Doc3" }));
            recentFileList.AddFile("Doc1");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc1", "Doc2", "Doc3" }));

            // Add a file to a full list
            recentFileList.AddFile("Doc4");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc4", "Doc1", "Doc2" }));

            // Add a file that already exists in the list
            recentFileList.AddFile("Doc2");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc2", "Doc4", "Doc1" }));
        }

        [TestMethod]
        public void AddFilesAndPinThem()
        {
            RecentFileList recentFileList = new RecentFileList();
            recentFileList.MaxFilesNumber = 3;

            // Add files to an empty list
            recentFileList.AddFile("Doc3");
            recentFileList.AddFile("Doc2");
            recentFileList.AddFile("Doc1");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc1", "Doc2", "Doc3" }));

            // Pin first file
            recentFileList.RecentFiles.First(r => r.Path == "Doc3").IsPinned = true;
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc3", "Doc1", "Doc2" }));

            // Add a file to a full list
            recentFileList.AddFile("Doc4");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc3", "Doc4", "Doc1" }));

            // Add a file that already exists in the list
            recentFileList.AddFile("Doc1");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc3", "Doc1", "Doc4" }));

            // Pin all files
            recentFileList.RecentFiles.First(r => r.Path == "Doc4").IsPinned = true;
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc4", "Doc3", "Doc1" }));
            recentFileList.RecentFiles.First(r => r.Path == "Doc1").IsPinned = true;
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc1", "Doc4", "Doc3" }));

            // Add a file to a full pinned list
            recentFileList.AddFile("Doc5");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc1", "Doc4", "Doc3" }));

            // Add a file that already exists in the list
            recentFileList.AddFile("Doc4");
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc4", "Doc1", "Doc3" }));

            // Unpin files
            recentFileList.RecentFiles.First(r => r.Path == "Doc4").IsPinned = false;
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc1", "Doc3", "Doc4" }));
            recentFileList.RecentFiles.First(r => r.Path == "Doc1").IsPinned = false;
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc3", "Doc1", "Doc4" }));
        }

        [TestMethod]
        public void XmlSerializing()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RecentFileList));

            // Serialize an empty list            
            MemoryStream stream1 = new MemoryStream();
            RecentFileList recentFileList1 = new RecentFileList();
            serializer.Serialize(stream1, recentFileList1);
            stream1.Position = 0;
            RecentFileList recentFileList2 = (RecentFileList)serializer.Deserialize(stream1);
            Assert.AreEqual(recentFileList1.RecentFiles.Count, recentFileList2.RecentFiles.Count);
            Assert.IsTrue(recentFileList1.RecentFiles.Select(f => f.Path).SequenceEqual(recentFileList2.RecentFiles.Select(f => f.Path)));

            // Serialize a list with items
            MemoryStream stream2 = new MemoryStream();
            recentFileList2.AddFile("Doc3");
            recentFileList2.AddFile("Doc2");
            recentFileList2.AddFile("Doc1");
            serializer.Serialize(stream2, recentFileList2);
            stream2.Position = 0;
            RecentFileList recentFileList3 = (RecentFileList)serializer.Deserialize(stream2);
            Assert.IsTrue(recentFileList2.RecentFiles.Select(f => f.Path).SequenceEqual(recentFileList3.RecentFiles.Select(f => f.Path)));

            // Set MaxFilesNumber to a lower number
            recentFileList3.MaxFilesNumber = 2;
            Assert.IsTrue(recentFileList3.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "Doc1", "Doc2" }));

            // Check error handling of the serializable implementation
            IXmlSerializable serializable = recentFileList3;
            Assert.IsNull(serializable.GetSchema());
            AssertHelper.ExpectedException<ArgumentNullException>(() => serializable.ReadXml(null));
            AssertHelper.ExpectedException<ArgumentNullException>(() => serializable.WriteXml(null));
        }

        [TestMethod]
        public void Load()
        {
            RecentFileList recentFileList = new RecentFileList();
            recentFileList.MaxFilesNumber = 3;
            recentFileList.AddFile("Doc3");
            recentFileList.AddFile("Doc2");
            recentFileList.AddFile("Doc1");

            AssertHelper.ExpectedException<ArgumentNullException>(() => recentFileList.Load(null));

            // Load an empty recent file list
            recentFileList.Load(new RecentFile[] { });
            Assert.IsFalse(recentFileList.RecentFiles.Any());

            recentFileList.Load(new RecentFile[] 
            {
                new RecentFile("NewDoc1") { IsPinned = true },
                new RecentFile("NewDoc2"),
                new RecentFile("NewDoc3"),
                new RecentFile("NewDoc4")
            });
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.Path).SequenceEqual(new[] { "NewDoc1", "NewDoc2", "NewDoc3" }));
            Assert.IsTrue(recentFileList.RecentFiles.Select(f => f.IsPinned).SequenceEqual(new[] { true, false, false }));
        }
    }
}
