using System.Collections.Generic;
using Payroll.Core.Interfaces;

namespace Payroll.Core.Entities {
    public class ItalyPayrollCalculator : PayrollCalculator {

        public ItalyPayrollCalculator (List<IDeduction> deductions) : base (deductions) {

        }

        public ItalyPayrollCalculator () : base () {
            this.deductions.Add (new IncomeDeduction (25, 0, 0, "Income Tax: €x"));
        }

    }
}