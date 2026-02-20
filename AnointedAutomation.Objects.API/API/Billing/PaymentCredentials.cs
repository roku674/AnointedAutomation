// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

namespace AnointedAutomation.Objects.API.Billing
{
    public class PaymentCredentials
    {
        public PaymentCredentials()
        {
        }

        public PaymentCredentials(PaymentType paymentType)
        {
            this.paymentType = paymentType;
        }

        public CreditCard CreditCard
        {
            get; set;
        }

        public PayeeInfo PayeeInfo
        {
            get; set;
        }

        public PaymentType paymentType
        {
            get; set;
        }
    }
}
