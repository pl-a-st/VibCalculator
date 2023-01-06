using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath {
    /// <summary>
    /// Напряжение.
    /// </summary>
    public class Voltage : SignalsParameter {
        private double Threshold = Math.Pow(10, -3);
        /// <summary>
        /// Возвращает значение в дБ.
        /// </summary>
        /// <returns></returns>
        public double Get_dB() {
            return 20 * Math.Log10(Value / Threshold);
        }
        /// <summary>
        /// Присваивает значение параметру, принимает дБ.
        /// </summary>
        /// <param name="dB"></param>
        public void Set_dB(double dB) {
            double threshold = Math.Pow(10, -6);
            Value = Math.Pow(10, dB / 20) * Threshold;
        }
    }
    /// <summary>
    /// Виброускорение.
    /// </summary>
    public class Acceleration : VibroParametr {
    }
    /// <summary>
    /// Виброскорость.
    /// </summary>
    public class Velocity : VibroParametr {
    }
    /// <summary>
    /// Виброперемещение.
    /// </summary>
    public class Displacement : VibroParametr {
    }
    /// <summary>
    /// Коэффициент преобразования датчика.
    /// 
    /// </summary>
    public class Sensitivity : Parametr {
        /// <summary>
        /// Единица измерения вибрационного ускорения принятая равной 9,807 м/с²
        /// </summary>
        private const double G = 9.807;
        /// <summary>
        /// Возвращает значение в мВ/g
        /// </summary>
        /// <returns></returns>
        public double Get_mV_G() {
            return Value;
        }
        /// <summary>
        /// Приваивает значение параметру. Принимает мВ/g.
        /// </summary>
        /// <param name="mV_G"></param>
        public void Set_mV_G(double mV_G) {
            Value = mV_G;
        }
        /// <summary>
        /// Возвращает значение параметра в мВ/м∙сˉ²
        /// </summary>
        /// <returns></returns>
        public double Get_mV_MS2() {
            return Value / G;
        }
        /// <summary>
        /// Присваивает значение параметру. Принимает мВ/м∙сˉ²
        /// </summary>
        /// <param name="mV_MS2"></param>
        public void Set_mV_MS2(double mV_MS2) {
            Value = mV_MS2 * G;
        }
    }
    /// <summary>
    /// Частота
    /// </summary>
    public class Frequency : Parametr {
        private const double CountSecondInMinute = 60;
        /// <summary>
        /// Возвращает значение в Гц.
        /// </summary>
        /// <returns></returns>
        public double Get_Hz() {
            return Value;
        }
        /// <summary>
        /// Присваивает значение параметру. Прнимает Гц.
        /// </summary>
        /// <param name="hz"></param>
        public void Set_Hz(double hz) {
            Value = hz;
        }
        /// <summary>
        /// Возвращает значение в Об/мин.
        /// </summary>
        /// <returns></returns>
        public double Get_RPM() {

            return Value * CountSecondInMinute;
        }
        /// <summary>
        /// Присваивает значение параметру. Прнимает Об/мин.
        /// </summary>
        /// <param name="RPM"></param>
        public void Set_RPM(double RPM) {
            Value = RPM / CountSecondInMinute;
        }
    }
}