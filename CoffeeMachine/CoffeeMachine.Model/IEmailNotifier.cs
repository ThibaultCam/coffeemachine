﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public interface IEmailNotifier
    {
        void NotifyMissingDrink(String drink);
    }
}
