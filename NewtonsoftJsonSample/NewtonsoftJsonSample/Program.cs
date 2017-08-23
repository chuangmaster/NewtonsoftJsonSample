using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonsoftJsonSample
{
    class Program
    {
        static void Main(string[] args)
        {
            serializeJson();
            deserialize();
            Console.Read();
        }

        static void serializeJson()
        {
            List<Student> students = new List<Student>();
            Student a = new Student()
            {

                id = "tom",
                school = new School()
                {
                    major = "IM",
                    name = "ntpu"
                },
                exeam = new Exeam()
                {
                    subject = "C#",
                    score = 95
                }
            };
            Student b = new Student()
            {
                id = "mary",
                nickname = "kitty",
                school = new School()
                {
                    major = "IM",
                    name = "SHU"
                }
            };
            students.Add(a);
            students.Add(b);
            //Formatting.Indented 格式化Json資料，使他有排版，none則反之
            //new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore } 可以忽略掉物件內容是null的資料，使他在序列化為Json資料時，不被刻意輸出。
            Console.WriteLine(JsonConvert.SerializeObject(students, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }).ToString());
            Console.WriteLine(JsonConvert.SerializeObject(students, Formatting.None).ToString());
        }
        static void deserialize()
        {
            string sampleJson = @"[{""id"":""tom"",""nickname"":null,""exeam"":{""score"":95,""subject"":""C#""},""school"":{""name"":""ntpu"",""major"":""IM""}},{""id"":""mary"",""nickname"":""kitty"",""exeam"":null,""school"":{""name"":""SHU"",""major"":""IM""}}]";
            List<Student> GroupOfStudents = JsonConvert.DeserializeObject<List<Student>>(sampleJson);
            foreach (Student student in GroupOfStudents)
            {
                Console.WriteLine(string.Format("Student.id : {0}", student.id != null ? student.id : "NULL"));
                Console.WriteLine(string.Format("Student.nickname : {0}", student.nickname != null ? student.nickname : "NULL"));
                School school = student.school;
                if (school != null)
                {
                    Console.WriteLine(string.Format("School.name : {0}", school.name != null ? school.name : "NULL"));
                    Console.WriteLine(string.Format("School.major : {0}", school.major != null ? school.major : "NULL"));
                }
                Exeam exeam = student.exeam;
                if (exeam != null)
                {
                    Console.WriteLine(string.Format("Exeam.subject : {0}", exeam.subject != null ? exeam.subject : "NULL"));
                    Console.WriteLine(string.Format("Exeam.score : {0}", exeam.score != 0 ? exeam.score.ToString() : "NULL"));
                }
                Console.WriteLine("======================");
            }
        }
    }
    public class School
    {
        public string name { get; set; }
        public string major { get; set; }
    }
    public class Student
    {
        public string id { get; set; }
        public string nickname { get; set; }
        public Exeam exeam { get; set; }
        public School school { get; set; }
    }

    public class Exeam
    {
        public int score { get; set; }
        public string subject { set; get; }
    }
}
