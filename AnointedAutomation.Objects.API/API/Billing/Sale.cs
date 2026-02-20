// Copyright © Anointed Automation, LLC., 2024. All Rights Reserved. Created by Alexander Fields https://www.alexanderfields.me on 2024-01-16 19:19:01
// Edited by Alexander Fields https://www.alexanderfields.me 2025-07-02 11:48:25
//Created by Alexander Fields

namespace AnointedAutomation.Objects.API.Billing
{
    public class Sale
    {
        public Sale(string UID, System.DateTime date, string menuItem, int soldQuantity, decimal totalSale)
        {
            this.UID = UID;
            this.date = date;
            MenuItem = menuItem;
            this.quantitySold = soldQuantity;
            this.totalSale = totalSale;
        }

        public Sale()
        {
        }

        public System.DateTime date
        {
            get; set;
        }

        public string MenuItem
        {
            get; set;
        }

        public int quantitySold
        {
            get; set;
        }

        public decimal totalSale
        {
            get; set;
        }

        public string UID
        {
            get; set;
        }
    }
}
