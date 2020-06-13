using System.Collections.Generic;
using Payroll.Core.Interfaces;

namespace Payroll.Core.Entities {
    public class IrelandPayrollCalculator : PayrollCalculator {

        public IrelandPayrollCalculator (List<IDeduction> deductions) : base (deductions) {

        }

        public IrelandPayrollCalculator () : base () {
            this.deductions.Add (new IncomeDeduction (25, 40, 600, "Income Tax: €x"));
            this.deductions.Add (new IncomeDeduction (7, 8, 500, "Universal Social Charge: €x"));
            this.deductions.Add (new IncomeDeduction (4, 0, 0, "Pension: €x"));
        }

    }
}