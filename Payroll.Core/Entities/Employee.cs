using Payroll.Core.Entities.Enums;

namespace Payroll.Core.Entities {

    public class Employee {

        public decimal HourRate { get; set; }
        public decimal TotalWorkedHours { get; set; }
        public decimal GrossIncome { get { return HourRate * TotalWorkedHours; } }
        public Location Location { get; set; }

    }
}