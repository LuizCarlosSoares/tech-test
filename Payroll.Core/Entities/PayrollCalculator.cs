using System.Collections.Generic;
using System.Text;
using Payroll.Core.Interfaces;

namespace Payroll.Core.Entities {
    public class PayrollCalculator : IPayroll {
        protected decimal GrossIncome;
        protected decimal NetIncome;

        protected StringBuilder Summary = new StringBuilder ();

        protected readonly List<IDeduction> deductions;
        public PayrollCalculator () {
            this.deductions = new List<IDeduction> ();
        }
        public PayrollCalculator (List<IDeduction> deductions) {
            this.deductions = deductions;
        }
        public virtual void Calculate (Employee employee) {

            this.deductions.ForEach ((deduction) => {
                var deductionAmount = deduction.Apply (employee.GrossIncome);
                Summary.AppendLine ($"{deduction.GetDeductionLabel()}: {deductionAmount}");
                NetIncome -= deductionAmount;
            });
        }

        public decimal CalculateGrossIncome (Employee employee) {
            return employee.GrossIncome;
        }

        public string ShowPayrollSummary () {
            return this.Summary.ToString ();
        }
    }
}