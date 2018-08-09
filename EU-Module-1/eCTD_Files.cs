using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace eCTD_indexer
{
    public class eCTD_Files
    {
        /// <summary>
        /// Counts the number of files of a given directory.
        /// </summary>
        /// <param name="path">path of the directory</param>
        /// <returns>number of files</returns>
        public int Count(String path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);

            // file counter
            int numberOfFiles = 0;

            if (dirs.Length > 0)
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    numberOfFiles = numberOfFiles + dirs[i].GetFiles().Length;
                }
            }

            return numberOfFiles;
        }
    }
}
