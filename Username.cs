using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Username
    {
        private string Uname;
        private string role;

        public string Name
        {
            get
            {
                return Uname;
            }
            set
            {
                Uname = value;
            }
        }

        public string type
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }
    }
}