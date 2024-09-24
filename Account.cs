using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank
{

    public class Account
    {


        public string name;
        public string pin;

        private int _balance = 0;



        public int CheckBalance()
        {
            return _balance;
        }

        public void Deposit(int amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }
        }

        public bool WithDraw(int amount)
        {
            if (amount > 0 && amount <= _balance)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }


    }


}