﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class EmailNotifier : IEmailNotifier
    {
        public void NotifyMissingDrink(string drink)
        {
            // send a mail
        }
    }
}
