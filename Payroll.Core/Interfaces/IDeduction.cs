namespace Payroll.Core.Interfaces {
    public interface IDeduction {

        decimal Apply (decimal amount);
        string GetDeductionLabel ();

    }
}