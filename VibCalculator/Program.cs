using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibroMath;

namespace VibCalculator {
    class Program {
        static void Main(string[] args) {
            Sensitivity sensitivity = new Sensitivity();
            sensitivity.Set_mV_G(100);
            double mV_MS2 = sensitivity.Get_mV_MS2();
        }
    }
}
