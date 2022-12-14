using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath {
    public abstract class Parametr { // Рассказать про абстрактные классы
        private protected double Value;
        //protected Parametr(double value) {
        //    Value = value;
        //}
    }
    public class SignalsParameter : Parametr { // abstract - класс не будет доступен для вызова
        //protected SignalsParameter(double RMSValue)
        //    : base(RMSValue) {
        //}
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
}
