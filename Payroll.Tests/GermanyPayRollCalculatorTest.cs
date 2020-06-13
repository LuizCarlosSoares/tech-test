 using System.Collections.Generic;
 using System;
 using Payroll.Core.Entities.Enums;
 using Payroll.Core.Entities;
 using Payroll.Core.Interfaces;
 using Xunit;

 namespace Payroll.Test {

     public class GermanyPayrollCalculatorTest {
         [Fact]
         public void As_a_payroll_user_I_should_see_an_income__tax_to_a_Germany_employee () {

             //Gross 4000            
             //1000 25% of 4000    
             // Gross - Tax = 3000

             var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Germany };

             IPayroll germanyPayrollCalculator = new GermanyPayrollCalculator ();
             germanyPayrollCalculator.Calculate (employee);

             var expected = 1252;
             Assert.Contains (expected.ToString (), germanyPayrollCalculator.ShowPayrollSummary ());

         }

         [Fact]
         public void As_a_payroll_user_I_should_see_the_pension_contibution_to_a_Germany_employee () {

             //Gross 4000            
             //80 = 2% of 4000             

             var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Germany };

             IPayroll GermanyPayrollCalculator = new GermanyPayrollCalculator ();
             GermanyPayrollCalculator.Calculate (employee);

             var expected = 80;
             Assert.Contains (expected.ToString (), GermanyPayrollCalculator.ShowPayrollSummary ());

         }

     }
 }