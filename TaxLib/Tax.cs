using System;

namespace tax;

public class Tax
{
    public double PayIncomeTax(double salary)
    {
        Console.WriteLine("In PayIncomeTAX");
       /* Console.WriteLine("Income Tax Paid");
        Console.WriteLine(salary - salary * 0.1);*/
        return salary - salary * 0.1; 
    }
    public double PayServiceTax(double salary)
    {
        Console.WriteLine("Service Tax Paid");
        return salary - salary * 0.25;
    }
    public double ProfessionalTax(double salary)
    {
        return salary - salary * 0.15;
    }
    public double PaySalesTax(double salary)
    {
        return salary - salary * 0.08;
    }
}