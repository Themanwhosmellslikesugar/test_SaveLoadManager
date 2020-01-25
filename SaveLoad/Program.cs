using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> student;
            int i;
            string filename;
            int answerUser;
            Console.WriteLine("Что сделать: 1 - записать новые данные и сохранить их, 2 - прочитать данные в файлах");
            answerUser = int.Parse(Console.ReadLine());
            switch (answerUser)
            {
                case 1:
                    Console.WriteLine("Введите название файла, в который сохранить данные о студентах");
                    filename = Console.ReadLine();
                    SaveManager save = new SaveManager(filename);
                    Console.WriteLine("Вы хотите удалить предыдущие файлы? 1 - да");
                    answerUser = int.Parse(Console.ReadLine());
                    if (answerUser == 1)
                    {
                        save.cleanFiles(save.directory);
                    }

                    createListStudent();
                    i = 0;
                    foreach (var val in student)
                    {
                        student[i].Write(save);
                        i++;
                    }
                    void createListStudent()
                    {
                        int answer = 0;
                        student = new List<Student>();
                        do
                        {
                            student.Add(new Student(answer));
                            Console.WriteLine("Продолжить? 0 - нет");
                            answer = int.Parse(Console.ReadLine());

                        } while (answer != 0);
                    }


                    Console.WriteLine("Ваши данные успешно сохранены");
                    break;
                case 2:
                    Console.WriteLine("Какой файл прочитать? При введение пустого значения считаются все файлы");
                    string filePathForRead = Console.ReadLine();
                    LoadManager load = new LoadManager(filePathForRead);
                    Student st = new Student();
                    st.Read(filePathForRead);
                    st.outputConsole();

                    break;
                default:
                    Console.WriteLine("ERROR!!!!!!!!!!!!!");
                    break;
            }
            Console.ReadKey();

        }
    }
}
