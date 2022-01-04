using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OL_1;

namespace System.IO
{
    
    class Program
    {
        private static readonly string DBName = "Stream";
        static void Main(string[] args)
        {

            string source = @"C:\Users\User\Desktop\TestFile";
            string destination = @"C:\destination";
            DateTime date = new DateTime(2021, 12, 20);

            if (Directory.GetFiles(source).Length > 0)
            {
                string[] files = Directory.GetFiles(source);

                foreach (string file in files)
                {
                    if (Directory.GetLastAccessTime(file) > date)
                    {
                        string fileName = Path.GetFileName(file);
                        string destFile = Path.Combine(destination, fileName);
                        File.Move(file, destFile);
                        Console.WriteLine(file);
                    }
                    else
                    {
                        Console.WriteLine($"\tTransfering \"{file}\" Was Denied\nFile \"{file}\" was last modified - {Directory.GetLastAccessTime(file)}.\n" +
                            $"Files you need must be last modified - {date} - or sooner\n");
                    }
                }
            }
            else
            {
                Console.WriteLine($"\"{source}\" folder is Empty!\n");
            }




        }
    }

  
    public class Test : IDisposable
    {
        private MemoryStream _mST;

        public Test(MemoryStream st)
        {
            _mST = st;
        }
        public void Dispose()
        {
            _mST.Dispose();
        }
    }
}
