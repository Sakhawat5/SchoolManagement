using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Manager
{
    public class DepartmentManager
    {
        SchoolManagementEntities2 Db;
        public DepartmentManager()
        {
            Db = new SchoolManagementEntities2();
        }

        public void Add(Department department)
        {
            DbSet<Department> aDepartment = Db.Departments;
            aDepartment.Add(department);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            Department  department = Db.Departments.FirstOrDefault(x => x.Id == id);

            if(department != null)
            {
                Db.Departments.Remove(department);
                Db.SaveChanges();
            }

        }

        public List<Department> GetDepartments()
        {
            DbSet<Department> departments = Db.Departments;

            return Db.Departments.ToList();
        }
    }
}
