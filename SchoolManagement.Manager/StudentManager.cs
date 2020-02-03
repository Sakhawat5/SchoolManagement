using SchoolManagement.Model;
using SchoolManagement.Model.ViewSchoolModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Manager
{
    public class StudentManager
    {
        SchoolManagementEntities2 Db;

        public StudentManager()
        {
            Db = new SchoolManagementEntities2();
        }
        
        public void Add(Student student)
        {
            DbSet<Student> students = Db.Students;
            students.Add(student);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Student s = Db.Students.FirstOrDefault(x => x.Id == id);

            //Student s = (from student in Db.Students
                         //where student.Id == id
                         //select student).FirstOrDefault();
            if(s != null)
            {
                Db.Students.Remove(s);
                Db.SaveChanges();
            }
        }

        public Student GetStudentById(int id)
        {
            Student student = Db.Students.Find(id);

            return student;
        }

        public List<Student> GetStudents()
        {
            DbSet<Student> students = Db.Students;

            return students.ToList();
        }

        public List<ViewSchoolModel> GetViewSchoolModels()
        {
            DbSet<Student> students = Db.Students;
            DbSet<Department> departments = Db.Departments;
            DbSet<Course> courses = Db.Courses;

            var query =from s in students
            join d in departments on s.DepartmentId equals d.Id
            join c in courses on s.CourseId equals c.Id
            select new ViewSchoolModel
            {
                Id = s.Id,
                Name = s.Name,
                Phone = s.Phone,
                Address = s.Address,
                DepartmentId = d.Id,
                CourseId = c.Id
            };

            return query.ToList();
        }
    }
}
