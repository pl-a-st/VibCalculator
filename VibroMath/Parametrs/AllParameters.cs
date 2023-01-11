using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Единицы измерения частоты вращения
/// </summary>
public enum FrequencyType {
    HZ,
    RPM
}
/// <summary>
/// Единицы измерения частоты вращения
/// </summary>
public enum SensitivityType {
    mV_G,
    mV_MS2
}
namespace VibroMath {
    /// <summary>
    /// Напряжение.
    /// </summary>
    public class Voltage : SignalsParameter {
        public Voltage() {

        }
        public Voltage(double value, SignalParametrType parametr) {
            if (parametr == SignalParametrType.RMS) {
                SetRMS(value);
            }
            if (parametr == SignalParametrType.PIK) {
                SetPIK(value);
            }
            if (parametr == SignalParametrType.PIK_PIK) {
                SetPIK_PIK(value);
            }
            if (parametr == SignalParametrType.dB) {
                Set_dB(value);
            }
        }
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
        public Acceleration() : base() { 
        }
        public Acceleration(double value, SignalParametrType param) : base(value, param) {
        }
    }
    /// <summary>
    /// Виброскорость.
    /// </summary>
    public class Velocity : VibroParametr {
        public Velocity() : base() {
        }
        public Velocity(double value, SignalParametrType param) : base(value, param) {
        }
    }
    /// <summary>
    /// Виброперемещение.
    /// </summary>
    public class Displacement : VibroParametr {
        public Displacement() : base() {
        }
        public Displacement(double value, SignalParametrType param) : base(value, param) {
        }
    }
    /// <summary>
    /// Коэффициент преобразования датчика.
    /// 
    /// </summary>
    public class Sensitivity : Parametr {
        public Sensitivity() {
        }
        public Sensitivity(double value, SensitivityType type) {
            if (type == SensitivityType.mV_G) {
                Set_mV_G(value);
            }
            if (type == SensitivityType.mV_MS2) {
                Set_mV_MS2(value);
            }
        }
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
        public Frequency() {
        }
        public Frequency(double value, FrequencyType type) {
            if (type == FrequencyType.HZ) {
                Set_Hz(value);
            }
            if (type == FrequencyType.RPM) {
                Set_RPM(value);
            }
        }
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