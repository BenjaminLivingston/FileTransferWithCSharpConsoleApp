using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferWithCSharpConsoleApp
{
    class Program
    {
        // Program is a console application that:
        // - Detects Files in Origination Folder
        // - Tests if files are a text document
        // - Test if Files are new/or modified within past 24 hours
        // - Copies modified files to destination directory
        // Specification: "file check" and "file copy" performed
        //      outside of "Main" method and called from within "Main"
        // Note: console messages are optional and can be commented.
        static void Main(string[] args)
        {
             // NOTE CHANGE FILES PATHS BELOW TO SOURCE AND DESTINATION DIRECTORIES
            string sReadPath = "C:\\Users\\Owner\\Desktop\\Folder A";
            string sWritePath = "C:\\Users\\Owner\\Desktop\\Folder B";
            // Change value below to edit length of time -- Default to 24 hours
            TimeSpan timePeriod = new TimeSpan(24,0,0);
            int iFileCount = 0;

            Program prog = new Program();

            // Get List of Files modified within specified time period
            DateTime currTime = DateTime.Now;
            DateTime copyTime = (currTime - timePeriod);
            List<string> sFileList = prog.GetEditedFiles(sReadPath, copyTime);
            if (sFileList.Count == 0)
            {
                // Report to user that no files have been modified
                Console.Write("None of the files in " + sReadPath + "\n" +
                    " have been modified since " +
                    copyTime.ToString("HH:mm MM/dd/yyyy") +
                    "\n \n");
            }
            else
            {
                // Copy Files that have changed in the time period
                iFileCount = prog.CopyFiles(sFileList.ToArray(), sReadPath, sWritePath);
            }

            if (iFileCount > 0)
            {
                // Report to user Files that were copied and the time they were copied.
                Console.Write(iFileCount.ToString("#,###") + 
                    " files were copied at " + 
                    currTime.ToString("HH:mm MM/dd/yyyy"));
            }
            else
            {
                // If the files fail to copy report that to the user
                Console.Write("No files were copied from " + sReadPath + "\n" + 
                    " to " + sWritePath + "\n \n");
            }
            // Enforces user to be able to see console messages. Can be commented out.
            Console.Read();
        }



        public List<string> GetEditedFiles(string sWritePath, DateTime copyTime)
        {
            List<string> sCopyList = new List<string>();
            try
            {
                string[] files = Directory.GetFiles(sWritePath);
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Extension == ".txt" || fi.Extension == ".text")
                    {
                        if (fi.LastWriteTime > copyTime)
                        {
                            sCopyList.Add(fi.Name.ToString());
                            Console.Write(fi.Name.ToString() + "\n" +
                                "was last modifed at " +
                                fi.LastWriteTime.ToString("HH:mm MM/dd/yyyy" + "\n\n"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking files: " + ex.ToString());
            }
            return sCopyList;
        }


        public int CopyFiles(string[] sFileList, string sReadPath, string sWritePath)
        {
            int iFilesCopied = 0;

            try
            {
                foreach (string f in sFileList)
                {
                    File.Copy(sReadPath + "\\" + f, sWritePath + "\\" + f, true);
                    iFilesCopied = iFilesCopied + 1;
                }
            }
            catch (Exception e)
            {
                Console.Write("Error copying files: " + e.ToString());
            }

            return iFilesCopied;
        }
    }
}
