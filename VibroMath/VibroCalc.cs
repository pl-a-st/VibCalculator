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
    static public class VibroCalc {
        const int IntegrationFactor = 1000;
        public static Voltage Voltage {
            get;
            private set;
        } = new Voltage();
        public static Acceleration Acceleration {
            get;
            private set;
        } = new Acceleration();
        public static Velocity Velocity {
            get;
            private set;
        } = new Velocity();
        public static Displacement Displacement {
            get;
            private set;
        } = new Displacement();
        public static Sensitivity Sensitivity {
            get;
            private set;
        } = new Sensitivity();
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
        private static void CalcAll() {
            SetAcceleration();
            SetVelocity();
            SetDisplacement();
        }
        public static void CalcAll(Voltage voltage) {
            Voltage = voltage;
            SetAcceleration();
            SetVelocity();
            SetDisplacement();
        }
        public static void CalcAll(Acceleration acceleration) {
            Acceleration = acceleration;
            SetVelocity();
            SetDisplacement();
        }
        public static void CalcAll(Velocity velocity) {
            Velocity = velocity;
            Acceleration.SetRMS(Velocity.GetRMS() * 2 * Math.PI * Frequency.Get_Hz() / IntegrationFactor);
            Voltage.SetRMS(Acceleration.GetRMS() / Sensitivity.Get_mV_MS2());
            SetDisplacement();
        }
        public static void CalcAll(Displacement displacement) {
            Displacement = displacement;
            Velocity.SetRMS(Displacement.GetRMS() * 2 * Math.PI * Frequency.Get_Hz() / IntegrationFactor);
            Acceleration.SetRMS(Velocity.GetRMS() * 2 * Math.PI * Frequency.Get_Hz() / IntegrationFactor);
            Voltage.SetRMS(Acceleration.GetRMS() / Sensitivity.Get_mV_MS2());
        }
        public static void CalcAll(Frequency frequency, Freeze freeze) {
            Frequency = frequency;
            if (freeze == Freeze.Acceleration|| freeze == Freeze.Voltage) {
                CalcAll(Acceleration);
            }
            if (freeze == Freeze.Velocity) {
                CalcAll(Velocity);
            }
            if (freeze == Freeze.Displacement) {
                CalcAll(Displacement);
            }
        }
        public static void CalcAll(Sensitivity sensitivity, Freeze freeze) {
            Sensitivity = sensitivity;
            if (freeze == Freeze.Acceleration || freeze == Freeze.Voltage) {
                CalcAll(Acceleration);
            }
            if (freeze == Freeze.Velocity) {
                CalcAll(Velocity);
            }
            if (freeze == Freeze.Displacement) {
                CalcAll(Displacement);
            }
        }
        private static void SetAcceleration() {
            Acceleration.SetRMS(Voltage.GetRMS() / Sensitivity.Get_mV_MS2());
        }
        private static void SetVelocity() {
            Velocity.SetRMS(Acceleration.GetRMS() / 2 / Math.PI / Frequency.Get_Hz() * IntegrationFactor);
        }
        static private void SetDisplacement() {
            Displacement.SetRMS(Velocity.GetRMS() / 2 / Math.PI / Frequency.Get_Hz() * IntegrationFactor);
        }
    }
}
