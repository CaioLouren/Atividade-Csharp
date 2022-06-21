using Entities;
using Service;
using System;
using System.Globalization;

namespace Interface
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int month = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue);
            Console.WriteLine("Installments:");

            ContractService contractService = new ContractService(new PayPalService());
            contractService.ProcessContract(contract, month);

            foreach(Installment installment in contract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}