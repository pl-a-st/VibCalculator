using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath {
    public enum Freeze {
        Voltage,
        Acceleration,
        Velocity,
        Displacement
    }
    /// <summary>
    /// Предоставляет:
    /// поля - параметры синусоидальной вибрации, находящиеся в математической зависимости;
    /// метод - вызывающий пересчет полей в зависимости от типа задаваемого параметра и его значения.
    /// </summary>
    static public class VibroCalc {
        const int IntegrationFactor = 1000;
        /// <summary>
        /// Напряжение.
        /// </summary>
        public static Voltage Voltage {
            get;
            private set;
        } = new Voltage();
        /// <summary>
        /// Виброускорение.
        /// </summary>
        public static Acceleration Acceleration {
            get;
            private set;
        } = new Acceleration();
        /// <summary>
        /// Виброскорость.
        /// </summary>
        public static Velocity Velocity {
            get;
            private set;
        } = new Velocity();
        /// <summary>
        /// Виброперемещние.
        /// </summary>
        public static Displacement Displacement {
            get;
            private set;
        } = new Displacement();
        /// <summary>
        /// Чувствительность.
        /// </summary>
        public static Sensitivity Sensitivity {
            get;
            private set;
        } = new Sensitivity();
        /// <summary>
        /// Частота.
        /// </summary>
        public static Frequency Frequency {
            get;
            private set;
        } = new Frequency();

        static VibroCalc() {
            Frequency.Set_RPM(1000 / 2 / Math.PI / 60);
            Voltage.SetRMS(100);
            Sensitivity.Set_mV_G(100);
            CalcAll();
        }
        
        /// <summary>
        /// Пересчитывает все параметры в зависимости от типа поданного значения.
        /// Принимает экземпляры классов: Voltage,  Acceleration, Velocity, Displacement, Frequency
        /// </summary>
        /// <param name="acceleration"></param>
        public static void CalcAll(Acceleration acceleration) {
            Acceleration = acceleration;
            Voltage.SetRMS(Sensitivity.Get_mV_MS2()* Acceleration.GetRMS());
            SetVelocity();
            SetDisplacement();
        }
        public static void CalcAll(Voltage voltage) {
            Voltage = voltage;
            SetAcceleration();
            SetVelocity();
            SetDisplacement();
        }
        public static void CalcAll(Velocity velocity) {
            Velocity = velocity;
            Acceleration.SetRMS(Velocity.GetRMS() * 2 * Math.PI * Frequency.Get_Hz() / IntegrationFactor);
            Voltage.SetRMS(Sensitivity.Get_mV_MS2()* Acceleration.GetRMS());
            SetDisplacement();
        }
        public static void CalcAll(Displacement displacement) {
            Displacement = displacement;
            Velocity.SetRMS(Displacement.GetRMS() * 2 * Math.PI * Frequency.Get_Hz() / IntegrationFactor);
            Acceleration.SetRMS(Velocity.GetRMS() * 2 * Math.PI * Frequency.Get_Hz() / IntegrationFactor);
            Voltage.SetRMS(Sensitivity.Get_mV_MS2()* Acceleration.GetRMS());
        }
        /// <summary>
        /// Пересчитывает все параметры относитлеьно замароженного параметра указанно в "freeze"
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="freeze"></param>
        public static void CalcAll(Frequency frequency, Freeze freeze) {
            Frequency = frequency;
            if (freeze == Freeze.Voltage) {
                CalcAll(Voltage);
            }
            if (freeze == Freeze.Acceleration) {
                CalcAll(Acceleration);
            }
            if (freeze == Freeze.Velocity) {
                CalcAll(Velocity);
            }
            if (freeze == Freeze.Displacement) {
                CalcAll(Displacement);
            }
        }
        /// <summary>
        /// Пересчитывает все параметры относитлеьно замароженного параметра указанно в "freeze"
        /// </summary>
        /// <param name="sensitivity"></param>
        /// <param name="freeze"></param>
        public static void CalcAll(Sensitivity sensitivity, Freeze freeze) {
            Sensitivity = sensitivity;
            if(freeze == Freeze.Voltage) {
                CalcAll(Voltage);
            }
            if (freeze == Freeze.Acceleration ) {
                CalcAll(Acceleration);
            }
            if (freeze == Freeze.Velocity) {
                CalcAll(Velocity);
            }
            if (freeze == Freeze.Displacement) {
                CalcAll(Displacement);
            }
        }

        private static void CalcAll() {
            SetAcceleration();
            SetVelocity();
            SetDisplacement();
        }
        private static void SetAcceleration() {
            Acceleration.SetRMS(Voltage.GetRMS() / Sensitivity.Get_mV_MS2());
        }
        private static void SetVelocity() {
            Velocity.SetRMS(Acceleration.GetRMS() / 2 / Math.PI / Frequency.Get_Hz() * IntegrationFactor);
        }
        private static void SetDisplacement() {
            Displacement.SetRMS(Velocity.GetRMS() / 2 / Math.PI / Frequency.Get_Hz() * IntegrationFactor);
        }
    }
}
