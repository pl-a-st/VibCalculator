using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibroMath;

namespace VibCalculator {
    class Program {
        static void Main(string[] args) {
            Voltage voltage = new Voltage();
            voltage.SetPIK_PIK(242);
            double volt = voltage.GetPIK();
        }
    }
}
