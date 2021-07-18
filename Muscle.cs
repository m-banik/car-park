using System;
using VehicleSpace;

namespace MuscleSpace {
    [Serializable]
    class Muscle: Vehicle {
        public Muscle():base(){}

        public Muscle(
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
                "Mustang"
                ){}

        public override string ToString() {
            string result = "\nProdukt klasy premium - tylko dla najbardziej wymagających klientów!";
            result += "\nCena za dobę: " + cena_za_dobe + " PLN";
            result += "\nImię i nazwisko klienta: " + name;
            result += "\nSaldo klienta: " + balance.ToString() + " PLN";
            result += "\nOkres wypożyczenia: " + term.ToString();
            result += "\nData wypożyczenia: " + dataWyp;
            result += "\nData zwrotu: " + dataZwr.ToString();
            result += "\nMarka pojazdu: " + marka;
            result += "\nModel pojazdu: " + model;
            result += "\nData produkcji: " + data_prod.ToString();
            result += "\nWartość pojazdu: " + value.ToString();
            result += "\nKoszty amortyzacji: " + amortyzacja.ToString();
            result += "\nPrzebieg pojazdu: " + odometer.ToString();
            return result;
        }
    }
}