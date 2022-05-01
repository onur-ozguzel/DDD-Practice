using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DddInPractice.Logic.SnackMachines
{
    public class SnackMap : ClassMap<Snack>
    {
        public SnackMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
