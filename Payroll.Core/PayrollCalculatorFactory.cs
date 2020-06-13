using System;
using Payroll.Core.Entities;
using Payroll.Core.Entities.Enums;
using Payroll.Core.Interfaces;

namespace Payroll.Core {
    public class PayrollCalculatorFactory {
        public static IPayroll Create (Employee employee) { 
            switch (employee.Location) {

                case Location.Ireland:
                    return new IrelandPayrollCalculator ();
                case Location.Germany:
                    return new GermanyPayrollCalculator ();
                case Location.Italy:
                    return new ItalyPayrollCalculator ();
                default:
                    throw new Exception ("Location Unknown");

            }

        }
    }
}