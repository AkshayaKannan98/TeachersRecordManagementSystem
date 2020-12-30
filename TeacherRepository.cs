using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;




namespace ConsoleApplication7
{
    class TeacherRepository
    {
        List<TeacherModel> teachers;

        public TeacherRepository()
        {
            this.teachers = new List<TeacherModel>{
                new TeacherModel {Id = 1, Name="Rachel", TClass = "English",Section = "A"},
                new TeacherModel {Id = 2, Name="Monica", TClass = "Maths",Section = "B"},
                new TeacherModel {Id = 3, Name="Phoebe", TClass = "Science",Section = "C"},
                new TeacherModel {Id = 4, Name="Amy", TClass = "Social",Section = "D"}
            };
        }

        public void StoreTeachers()
        {
            StreamWriter store = new StreamWriter("e:/Teachers.txt");

            foreach (TeacherModel t in teachers)
                store.WriteLine("{0} {1} {2} {3}", t.Id, t.Name, t.TClass, t.Section);
            store.Close();

            Console.WriteLine("Stored successfully");

        }

        public void GetAllTeachers()
        {
            StreamReader read = new StreamReader(@"e:/Teachers.txt");

            string message = read.ReadToEnd();
            Console.WriteLine(message);
            read.Close();
        }
         
        public TeacherModel GetTeacherById(int id)
        {
            TeacherModel t = null;
            for(int i = 0; i < teachers.Count; i++)
                if (teachers[i].Id == id)
                {
                    t = teachers[i];
                    break;
                }
            return t;
        }
        
        public List<TeacherModel> GetTeacherBySubject(string subject)
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            for (int i = 0; i < this.teachers.Count; i++) 
                if (this.teachers[i].TClass == subject)
                {
                     teachers.Add(this.teachers[i]);
                     break;
                }

            return teachers;
        }

        public List<TeacherModel> GetTeacherBySection(string section)
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            for (int i = 0; i < this.teachers.Count; i++)
                if (this.teachers[i].Section == section)
                {
                    teachers.Add(this.teachers[i]);
                    break;
                }

            return teachers;   
        }

        public void AddTeacher(TeacherModel t)
        {
            StreamWriter store = new StreamWriter ("e:/Teachers.txt",true);
            store.WriteLine("{0} {1} {2} {3}", t.Id, t.Name, t.TClass, t.Section);
            store.Close();
        }
        
        public void EditTeacher(int id,string n1,string n2)
        {
            StreamReader sr = new StreamReader("e:/Teachers.txt",true);
            string msg = sr.ReadToEnd();
            sr.Close();
            if (msg.Contains((char)id))
            {
                msg = Regex.Replace(msg, n1, n2);
                Console.WriteLine("The Row has been edited successfully");
            }
           
            StreamWriter fname = new StreamWriter("e:/Teachers.txt");
            fname.Write(msg);
            fname.Close();
           
           
        } 
        
    } 


}
