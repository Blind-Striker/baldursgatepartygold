using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MvpVmSample.Core.Foundation;
using MvpVmSample.Core.InfinityModel;
using MvpVmSample.Presentation.PartyGoldEditor.Core;

namespace MvpVmSample.Infinity.ResourceRepository
{
    public class HeaderRepository : IHeaderRepository
    {
        public Header GetHeader(string savePath)
        {
            if (String.IsNullOrEmpty(savePath))
            {
                // TODO: do something
            }

            try
            {
                string savefile = Path.Combine(savePath, "BALDUR.GAM");

                byte[] content = IoHelper.ReadBinaryFile(savefile);

                IntPtr unmanagedPointer = Marshal.AllocHGlobal(content.Length);
                Marshal.Copy(content, 0, unmanagedPointer, content.Length);

                Header header = (Header)Marshal.PtrToStructure(unmanagedPointer, typeof(Header));

                Marshal.FreeHGlobal(unmanagedPointer);

                return header;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when reading file", ex);
            }
        }

        public string SaveHeader(string currentSavePath, uint partyGold)
        {
            if (String.IsNullOrEmpty(currentSavePath))
            {
                // TODO: do something
            }

            string destinationPath = String.Format("{0}-{1}", currentSavePath, DateTime.Now.Ticks);

            try
            {
                Directory.CreateDirectory(destinationPath);

                IoHelper.CopyFolderToDestination(currentSavePath, destinationPath);

                string savefile = Path.Combine(destinationPath, "BALDUR.GAM");

                byte[] content = IoHelper.ReadBinaryFile(savefile);

                IntPtr unmanagedPointer = Marshal.AllocHGlobal(content.Length);
                Marshal.Copy(content, 0, unmanagedPointer, content.Length);

                Header header = (Header)Marshal.PtrToStructure(unmanagedPointer, typeof(Header));

                header.PartyGold = partyGold;

                int sizeOfHeader = Marshal.SizeOf(header);

                byte[] headerContent = new byte[sizeOfHeader];
                IntPtr headerPtr = Marshal.AllocHGlobal(sizeOfHeader);

                Marshal.StructureToPtr(header, headerPtr, true);
                Marshal.Copy(headerPtr, headerContent, 0, sizeOfHeader);

                Marshal.FreeHGlobal(headerPtr);

                WriteToBytes(headerContent, content, 0);

                IoHelper.CreateFile(savefile, content);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured when reading file", ex);
            }

            return destinationPath;
        }

        private void WriteToBytes(byte[] source, byte[] to, int toStartIndex)
        {
            if (source == null)
                throw new Exception("WriteToBytes için geçersiz parametre gönderdiniz", new ArgumentNullException("source"));
            if (to == null)
                throw new Exception("WriteToBytes için geçersiz parametre gönderdiniz", new ArgumentNullException("to"));
            if (toStartIndex < 0)
                throw new Exception("WriteToBytes için geçersiz parametre gönderdiniz", new ArgumentOutOfRangeException("toStartIndex"));
            if (source.Length > to.Length || source.Length > to.Length - toStartIndex)
                throw new Exception("Source'u to'ya yazıcak yer yok");
            try
            {
                int index1 = 0;
                int index2 = toStartIndex;
                while (index1 < source.Length)
                {
                    to[index2] = source[index1];
                    ++index1;
                    ++index2;
                }
            }
            catch (Exception ex)
            {
                Exception ioLibException = new Exception("WriteToBytes işlemini gerçekleştirilirken bir hata oluştur", ex);
                ioLibException.Data.Add("SourceBytesLenghth", source.Length);
                ioLibException.Data.Add("ToBytesLenghth", to.Length);
                ioLibException.Data.Add("ToStartIndex", toStartIndex);
            }
        }
    }
}
