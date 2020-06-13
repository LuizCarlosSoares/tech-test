 using System.Collections.Generic;
 using System;
 using Payroll.Core.Entities.Enums;
 using Payroll.Core.Entities;
 using Payroll.Core.Interfaces;
 using Xunit;

 namespace Payroll.Test {

     public class ItalyPayrollCalculatorTest {
         [Fact]
         public void As_a_payroll_user_I_should_see_an_income__tax_to_an_Italian_employee () {

             //Gross 4000            
             //1000 25% of 4000    
             // Gross - Tax = 3000

             var employee = new Employee () { HourRate = 40, TotalWorkedHours = 100, Location = Location.Italy };

             IPayroll italyPayrollCalculator = new ItalyPayrollCalculator ();
             italyPayrollCalculator.Calculate (employee);

             var expected = 1000;
             Assert.Contains (expected.ToString (), italyPayrollCalculator.ShowPayrollSummary ());

         }
     }

 }