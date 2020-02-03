using SchoolManagement.Manager;
using SchoolManagement.Model;
using SchoolManagement.Model.ViewSchoolModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student() { Name = "abc", Phone = "123", Address = "Comilla", DepartmentId = 1, CourseId = 2 };
            StudentManager aManage = new StudentManager();

            //aManage.Add(student);

            //Console.WriteLine("Data Save");

            //--------------
            //List<Student> students = aManage.GetStudents();
            //foreach(var item in students)
            //{
            //    Console.WriteLine(item.Name+""+item.Phone+" "+item.Address);
            //}
            //----------------

            #region Department
            //DepartmentManager departmentManager = new DepartmentManager();

            //List<Department> departments = departmentManager.GetDepartments();

            //foreach (var item in departments)
            //{
            //    Console.WriteLine(item.DepartmentName);
            //}
            #endregion


            List<ViewSchoolModel> viewSchoolModels = aManage.GetViewSchoolModels();

            foreach (var item in viewSchoolModels)
            {
                Console.WriteLine(item.Name+" "+ item.Phone+" "+item.Address+" "+item.DepartmentId+" "+item.CourseId);
            }
            

            Console.ReadKey();
        }
    }
}
