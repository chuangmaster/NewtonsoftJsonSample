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
