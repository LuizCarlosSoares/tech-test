using Payroll.Core.Interfaces;

namespace Payroll.Core.Entities {
    public class IncomeDeduction : BaseDeduction {

        public IncomeDeduction (decimal standardRate, decimal higherRate, decimal standardRateBand, string description) 
        : base (standardRate, higherRate, standardRateBand, description) {
        
        }

        public override decimal Apply (decimal Income) {

            var remainder = Income - standardRateBand;

            var currentBand = standardRateBand > 0 ? standardRateBand : Income;

            var tax = currentBand * (standardRate / 100);

            return (remainder > 0) ? (remainder * (higherRate / 100)) + tax : tax;

        }
        public override string GetDeductionLabel () {
            return base.GetDeductionLabel ();
        }

    }
}