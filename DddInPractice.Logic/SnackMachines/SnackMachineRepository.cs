using DddInPractice.Logic.Common;
using DddInPractice.Logic.SharedKernel;
using DddInPractice.Logic.Utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DddInPractice.Logic.SnackMachines
{
    public class SnackMachineRepository : Repository<SnackMachine>
    {
        public IReadOnlyList<SnackMachine> GetAllWithSnack(Snack snack)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SnackMachine> GetAllWithMoneyInside(Money money)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<SnackMachineDto> GetSnackMachineList()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<SnackMachine>()
                    .ToList()
                    .Select(x => new SnackMachineDto(x.Id, x.MoneyInside.Amount))
                    .ToList();
            }
        }
    }
}
