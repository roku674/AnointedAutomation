// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

namespace AnointedAutomation.Objects.API.Billing
{
    public class CreditCard
    {
        public CreditCard(string cardNumber, string cardHolderName, System.DateTime expirationDate, int cvv)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            this.expirationDate = expirationDate;
            this.cvv = cvv;
        }

        public CreditCard()
        {
        }

        public string CardHolderName
        {
            get; set;
        }

        public string CardNumber
        {
            get; set;
        }

        public int cvv
        {
            get; set;
        }

        public System.DateTime expirationDate
        {
            get; set;
        }

        public bool IsValid()
        {
            return System.DateTime.Now < expirationDate;
        }

        // Add other methods as needed, e.g. for validating card numbers, checking card types, etc.
    }
}
