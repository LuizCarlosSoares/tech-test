using System;
using System.Collections.Generic;
using Payroll.Core.Entities;
using Payroll.Core.Entities.Enums;
using Payroll.Core.Interfaces;
using Xunit;

namespace PayrollTests {

    public class IrelandPayrollCalculatorTests {

        [Fact]
        public void Given_th_employee_is_paid_10_per_hour_when_the_employee_works_40_hours_the_Gross_amount_400 () {

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 10 };

            IPayroll payrollCaculator = new IrelandPayrollCalculator ();
            var expected = 400;
            var actual = payrollCaculator.CalculateGrossIncome (employee);
            Assert.Equal (expected, actual);

        }

        [Fact]
        public void As_a_payroll_user_I_should_see_the_income_tax_of_an_Irish_employee_with_fake_calculation () {

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
        public void As_a_payroll_user_I_should_see_the_income_tax_of_an_Irish_employee_with_real_calculation () {

            //Gross 4000
            //3400 remainder
            //150 25% of 600
            //1360 40% of 3400
            //total 1510 Income Tax
            // Gross - Tax = 2490           

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Ireland };

            var expected = 1510;
            IPayroll irelandPayroll = new IrelandPayrollCalculator ();

            irelandPayroll.Calculate (employee);

            Assert.Contains (expected.ToString (), irelandPayroll.ShowPayrollSummary ());

        }

        [Fact]
        public void As_a_payroll_user_I_sould_see_the_universal_social_charge_of_an_Irish_employee () {
            //Gross 4000
            //3500 remainder
            //35 = 7% of 500
            //315 8% of 3500
            //total 315 = USC
            // Gross - Tax = 3685

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Ireland };

             IPayroll irelandPayroll = new IrelandPayrollCalculator ();
            irelandPayroll.Calculate (employee);

            var expected = 315;
            Assert.Contains (expected.ToString (), irelandPayroll.ShowPayrollSummary ());

        }

        [Fact]
        public void As_a_payroll_user_I_sould_see_the_compulsory_pension_contribution_of_an_Irish_employee () {
            //Gross 4000
            //0 remainder
            //160 = 4% of 4000 pension                    
            // Gross - Tax = 3840

            var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Ireland };

            IPayroll irelandPayroll = new IrelandPayrollCalculator();
            irelandPayroll.Calculate (employee);

            var expected = 160;
            Assert.Contains (expected.ToString (), irelandPayroll.ShowPayrollSummary ());

        }

    }

}