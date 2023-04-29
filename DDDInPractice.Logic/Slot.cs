using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public class Slot : Entity
    {
        public virtual Snack Snack { get; set; }
        public virtual int Quantity {get; set; }
        public virtual decimal Price { get; set; }
        public virtual sanckMachine SnackMachine {get; protected set; }
        public virtual int Position { get; protected set; }

        protected Slot() 
          {

          }
        
        public Slot (sanckMachine snack_Machine, int position, Snack snack, int quantity, decimal price)
        : this()
        {
            SnackMachine = snack_Machine;
            Position = position;
            Snack = snack;
            Quantity = quantity;
            Price = price;
        }
    }
}