namespace Emp;
using tax;

public  class Employee{
    public int Id { get; set;}
    public string Name { get; set;} = string.Empty;
    public double Salary { get; set;}

    public double InHandSal { get; set;}

    //public Department Dept { get; set;}
    public enum Department
    {
        HR,
        SALES
    }
    public Department dept;

    public Employee(){

    }

    public  Employee(int id, string name,double salary,string dept1){

        Enum.TryParse(dept1, out Department deptNew);
        this.Id = id;
        this.Name = name;
        this.dept = deptNew;
        this.Salary = salary;
        this.InHandSal = 0;
        /*Tax tax = new Tax();

        TaxOperation txOp = new TaxOperation(tax.PayIncomeTax);
        TaxOperation txProf = new TaxOperation(tax.ProfessionalTax);
        TaxOperation txSer = new TaxOperation(tax.PayServiceTax);
        */
       /* if (deptNew.Equals(Department.HR))
        {
            salary = txOp(salary);
            salary = txProf(salary);
        }
        else
        {
            salary = txSer(salary);
        }*/
    }

    public override string ToString()
    {
        return $"EMP ID: {this.Id} , NAME: {this.Name}, Department: {this.dept} ,Salary: {this.Salary}";
    }

    


    // public abstract double ComputeSal(double salary);


}