using SchoolManagement.Manager;
using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolManagement.RestService.Controllers
{
    public class DepartmentController : ApiController
    {
        SchoolManagementEntities2 Db = new SchoolManagementEntities2();

        public List<Department> Get()
        {
            DepartmentManager managerDept = new DepartmentManager();

            List<Department> departments = managerDept.GetDepartments();

            return departments.ToList();
        }

        public bool Post(Department department)
        {
            DepartmentManager managerDept = new DepartmentManager();
            
            managerDept.Add(department); 

            return true;
        }


    }
}
