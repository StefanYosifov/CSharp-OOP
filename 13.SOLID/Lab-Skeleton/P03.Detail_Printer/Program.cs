using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> documents = new List<string>();


            IList<IEmployee> employees = new List<IEmployee>();
            IEmployee employee = new Employee("Gosho");
            employees.Add(employee);
            IEmployee manager = new Manager("Peter",documents);
            employees.Add(manager);

            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();

        }
    }
}
