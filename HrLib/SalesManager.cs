using tax;

namespace Emp;

public class SalesManager : Employee
{
     public SalesManager(int id, string name, double salary, string dept) : base(id, name, salary, dept)
    {
        base.Salary = salary * 10;
    }

}