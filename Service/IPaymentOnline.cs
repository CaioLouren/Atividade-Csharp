using System;
using Entities;

namespace Service
{
    interface IPaymentOnline
    {
        public double PaymentFee(double amount);
        public double Interest(double amount, int months);


    }
}
