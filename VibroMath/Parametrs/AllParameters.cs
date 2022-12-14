using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath {
    public class Voltage : SignalsParameter {
        private double Threshold = Math.Pow(10, -3);
        public double Get_dB() {
            return 20 * Math.Log10(Value / Threshold);
        }
        public void Set_dB(double dB) {
            double threshold = Math.Pow(10, -6);
            Value = Math.Pow(10, dB / 20) * Threshold;
        }
    }
    public class Acceleration : VibroParametr {

    }
    public class Velocity : VibroParametr {

    }
    public class Displacement : VibroParametr {

    }
    public class Sensitivity : Parametr {
        private const double G = 9.807;
        public double Get_mV_G() {
            return Value;
        }
        public void Set_mV_G(double mV_G) {
            Value = mV_G;
        }
        public double Get_mV_MS2() {

            return Value / G;
        }
        public void Set_mV_MS2(double mV_MS2) {
            Value = mV_MS2 * G;
        }
    }
    public class Frequency : Parametr {
        private const double CountSecondInMinute = 60;
        public double Get_Hz() {
            return Value;
        }
        public void Set_Hz(double hz) {
            Value = hz;
        }
        public double Get_RPM() {

            return Value / CountSecondInMinute;
        }
        public void Set_RPM(double RPM) {
            Value = RPM * CountSecondInMinute;
        }
    }
}