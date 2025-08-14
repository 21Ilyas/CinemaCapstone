using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class AddScreeningMenuItem : MenuItem
    {
        private Screening _screening;
        private Transaction _transaction;

        public AddScreeningMenuItem(Screening screening, Transaction transaction)
        {
            _screening = screening ?? throw new ArgumentNullException(nameof(screening), "Screening cannot be null");
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
        }

        public override string MenuText()
        {
            return _screening.ToString();
        }

        public override void Select()
        {
            // Add the screening to the transaction
            _transaction.AddScreening(_screening);
            Console.WriteLine($"You have selected the screening: {_screening}");
        }
    }
}
