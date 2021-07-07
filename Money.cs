using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Money
    {
        private double money;

        public double amount
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
    }
}