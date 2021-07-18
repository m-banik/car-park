using System;
using VehicleSpace;

namespace CarSpace {
    [Serializable]
    class Car: Vehicle {
        public Car():base(){}

        public Car(
            double cena,
            string nam,
            DateTime datWyp,
            DateTime datZwr,
            DateTime dat_prod,
            double val,
            double odom
            ):base(
                cena,
                nam,
                datWyp,
                datZwr,
                dat_prod,
                val,
                odom,
                "FIAT"
                ){}
        
        public Car(
            double cena,
            string nam,
            DateTime datWyp,
            DateTime datZwr,
            DateTime dat_prod,
            double val,
            double odom,
            string model
            ):base(
                cena,
                nam,
                datWyp,
                datZwr,
                dat_prod,
                val,
                odom,
                "FIAT",
                model
                ){}
    }
}