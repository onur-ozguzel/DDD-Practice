using DddInPractice.Logic.Common;
using DddInPractice.Logic.Utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DddInPractice.Logic.Atms
{
    public class AtmRepository : Repository<Atm>
    {
        public IReadOnlyList<AtmDto> GetAtmList()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Atm>()
                    .ToList()
                    .Select(s => new AtmDto(s.Id, s.MoneyInside.Amount))
                    .ToList();
            }
        }
    }
}
