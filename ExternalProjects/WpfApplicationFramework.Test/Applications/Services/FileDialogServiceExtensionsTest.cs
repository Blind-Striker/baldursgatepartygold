﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Waf.Applications.Services;
using System.Waf.UnitTesting;

namespace Test.Waf.Applications.Services
{
    [TestClass]
    public class FileDialogServiceExtensionsTest
    {
        [TestMethod]
        public void ShowOpenFileDialogExtensionTest()
        {
            FileType rtfFileType = new FileType("RichText Document", ".rtf");
            FileType xpsFileType = new FileType("XPS Document", ".xps");
            IEnumerable<FileType> fileTypes = new FileType[] { rtfFileType, xpsFileType };
            string defaultFileName = "Document 1.rtf";
            FileDialogResult result = new FileDialogResult("Document 2.rtf", rtfFileType);

            object owner = new object();
            MockFileDialogService service = new MockFileDialogService();
            service.Result = result;

            Assert.AreEqual(result, service.ShowOpenFileDialog(rtfFileType));
            Assert.AreEqual(FileDialogType.OpenFileDialog, service.FileDialogType);
            Assert.AreEqual(rtfFileType, service.FileTypes.Single());
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowOpenFileDialog(null, rtfFileType));
            AssertHelper.ExpectedException<ArgumentNullException>(() => service.ShowOpenFileDialog((FileType)null));

            service.Clear();
            Assert.AreEqual(result, service.ShowOpenFileDialog(owner, rtfFileType));
            Assert.AreEqual(FileDialogType.OpenFileDialog, service.FileDialogType);
            Assert.AreEqual(owner, service.Owner);
            Assert.AreEqual(rtfFileType, service.FileTypes.Single());
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowOpenFileDialog(null, owner, rtfFileType));
            AssertHelper.ExpectedException<ArgumentNullException>(() => service.ShowOpenFileDialog(owner, (FileType)null));

            service.Clear();
            Assert.AreEqual(result, service.ShowOpenFileDialog(rtfFileType, defaultFileName));
            Assert.AreEqual(FileDialogType.OpenFileDialog, service.FileDialogType);
            Assert.AreEqual(rtfFileType, service.FileTypes.Single());
            Assert.AreEqual(defaultFileName, service.DefaultFileName);
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowOpenFileDialog(null, rtfFileType, defaultFileName));
            AssertHelper.ExpectedException<ArgumentNullException>(() => service.ShowOpenFileDialog((FileType)null, defaultFileName));

            service.Clear();
            Assert.AreEqual(result, service.ShowOpenFileDialog(owner, rtfFileType, defaultFileName));
            Assert.AreEqual(FileDialogType.OpenFileDialog, service.FileDialogType);
            Assert.AreEqual(owner, service.Owner);
            Assert.AreEqual(rtfFileType, service.FileTypes.Single());
            Assert.AreEqual(defaultFileName, service.DefaultFileName);
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowOpenFileDialog(null, owner, rtfFileType, defaultFileName));
            AssertHelper.ExpectedException<ArgumentNullException>(() => service.ShowOpenFileDialog(owner, (FileType)null, defaultFileName));

            service.Clear();
            Assert.AreEqual(result, service.ShowOpenFileDialog(fileTypes));
            Assert.AreEqual(FileDialogType.OpenFileDialog, service.FileDialogType);
            Assert.IsTrue(service.FileTypes.SequenceEqual(new FileType[] { rtfFileType, xpsFileType }));
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowOpenFileDialog(null, fileTypes));

            service.Clear();
            Assert.AreEqual(result, service.ShowOpenFileDialog(owner, fileTypes));
            Assert.AreEqual(FileDialogType.OpenFileDialog, service.FileDialogType);
            Assert.AreEqual(owner, service.Owner);
            Assert.IsTrue(service.FileTypes.SequenceEqual(new FileType[] { rtfFileType, xpsFileType }));
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowOpenFileDialog(null, owner, fileTypes));

            service.Clear();
            Assert.AreEqual(result, service.ShowOpenFileDialog(fileTypes, rtfFileType, defaultFileName));
            Assert.AreEqual(FileDialogType.OpenFileDialog, service.FileDialogType);
            Assert.IsTrue(service.FileTypes.SequenceEqual(new FileType[] { rtfFileType, xpsFileType }));
            Assert.AreEqual(rtfFileType, service.DefaultFileType);
            Assert.AreEqual(defaultFileName, service.DefaultFileName);
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowOpenFileDialog(null, fileTypes, rtfFileType, defaultFileName));
        }

        [TestMethod]
        public void ShowSaveFileDialogExtensionTest()
        {
            FileType rtfFileType = new FileType("RichText Document", ".rtf");
            FileType xpsFileType = new FileType("XPS Document", ".xps");
            IEnumerable<FileType> fileTypes = new FileType[] { rtfFileType, xpsFileType };
            string defaultFileName = "Document 1.rtf";
            FileDialogResult result = new FileDialogResult("Document 2.rtf", rtfFileType);

            object owner = new object();
            MockFileDialogService service = new MockFileDialogService();
            service.Result = result;

            Assert.AreEqual(result, service.ShowSaveFileDialog(rtfFileType));
            Assert.AreEqual(FileDialogType.SaveFileDialog, service.FileDialogType);
            Assert.AreEqual(rtfFileType, service.FileTypes.Single());
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowSaveFileDialog(null, rtfFileType));
            AssertHelper.ExpectedException<ArgumentNullException>(() => service.ShowSaveFileDialog((FileType)null));

            service.Clear();
            Assert.AreEqual(result, service.ShowSaveFileDialog(owner, rtfFileType));
            Assert.AreEqual(FileDialogType.SaveFileDialog, service.FileDialogType);
            Assert.AreEqual(owner, service.Owner);
            Assert.AreEqual(rtfFileType, service.FileTypes.Single());
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowSaveFileDialog(null, owner, rtfFileType));
            AssertHelper.ExpectedException<ArgumentNullException>(() => service.ShowSaveFileDialog(owner, (FileType)null));

            service.Clear();
            Assert.AreEqual(result, service.ShowSaveFileDialog(rtfFileType, defaultFileName));
            Assert.AreEqual(FileDialogType.SaveFileDialog, service.FileDialogType);
            Assert.AreEqual(rtfFileType, service.FileTypes.Single());
            Assert.AreEqual(defaultFileName, service.DefaultFileName);
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowSaveFileDialog(null, rtfFileType, defaultFileName));
            AssertHelper.ExpectedException<ArgumentNullException>(() => service.ShowSaveFileDialog((FileType)null, defaultFileName));

            service.Clear();
            Assert.AreEqual(result, service.ShowSaveFileDialog(owner, rtfFileType, defaultFileName));
            Assert.AreEqual(FileDialogType.SaveFileDialog, service.FileDialogType);
            Assert.AreEqual(owner, service.Owner);
            Assert.AreEqual(rtfFileType, service.FileTypes.Single());
            Assert.AreEqual(defaultFileName, service.DefaultFileName);
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowSaveFileDialog(null, owner, rtfFileType, defaultFileName));
            AssertHelper.ExpectedException<ArgumentNullException>(() => service.ShowSaveFileDialog(owner, (FileType)null, defaultFileName));

            service.Clear();
            Assert.AreEqual(result, service.ShowSaveFileDialog(fileTypes));
            Assert.AreEqual(FileDialogType.SaveFileDialog, service.FileDialogType);
            Assert.IsTrue(service.FileTypes.SequenceEqual(new FileType[] { rtfFileType, xpsFileType }));
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowSaveFileDialog(null, fileTypes));

            service.Clear();
            Assert.AreEqual(result, service.ShowSaveFileDialog(owner, fileTypes));
            Assert.AreEqual(FileDialogType.SaveFileDialog, service.FileDialogType);
            Assert.AreEqual(owner, service.Owner);
            Assert.IsTrue(service.FileTypes.SequenceEqual(new FileType[] { rtfFileType, xpsFileType }));
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowSaveFileDialog(null, owner, fileTypes));

            service.Clear();
            Assert.AreEqual(result, service.ShowSaveFileDialog(fileTypes, rtfFileType, defaultFileName));
            Assert.AreEqual(FileDialogType.SaveFileDialog, service.FileDialogType);
            Assert.IsTrue(service.FileTypes.SequenceEqual(new FileType[] { rtfFileType, xpsFileType }));
            Assert.AreEqual(rtfFileType, service.DefaultFileType);
            Assert.AreEqual(defaultFileName, service.DefaultFileName);
            AssertHelper.ExpectedException<ArgumentNullException>(() => FileDialogServiceExtensions.ShowSaveFileDialog(null, fileTypes, rtfFileType, defaultFileName));
        }
    }
}
