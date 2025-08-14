using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menus
{
    internal class AddConcessionMenuItem : MenuItem
    {
        private Concession _concession;
        private Transaction _transaction;

        public AddConcessionMenuItem(Concession concession, Transaction transaction)
        {
            _concession = concession;
            _transaction = transaction;
        }

        public override string MenuText()
        {
            return _concession.ToString();
        }

        public override void Select()
        {
            _transaction.AddConcession(_concession);
        }
    }
}
