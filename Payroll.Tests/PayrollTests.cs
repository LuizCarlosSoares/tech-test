using System;
using System.Collections.Generic;
using Payroll.Core;
using Payroll.Core.Entities;
using Payroll.Core.Entities.Enums;
using Payroll.Core.Interfaces;
using Xunit;

namespace Payroll.Tests {

    public class PayrollTests {

        [Fact]
        public void Given_th_employee_is_paid_10_per_hour_when_the_employee_works_40_hours_the_Gross_amount_400 () {

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 10 };

            IPayroll payrollCaculator = new PayrollCalculator ();
            var expected = 400;
            var actual = payrollCaculator.CalculateGrossIncome (employee);
            Assert.Equal (expected, actual);

        }

        [Fact]
        public void As_a_payroll_user_I_should_see_the_income_tax_of_an_Irish_employee () {

            //Gross 4000
            //3400 remainder
            //150 25% of 600
            //1360 40% of 3400
            //total 1510 Income Tax
            // Gross - Tax = 2490           

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Ireland };

            List<IDeduction> deductions = new List<IDeduction> ();
            var mockDeduction = new Moq.Mock<IDeduction> ();
            var expected = 1510;
            mockDeduction.Setup (d => d.Apply (Moq.It.IsAny<decimal> ())).Returns (expected);
            deductions.Add (mockDeduction.Object);
            IPayroll irelandPayroll = new IrelandPayrollCalculator (deductions);

            irelandPayroll.Calculate (employee);

            Assert.Contains (expected.ToString (), irelandPayroll.ShowPayrollSummary ());

        }

        [Fact]
        public void As_a_Payroll_user_I_should_get_the_calculations_based_on_employee_location_Ireland () {

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Ireland };

            IPayroll irelandPayroll = PayrollCalculatorFactory.Create (employee);
            irelandPayroll.Calculate (employee);

            var actual = irelandPayroll.GetType ();
            var expected = typeof (IrelandPayrollCalculator);

            Assert.Equal (actual, expected);

        }

        [Fact]
        public void As_a_Payroll_user_I_should_get_the_calculations_based_on_employee_location_Germany () {

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Germany };

            IPayroll germanyPayrollCalculator = PayrollCalculatorFactory.Create (employee);
            germanyPayrollCalculator.Calculate (employee);

            var actual = germanyPayrollCalculator.GetType ();
            var expected = typeof (GermanyPayrollCalculator);

            Assert.Equal (actual, expected);

        }

        [Fact]
        public void As_a_Payroll_user_I_should_get_the_calculations_based_on_employee_location_Italy () {

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Italy };

            IPayroll italyPayrollCalculator = PayrollCalculatorFactory.Create (employee);
            italyPayrollCalculator.Calculate (employee);

            var actual = italyPayrollCalculator.GetType ();
            var expected = typeof (ItalyPayrollCalculator);

            Assert.Equal (actual, expected);

        }

    }

}