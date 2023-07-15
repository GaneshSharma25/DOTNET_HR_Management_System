using tax;

namespace Emp;


public class HrManager : Employee
{
    public HrManager(int id, string name, double salary,string dept) : base(id, name, salary,dept)
    {
        base.Salary = salary * 10;
    }

    public double PayIncomeTax(double salary)
    {
         return salary*0.15;
    }

    public double PaySalesTax(double salary)
    {
        return salary*0.20;
    }

    public double PayServiceTax(double salary)
    {
        return salary*0.10;
    }

    public double ProfessionalTax(double salary)
    {
         return salary*0.03;
    }
}
