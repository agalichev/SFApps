using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_4_1
    {
        public static void ShowEmploeeAndDepartment(List<Employee> employees, List<Department> departments)
        {
            var employeeAndDepartment = employees.Join(departments,
                e => e.DepartmentId,
                d => d.Id,
                (e, d) => new
                {
                    EmployeeName = e.Name,
                    DepartmentName = d.Name
                });

            foreach (var employee in employeeAndDepartment)
                Console.WriteLine($"Сотрудник: {employee.EmployeeName}, отдел: {employee.DepartmentName}");
        }
    }
}
