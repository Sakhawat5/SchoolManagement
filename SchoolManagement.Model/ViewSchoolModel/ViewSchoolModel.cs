using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.ViewSchoolModel
{
    public class ViewSchoolModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }

    }
}
