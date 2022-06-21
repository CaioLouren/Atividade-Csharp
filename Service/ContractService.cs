using Entities;
using System;

namespace Service
{
    internal class ContractService
    {
        private IPaymentOnline _paymentOnline;

        public ContractService(IPaymentOnline paymentOnline)
        {
            _paymentOnline = paymentOnline;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double parcela = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                
                DateTime dateTime = contract.Date.AddMonths(i);
                double result1 = parcela + _paymentOnline.Interest(parcela, i);
                double result2 = result1 + _paymentOnline.PaymentFee(result1);
               
                contract.Installments.Add( new Installment(dateTime, result2));
            }

        }
    }
}
