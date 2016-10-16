using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferWithCSharpConsoleApp
{
    class Program
    {
        // Program:
        // Detects Files in Origination Folder
        // Tests if files are a text document
        // Test if Files are new/or modified within past 24 hours
        // Copies modified files to destination directory
        // Specification "file check" and "file copy" performed
        // outside of "Main" method and called from within "Main"
        static void Main(string[] args)
        {
             // NOTE CHANGE FILES PATHS BELOW TO SOURCE AND DESTINATION
            string sReadPath = "C:\\Users\\Owner\\Desktop\\Folder A";
            string sWritePath = "C:\\Users\\Owner\\Desktop\\Folder B";
            // Change value below to edit length of time -- Default to 24 hours
            int iTimePeriod = 86400;
            int iFileCount = 0;

            Program prog = new Program();

            // Get List of Files modified within specified time period
            string sFileList = prog.GetEditedFiles(sReadPath, iTimePeriod);
            DateTime copyTime = DateTime.Now;
            if (sFileList != "")
            {
                // Copy Files that have changed in the time period
                iFileCount = prog.CopyFiles(sWritePath);
            }
            else
            {
                // Report to user that no files have been modified
                Console.Write("None of the files in " + sReadPath + " have been modified since " + "\n \n");
            }

            if (iFileCount > 0)
            {
                // Report to user Files that were copied and the time they were copied.
                
            }
            else
            {
                // If the files fail to copy report that to the user
                Console.Write("No files were copied from " + sReadPath + " to " + sWritePath + "\n \n");
            }
        }


        public string GetEditedFiles(string sWritePath, int timePeriod)
        {
            // FileInfo.LastWriteTime and  FileInfo.LastWriteTimeUtc
            string sFileList = "";


            return sFileList;
        }


        public int CopyFiles(string sWritePath)
        {

            

            return 0;
        }
    }
}
