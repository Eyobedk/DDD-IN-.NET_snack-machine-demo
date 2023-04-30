using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public class Slot : Entity
    {
        public virtual SnackPile SnackPile { get; set; }
        public virtual sanckMachine SnackMachine {get; protected set; }
        public virtual int Position { get; protected set; }

        protected Slot() 
          {

          }
        
        public Slot (sanckMachine snack_Machine, int position)
        : this()
        {
            SnackMachine = snack_Machine;
            Position = position;
            SnackPile = new SnackPile(null, 0,0m);
        }
    }
}