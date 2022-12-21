using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath {
    public abstract class Parametr { 
        private protected double Value;
    }
    public abstract class SignalsParameter : Parametr { 
        public void SetRMS(double RMS) {
            Value = RMS;
        }
        public void SetPIK(double PIK) {
            Value = PIK / Math.Sqrt(2);
        }
        public void SetPIK_PIK(double PIK_PIK) {
            Value = PIK_PIK / 2 / Math.Sqrt(2);
        }
        public double GetRMS() {
            return Value;
        }
        public double GetPIK() {
            return Value* Math.Sqrt(2);
        }
        public double GetPIK_PIK() {
            return Value * 2*Math.Sqrt(2);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class VibroParametr : SignalsParameter {
        private double Threshold = Math.Pow(10, -6);
        public double Get_dB() {
            return 20 * Math.Log10(Value / Threshold);
        }
        public void Set_dB(double dB) {
            double threshold = Math.Pow(10, -6);
            Value = Math.Pow(10, dB / 20 )* Threshold;
        }
    }
    
}
