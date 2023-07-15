using Emp;
using tax;
using System.Text.Json;
using static Emp.Employee;

Console.WriteLine("Welcome to Employee Management System");
List<Employee> empList = new List<Employee>();
bool flag = false;
Console.WriteLine("Enter File Location: ");
string filePath = Console.ReadLine();
Console.WriteLine(filePath);
string jsonString = File.ReadAllText(filePath);
if (File.Exists(filePath))
{
    if (jsonString.Length != 0)
    {
        empList = JsonSerializer.Deserialize<List<Employee>>(jsonString)!;
    }
    else
    {
        Console.WriteLine("Empty File..");
    }
}
else
{
    Console.WriteLine("Invalid FilePath");
}



while (!flag){
    Console.WriteLine("--------------------------------------------------------------------------");
    Console.WriteLine("Enter Options"
                  +"\n1.Add Employee"
                  +"\n2.Display all Employee"
                  +"\n3.Get Employee by Id"
                  +"\n4.Compute Salary of an Employee."
                  +"\n5.Calculate total Cost to Company"
                  +"\n6.Delete Employee"
                  +"\n0.Exit");
    int choice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("--------------------------------------------------------------------------");
    switch (choice)
{
    case 1:
    //add emp
    //int id, string name,Department department,double salary
    Console.WriteLine("Enter employee Details");
    Console.WriteLine("\nEnter Employee ID");
    int empid = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\nEnter Employee name");
    string name = Console.ReadLine();
    Console.WriteLine("\nEnter Employee Dept (HR,SALES,ACCOUNTS)");
    string dept = Console.ReadLine().ToUpper();
    Console.WriteLine("\nEnter Salary: ");
    double salary = Convert.ToDouble(Console.ReadLine());
    //Department deptEn = Enum.Parse(Department,dept);
    empList.Add(new Employee(empid, name, salary,dept));
    Console.WriteLine("\nEmployee Added Successfully!!");
    break;

    case 2:
    //disp all emp
    empList.ForEach(delegate(Employee emp){
        Console.WriteLine(emp);
    });
    break;

    case 3:
    //get emp by id..
    Console.WriteLine("Enter Emp ID: ");
    int empid1 = Convert.ToInt32(Console.ReadLine());
    empList.ForEach(delegate(Employee emp){
            if(empid1 == emp.Id){
                Console.WriteLine(emp);
                return;
            }
    });
    break;

    case 4:
            Console.WriteLine("Enter Emp ID: ");
            int empid2 = Convert.ToInt32(Console.ReadLine());
            Tax tax = new Tax();
            TaxOperation txOp = new TaxOperation(tax.PayIncomeTax);
            TaxOperation txProf = new TaxOperation(tax.ProfessionalTax);
            TaxOperation txSer = new TaxOperation(tax.PayServiceTax);
            empList.ForEach(delegate (Employee emp) {
                if (empid2 == emp.Id)
                {

                    if (emp.dept.Equals(Department.HR))
                    {
                        emp.InHandSal = txOp(emp.Salary);
                        emp.InHandSal =  txProf(emp.Salary);
                        Console.WriteLine("Employee ID: " + emp.Id);
                        Console.WriteLine("Employee Name: " + emp.Name);
                        Console.WriteLine("Salary: "+emp.Salary);
                        Console.WriteLine("InHandSalary: " + emp.InHandSal);
                        Console.WriteLine("Total Taxes: " +( emp.Salary - emp.InHandSal));
                    }
                    else
                    {
                        emp.InHandSal = txSer(emp.Salary);
                        Console.WriteLine("Employee ID: " + emp.Id);
                        Console.WriteLine("Employee Name: " + emp.Name);
                        Console.WriteLine("Salary: " + emp.Salary);
                        Console.WriteLine("InHandSalary: " + emp.InHandSal);
                        Console.WriteLine("Total Taxes: " + (emp.Salary - emp.InHandSal));
                    }
                    return;
                }
            });


            break;

    case 5:
            //"\n5.Calculate total Cost to Company"
            double totalCost = 0;
            empList.ForEach(delegate (Employee emp)
            {
                totalCost = totalCost + emp.Salary;
            });
            Console.WriteLine("Total Cost to Company : " + totalCost);

            break;
    case 6:
            //delete
            Console.WriteLine("Enter Employee ID : ");
            int id =Convert.ToInt32(Console.ReadLine());
            Employee e = null;
            bool check = false;
            empList.ForEach(delegate (Employee emp)
            {
                if (emp.Id == id)
                {
                    e = emp;
                    check = true;
                    return;
                }
            });
            if (check)
            {
                empList.Remove(e);
                Console.WriteLine("Employee deleted successfully..");
            }
            else
            {
                Console.WriteLine("Employee not found..");
            }

            break;
    case 0:
            jsonString = JsonSerializer.Serialize(empList);
            File.WriteAllText(filePath, jsonString);
            flag = true;
    break;

    default:
    Console.WriteLine("Invalid Input");
    break;
}

}


