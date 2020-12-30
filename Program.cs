using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace ConsoleApplication7
{
    class Program
    {
        static TeacherRepository repository = new TeacherRepository();
        

        static void choice1()
        {
            repository.GetAllTeachers();
        }

        static void choice2()
        {
            Console.Write("Enter the id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            TeacherModel t = repository.GetTeacherById(id);
            if(t == null)
                Console.WriteLine("row does not exist");
            else
                Console.WriteLine("{0} {1} {2} {3}", t.Id, t.Name, t.TClass, t.Section);

        }  

        static void choice3()
        {
            Console.Write("Enter the subject : ");
            string subject = Console.ReadLine();

            List<TeacherModel> teachers = repository.GetTeacherBySubject(subject);

            foreach(TeacherModel t in teachers)
                Console.WriteLine("{0} {1} {2} {3}", t.Id, t.Name, t.TClass, t.Section);
        }
       
        static void choice4()
        {
            Console.Write("Enter the section : ");
            string section = Console.ReadLine();

            List<TeacherModel> teachers = repository.GetTeacherBySection(section);

            foreach (TeacherModel t in teachers)
                Console.WriteLine("{0} {1} {2} {3}", t.Id, t.Name, t.TClass, t.Section);
        }  

        static void choice5()
        {
            TeacherModel t = new TeacherModel();
            Console.Write("Enter id: ");
            t.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Name: ");
            t.Name = Console.ReadLine();
            Console.Write("Enter Class: ");
            t.TClass = Console.ReadLine();
            Console.Write("Enter Section: ");
            t.Section = Console.ReadLine();
            repository.AddTeacher(t);
        }

        

        

         static void choice6()
         {
             Console.Write("Enter the id : ");
             int id = Convert.ToInt32(Console.ReadLine());
             Console.Write("Enter n1:");
             string n1 = Console.ReadLine();
             Console.Write("Enter n2:");
             string n2 = Console.ReadLine();
             repository.EditTeacher(id, n1, n2);
         }


        static void Main()
        {
            repository.StoreTeachers();
            int ch;
            do
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1.Display all rows\n2.Display row by Id\n3.Display row by class\n4.Display row by section\n5.Add teacher\n6.Edit row\n7.Exit");
                Console.WriteLine("Enter choice : ");
                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                            choice1();
                        break;
                    
                    case 2:
                            choice2();
                        break; 

                    case 3:
                            choice3();
                         break;

                    case 4:
                            choice4();
                        break;

                    case 5:
                            choice5();
                        break;

                    

                    case 6:
                            choice6();
                        break;

                    case 7:
                        {
                            Console.WriteLine("Exited");
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("invalid input");
                            break;
                        }
                }
            }while(ch!=7);

            Console.ReadKey();
        }
    }
}
