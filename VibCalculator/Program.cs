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
            voltage.SetRMS(100);
            VibroCalc.CalcAll(voltage);
            VibroCalc.Velocity.Get_dB();
            VibroCalc.Voltage.Get_dB();
            double acc = VibroCalc.Acceleration.GetRMS();
        }
    }
}
