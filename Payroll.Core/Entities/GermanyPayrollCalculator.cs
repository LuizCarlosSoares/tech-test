using System.Collections.Generic;
using Payroll.Core.Interfaces;
namespace Payroll.Core.Entities {
    public class GermanyPayrollCalculator : PayrollCalculator {

        public GermanyPayrollCalculator () : base () {

            this.deductions.Add (new IncomeDeduction (25, 32, 400, "Income Tax: €x")); 
             this.deductions.Add (new IncomeDeduction (2, 0, 0, "Pension: €x"));          

        }

        public override void Calculate (Employee employee) {
            base.Calculate (employee);
        }

    }
}