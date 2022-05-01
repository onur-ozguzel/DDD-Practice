using DddInPractice.Logic.Management;
using DddInPractice.Logic.SharedKernel;
using DddInPractice.Logic.SnackMachines;
using DddInPractice.Logic.Utils;
using NHibernate;
using Xunit;

namespace DddInPractice.Tests
{
    public class TemporaryTests
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true");
            using (ISession session = SessionFactory.OpenSession())
            {
                var snackMachine = session.Get<SnackMachine>((long)1);
            }
        }

        [Fact]
        public void TestRepository()
        {
            SessionFactory.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true");
            using (ISession session = SessionFactory.OpenSession())
            {
                var repository = new SnackMachineRepository();
                var snackMachine = repository.GetById(1);
                snackMachine.InsertMoney(Money.Dollar);
                snackMachine.InsertMoney(Money.Dollar);
                snackMachine.InsertMoney(Money.Dollar);
                snackMachine.BuySnack(1);
                //repository.Save(snackMachine);
            }
        }

        [Fact]
        public void TestHeadOfficeInstance()
        {
            SessionFactory.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true");
            HeadOfficeInstance.Init();
            HeadOffice headOffice = HeadOfficeInstance.Instance;
        }
    }
}
