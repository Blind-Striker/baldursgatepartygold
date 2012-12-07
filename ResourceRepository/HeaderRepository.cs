using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MvpVmSample.Core.Foundation;
using MvpVmSample.Core.InfinityModel;

namespace MvpVmSample.Infinity.ResourceRepository
{
    public class HeaderRepository : IHeaderRepository
    {
        public Header GetHeader(string savePath)
        {
            //if (String.IsNullOrEmpty(savePath))
            //{
            //    // TODO: do something
            //}

            //try
            //{
            //    string savefile = Path.Combine(savePath, "BALDUR.GAM");

            //    byte[] content = IoHelper.ReadBinaryFile(savefile);

            //    IntPtr unmanagedPointer = Marshal.AllocHGlobal(content.Length);
            //    Marshal.Copy(content, 0, unmanagedPointer, content.Length);

            //    Header header = (Header)Marshal.PtrToStructure(unmanagedPointer, typeof(Header));

            //    Marshal.FreeHGlobal(unmanagedPointer);

            //    return header;
            //}
            //catch (Exception ex)
            //{
            //    throw new ResourceReaderException("An error occured when reading file", ex);
            //}

            return new Header();
        }

        public void SaveHeader(string destinationPath, uint partyGold)
        {
            //if (String.IsNullOrEmpty(destinationPath))
            //{
            //    // TODO: do something
            //}

            //try
            //{
            //    string savefile = Path.Combine(destinationPath, "BALDUR.GAM");

            //    byte[] content = IoHelper.ReadBinaryFile(savefile);

            //    IntPtr unmanagedPointer = Marshal.AllocHGlobal(content.Length);
            //    Marshal.Copy(content, 0, unmanagedPointer, content.Length);

            //    Header header = (Header)Marshal.PtrToStructure(unmanagedPointer, typeof(Header));

            //    header.PartyGold = partyGold;

            //    int sizeOfHeader = Marshal.SizeOf(header);

            //    byte[] headerContent = new byte[sizeOfHeader];
            //    IntPtr headerPtr = Marshal.AllocHGlobal(sizeOfHeader);

            //    Marshal.StructureToPtr(header, headerPtr, true);
            //    Marshal.Copy(headerPtr, headerContent, 0, sizeOfHeader);

            //    Marshal.FreeHGlobal(headerPtr);

            //    WriteToBytes(headerContent, content, 0);

            //    IoHelper.CreateFile(savefile, content);
            //}
            //catch (Exception ex)
            //{
            //    throw new ResourceReaderException("An error occured when reading file", ex);
            //}
        }
    }
}
