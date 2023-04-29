using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace DDDInPractice.Logic
{
    public class SnackMachineMap : ClassMap<sanckMachine>
    {
        public SnackMachineMap()
        {
            Id(x => x.Id);
            Component(x => x.MoneyInside, y =>
            { 
            y.Map(x=>x.OneCentCount);
            y.Map(x=>x.TenCentCount);
            y.Map(x=>x.QuarterCount);
            y.Map(x=>x.OneDollarCOunt);
            y.Map(x=>x.TenDollarCount);
            y.Map(x => x.TwentyDollarCount);
        });
        }
    }
}