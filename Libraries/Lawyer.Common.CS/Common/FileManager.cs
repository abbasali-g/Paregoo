using System;
using System.Collections.Generic;
 
using System.Text;
using System.IO;

namespace Lawyer.Common.CS.Common
{
    class FileManager
    {

        public static String GetFileFromBinaryFormat(Byte[] binaryFile, string filefullName, bool ignoreExist)
        {
            if (!ignoreExist)
            {
                if (System.IO.File.Exists(filefullName))
                {
                    return filefullName;
                }
            }
            FileStream fs;

            Int32 fileSize = binaryFile.Length;

            String Path = filefullName;

            fs=new  FileStream(Path, FileMode.Create, FileAccess.Write);

            fs.Write(binaryFile, 0, fileSize);

            fs.Close();

            return Path;
        }

 
    }
}
