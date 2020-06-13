using Payroll.Core.Entities;

namespace Payroll.Core.Interfaces {

    public interface IPayroll {
        void Calculate (Employee employee);
        string ShowPayrollSummary ();

        decimal CalculateGrossIncome (Employee employee);
    }
}