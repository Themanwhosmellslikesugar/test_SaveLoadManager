using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveLoad
{
    class Student: IWritableObject, IReadbleObject
    {
        private string FIO;
        private string group;
        private int mark;

        public Student(int read)
        {
            inputData();
        }
        public Student()
        {
          
        }
        Student(string fio, string groupC, int markC)
        {
            FIO = fio;
            group = groupC;
            mark = markC;
            //outputConsole();
        }
        public void outputConsole()
        {
            Console.WriteLine($"ФИО:{FIO}");
            Console.WriteLine($"Группа: {group}");
            Console.WriteLine($"Оценка за год: {mark}");
        }

        public void Write(SaveManager write)
        {
            write.WriteLine($"ФИО:{FIO}");
            write.WriteLine($"Группа:{group}");
            write.WriteLine($"Годовая оценка:{mark}");
            write.WriteStar();
            
        }
        public Student Read(string filename = null, LoadManager load = null)
        { 
            if(load == null)
            {
                load = new LoadManager(filename);
                load.BeginRead();
            }

            FIO = load.ReadLine().Split(':')[1];
            group = load.ReadLine().Split(':')[1];
            mark = int.Parse(load.ReadLine().Split(':')[1]);
            if (!load.IsLoading())
            {
                load.EndRead();
            }
            return new Student(FIO, group, mark);
        }
        public void inputData()
        {
            Console.WriteLine("Введите ФИО студента: ");
            FIO = Console.ReadLine();
            Console.WriteLine("Введите группу студента: ");
            group = Console.ReadLine();
            Console.WriteLine("Введите оценку за год: ");
            mark = int.Parse(Console.ReadLine());
        }
    }
}
