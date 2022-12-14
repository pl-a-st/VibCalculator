using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibroMath {
    static public class VibroCalc {
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
            Frequency.Set_Hz(159.17);
            Voltage.SetRMS(100);
            Sensitivity.Set_mV_G(100);
        }
        public static void CalcAll(Voltage voltage) {
            Voltage = voltage;


        }
    }
}
