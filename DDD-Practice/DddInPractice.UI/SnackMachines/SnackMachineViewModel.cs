﻿using DddInPractice.Logic.SharedKernel;
using DddInPractice.Logic.SnackMachines;
using DddInPractice.UI.Common;
using System.Collections.Generic;
using System.Linq;

namespace DddInPractice.UI.SnackMachines
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;
        private readonly SnackMachineRepository _repository;
        public override string Caption => "Snack Machine";
        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
        public Money MoneyInside => _snackMachine.MoneyInside;

        public IReadOnlyList<SnackPileViewModel> Piles
        {
            get
            {
                return _snackMachine.GetAllSnackPiles().Select(s => new SnackPileViewModel(s)).ToList();
            }
        }

        private string _message = "";
        public string Message
        {
            get { return _message; }
            private set
            {
                _message = value;
                Notify();
            }
        }
        public Command InsertCentCommand { get; private set; }
        public Command InsertTenCentCommand { get; private set; }
        public Command InsertQuarterCommand { get; private set; }
        public Command InsertDollarCommand { get; private set; }
        public Command InsertFiveDollarCommand { get; private set; }
        public Command InsertTwentyDollarCommand { get; private set; }
        public Command ReturnMoneyCommand { get; private set; }
        public Command<string> BuySnackCommand { get; private set; }

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;
            _repository = new SnackMachineRepository();

            InsertCentCommand = new Command(() => InsertMoney(Money.Cent));
            InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
            InsertQuarterCommand = new Command(() => InsertMoney(Money.Quarter));
            InsertDollarCommand = new Command(() => InsertMoney(Money.Dollar));
            InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
            ReturnMoneyCommand = new Command(() => ReturnMoney());
            BuySnackCommand = new Command<string>(BuySnack);
        }

        private void BuySnack(string positionString)
        {
            int position = int.Parse(positionString);

            string error = _snackMachine.CanBuySnack(position);
            if (error != string.Empty)
            {
                NotifyClient(error);
                return;
            }

            _snackMachine.BuySnack(position);
            _repository.Save(_snackMachine);

            NotifyClient("You've bought a snack");
        }

        private void ReturnMoney()
        {
            _snackMachine.ReturnMoney();
            NotifyClient("Money was returned");
        }

        private void InsertMoney(Money cointOrNote)
        {
            _snackMachine.InsertMoney(cointOrNote);
            NotifyClient("You have inserted: " + cointOrNote);
        }

        private void NotifyClient(string message)
        {
            Notify(nameof(MoneyInTransaction));
            Notify(nameof(MoneyInside));
            Notify(nameof(Piles));
            Message = message;
        }
    }
}
