using Newtonsoft.Json;
using SchoolManagement.Manager;
using SchoolManagement.Model;
using SchoolManagement.Model.ViewSchoolModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolManagement.RestService.Controllers
{
    public class StudentController : ApiController
    {
        public List<ViewSchoolModel> Get()
        {
            StudentManager manager = new StudentManager();
            List<ViewSchoolModel> students = manager.GetViewSchoolModels();

            return students;
        }

        public List<Student> Get(string request)
        {
            StudentManager studentManager = new StudentManager();
            int id = JsonConvert.DeserializeObject<int>(request);
            Student students = studentManager.GetStudentById(id);
            return new List<Student> { students };
        }

        public bool post(Student student)
        {
            StudentManager manager = new StudentManager();
            manager.Add(student);

            return true;
        }

        public bool Delete(string request)
        {
            StudentManager studentManager = new StudentManager();
            int id = JsonConvert.DeserializeObject<int>(request);
            studentManager.Delete(id);

            return true;
        }
    }
}
