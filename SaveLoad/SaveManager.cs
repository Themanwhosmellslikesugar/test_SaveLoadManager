using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SaveLoad
{
    class SaveManager
    {
        FileInfo file;
        public DirectoryInfo directory;
        public SaveManager(string filename)
        {
            createDirectory();
            file = new FileInfo($@"MAIN//{filename}.txt");
            file.CreateText().Close();
        }

        public void WriteLine(string line)
        {
            StreamWriter sw = file.AppendText();
            sw.WriteLine(line);
            sw.Close();
        }
        public void WriteStar()
        {
            StreamWriter sw = file.AppendText();
            sw.WriteLine("*********************************");
            sw.Close();
        }
        public void WriteObject(IWritableObject obj)
        {
            obj.Write(this);
        }
        void createDirectory()
        {
            directory = Directory.CreateDirectory("MAIN");
        }
        public void cleanFiles(DirectoryInfo dir)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                f.Delete();
            }

        }
    }
}
