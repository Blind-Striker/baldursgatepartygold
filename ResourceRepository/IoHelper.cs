using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core
{
    public static class IoHelper
    {
        public static void CreateFile(string filePath, string content)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string directoryName = Path.GetDirectoryName(filePath);

                if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                fileStream = new FileStream(filePath, FileMode.Append);
                streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(content);
            }
            catch (Exception ex)
            {
                Exception ioException = new Exception("An error occured when Creating File", ex);
                ioException.Data.Add("Path", filePath);
                throw ioException;
            }
            finally
            {
                if (fileStream != null)
                {
                    if (streamWriter != null)
                        streamWriter.Close();
                    fileStream.Close();
                }
            }
        }

        public static void CreateFile(string filePath, Stream content)
        {
            FileStream fileStream1 = null;
            try
            {
                string directoryName = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                byte[] buffer = new byte[content.Length];
                content.Position = 0L;
                content.Read(buffer, 0, (int)content.Length);
                FileStream fileStream2;
                fileStream1 = fileStream2 = new FileStream(filePath, FileMode.Create);
                try
                {
                    fileStream1.Write(buffer, 0, buffer.Length);
                }
                finally
                {
                    fileStream2.Dispose();
                }
            }
            catch (Exception ex)
            {
                Exception ioException = new Exception("An error occured when Creating File", ex);
                ioException.Data.Add("Path", filePath);
                throw ioException;
            }
            finally
            {
                if (fileStream1 != null)
                {
                    fileStream1.Close();
                    fileStream1.Dispose();
                }
            }
        }

        public static void CreateFile(string filePath, byte[] content)
        {
            FileStream fileStream = null;
            BinaryWriter binaryWriter = null;
            try
            {
                string directoryName = Path.GetDirectoryName(filePath);

                if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                fileStream = new FileStream(filePath, FileMode.Create);
                binaryWriter = new BinaryWriter((Stream)fileStream);
                binaryWriter.Write(content);
            }
            catch (Exception ex)
            {
                Exception ioException = new Exception("An error occured when Creating File", ex);
                ioException.Data.Add("Path", filePath);
                throw ioException;
            }
            finally
            {
                if (fileStream != null)
                {
                    if (binaryWriter != null)
                        binaryWriter.Close();
                    fileStream.Close();
                }
            }
        }

        public static string ReadFile(string filePath)
        {
            StreamReader streamReader = null;
            string str;
            try
            {
                streamReader = new StreamReader(filePath);
                str = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Exception ioException = new Exception("An error occured when reading file", ex);
                ioException.Data.Add("Path", filePath);
                throw ioException;
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
            return str;
        }

        public static byte[] ReadBinaryFile(string filePath)
        {
            FileStream fileStream = null;
            BinaryReader binaryReader = null;
            byte[] numArray;
            try
            {
                long length = new FileInfo(filePath).Length;
                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                binaryReader = new BinaryReader(fileStream);
                numArray = binaryReader.ReadBytes((int)length);
            }
            catch (Exception ex)
            {
                Exception ioException = new Exception("An error occured when reading file", ex);
                ioException.Data.Add("Path", filePath);
                throw ioException;
            }
            finally
            {
                if (binaryReader != null)
                    binaryReader.Close();
                if (fileStream != null)
                    fileStream.Close();
            }
            return numArray;
        }

        public static FileSystemInfo GetFileSystemInfo(string path)
        {
            return !File.Exists(path) ? (!Directory.Exists(path) ? null : new DirectoryInfo(path)) : (FileSystemInfo)new FileInfo(path);
        }


        public static List<FileInfo> GetFileInfos(string path, string[] searchPatterns)
        {
            return GetFileInfos(path, searchPatterns, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Verilen dizindeki dosyanaların bilgilerini döndürür
        /// 
        /// </summary>
        /// <param name="path">Dizin</param><param name="searchPatterns">Arama Patterni</param><param name="searchOption">Arama Seçeneği</param>
        /// <returns/>
        public static List<FileInfo> GetFileInfos(string path, string[] searchPatterns, SearchOption searchOption)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            if (searchPatterns == null || searchPatterns.Length == 0)
                throw new ArgumentException("Search Pattern cannot be null or empty", "searchPatterns");
            List<FileInfo> list1;
            if (!Directory.Exists(path))
            {
                list1 = new List<FileInfo>(0);
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                List<FileInfo> list2 = new List<FileInfo>();
                for (int index = 0; index < searchPatterns.Length; ++index)
                {
                    string searchPattern = searchPatterns[index];
                    IEnumerable<FileInfo> collection = directoryInfo.GetFiles(searchPattern, searchOption).Select(f => f);
                    list2.AddRange(collection);
                }
                list1 = list2;
            }
            return list1;
        }

        public static void CheckAndCreateDirectory(string directoryPath)
        {
            string directoryName = Path.GetDirectoryName(directoryPath);
            if (Directory.Exists(directoryName))
                return;
            Directory.CreateDirectory(directoryName);
        }

        public static void CopyFolderToDestination(string source, string destination)
        {
            string[] files = Directory.GetFiles(source);

            // Copy the files and overwrite destination files if they already exist.
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
                string fileName = System.IO.Path.GetFileName(s);
                string destFile = System.IO.Path.Combine(destination, fileName);
                System.IO.File.Copy(s, destFile, true);
            }
        }
    }
}
