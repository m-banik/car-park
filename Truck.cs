using System;
using VehicleSpace;

namespace TruckSpace {
    [Serializable]
    class Truck: Vehicle {
        public Truck():base(){}

        public Truck(
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
                "Ford",
                "Ranger"
                ){}
    }
}