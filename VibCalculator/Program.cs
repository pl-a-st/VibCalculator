using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibroMath;

namespace VibCalculator {
    class Program {
        static void Main(string[] args) {
            double acc = VibroCalc.Acceleration.GetRMS();
            double vel = VibroCalc.Velocity.GetRMS();
            double dis = VibroCalc.Displacement.GetRMS();
            double freq = VibroCalc.Frequency.Get_Hz();
            double sens = VibroCalc.Sensitivity.Get_mV_MS2();
            double sens2 = VibroCalc.Sensitivity.Get_mV_G();

            Frequency frequency = new Frequency();
            frequency.Set_Hz(80);

            Velocity velocity = new Velocity();
            velocity.SetRMS(140);
            VibroCalc.CalcAll(frequency, Freeze.Acceleration);
            acc = VibroCalc.Acceleration.GetRMS();
            vel = VibroCalc.Velocity.GetRMS();
            dis = VibroCalc.Displacement.GetRMS();
            freq = VibroCalc.Frequency.Get_Hz();
            VibroCalc.CalcAll(velocity);
            acc = VibroCalc.Acceleration.GetRMS();
            vel = VibroCalc.Velocity.GetRMS();
            dis = VibroCalc.Displacement.GetRMS();
            freq = VibroCalc.Frequency.Get_Hz();

        }
    }
}
