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
        /// <summary>
        /// Присваивает значение параметру, принимает СКЗ
        /// </summary>
        /// <param name="RMS">значение СКЗ</param>
        public void SetRMS(double RMS) {
            Value = RMS;
        }
        /// <summary>
        /// Присваивает значение параметру, принимает ПИК
        /// </summary>
        /// <param name="PIK">значение ПИК</param>
        public void SetPIK(double PIK) {
            Value = PIK / Math.Sqrt(2);
        }
        /// <summary>
        /// Присваивает значение параметру, принимает Размах
        /// </summary>
        /// <param name="PIK_PIK">значение Разамх</param>
        public void SetPIK_PIK(double PIK_PIK) {
            Value = PIK_PIK / 2 / Math.Sqrt(2);
        }
        /// <summary>
        /// Возвращает СКЗ параметра
        /// </summary>
        /// <returns></returns>
        public double GetRMS() {
            return Value;
        }
        /// <summary>
        /// Возвращает ПИК параметра
        /// </summary>
        /// <returns></returns>
        public double GetPIK() {
            return Value* Math.Sqrt(2);
        }
        /// <summary>
        /// Возвращает Размах параметра
        /// </summary>
        /// <returns></returns>
        public double GetPIK_PIK() {
            return Value * 2*Math.Sqrt(2);
        }
    }
    public abstract class VibroParametr : SignalsParameter {
        private double Threshold = Math.Pow(10, -6);
        /// <summary>
        /// Возвращает значение в дБ
        /// </summary>
        /// <returns></returns>
        public double Get_dB() {
            return 20 * Math.Log10(Value / Threshold);
        }
        /// <summary>
        ///  Присваивает значение параметру, принимает значение в дБ
        /// </summary>
        /// <param name="dB"></param>
        public void Set_dB(double dB) {
            double threshold = Math.Pow(10, -6);
            Value = Math.Pow(10, dB / 20 )* Threshold;
        }
    }
    
}
