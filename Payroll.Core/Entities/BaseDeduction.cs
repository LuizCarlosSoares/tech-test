using Payroll.Core.Interfaces;

namespace Payroll.Core.Entities {
    public abstract class BaseDeduction : IDeduction {

        public BaseDeduction (decimal standardRate, decimal higherRate, decimal standardRateBand, string description) {
            this.standardRate = standardRate;
            this.higherRate = higherRate;
            this.standardRateBand = standardRateBand;
            this.description = description;
        }
        protected decimal standardRate;
        protected decimal standardRateBand;
        protected decimal higherRate;
        protected decimal remainder;
        protected string description;

        public virtual decimal Apply (decimal income) {
            return (income * (standardRate / 100));
        }

        public virtual string GetDeductionLabel () {
            return this.description;
        }

    }
}