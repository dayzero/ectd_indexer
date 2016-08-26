using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace eCTD_indexer.XML
{
    public class MD5
    {
        /// <summary>
        /// Return the MD5 hash value.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public String Calculate(String file)
        {
            MD5Calculator checksum = new MD5Calculator();
            return checksum.ComputeMD5Checksum(file);
        }

        /// <summary>
        /// Saves the MD5 hash value of "file" in "md5file"
        /// </summary>
        /// <param name="file"></param>
        /// <param name="md5file">path & filename</param>
        public void Save(String file, String md5file)
        {
            StreamWriter indexmd5 = File.CreateText(md5file);
            indexmd5.WriteLine(this.Calculate(file));
            indexmd5.Close();
        }
    }
}
