using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15Tasks
{
    public static class Task15_4_2
    {
        public static void GroupDepsWithEmployees(List<Department> departments, List<Employee> employees)
        {
            var depsWithEmployees = departments.GroupJoin(employees,
                d => d.Id,
                e => e.DepartmentId,
                (d, emp) => new
                {
                    DepartmentName = d.Name,
                    Employees = emp.Select(e => e.Name)
                });

            foreach (var dep in depsWithEmployees)
            {
                Console.WriteLine($"{dep.DepartmentName}:");

                foreach(string eployee in dep.Employees)
                    Console.WriteLine(eployee);

                Console.WriteLine();
            }
        }
    }
}
