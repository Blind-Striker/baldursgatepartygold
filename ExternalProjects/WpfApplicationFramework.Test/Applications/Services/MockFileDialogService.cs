using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications.Services;

namespace Test.Waf.Applications.Services
{
    public class MockFileDialogService : IFileDialogService
    {
        public FileDialogResult Result { get; set; }

        public object Owner { get; private set; }

        public FileDialogType FileDialogType { get; private set; }

        public IEnumerable<FileType> FileTypes { get; private set; }

        public FileType DefaultFileType { get; private set; }

        public string DefaultFileName { get; private set; }


        public FileDialogResult ShowOpenFileDialog(object owner, IEnumerable<FileType> fileTypes, FileType defaultFileType, string defaultFileName)
        {
            FileDialogType = FileDialogType.OpenFileDialog;
            Owner = owner;
            FileTypes = fileTypes;
            DefaultFileType = defaultFileType;
            DefaultFileName = defaultFileName;
            return Result;
        }

        public FileDialogResult ShowSaveFileDialog(object owner, IEnumerable<FileType> fileTypes, FileType defaultFileType, string defaultFileName)
        {
            FileDialogType = FileDialogType.SaveFileDialog;
            Owner = owner;
            FileTypes = fileTypes;
            DefaultFileType = defaultFileType;
            DefaultFileName = defaultFileName;
            return Result;
        }

        public void Clear()
        {
            Owner = null;
            FileDialogType = FileDialogType.None;
            FileTypes = null;
            DefaultFileType = null;
            DefaultFileName = null;
        }
    }



    public enum FileDialogType
    {
        None,
        OpenFileDialog,
        SaveFileDialog
    }
}
