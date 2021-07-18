using System;

namespace VehicleSpace {
    [Serializable]
    class Vehicle
    {
        public double cena_za_dobe;
        public double promocja = 0.25;
        public string name; //(Imie i nazwisko klienta)
        public double balance; //(saldo klienta – ile kosztowało wypożyczenie)
        public int term; //(okres wypożyczenia – liczba dni)
        public DateTime dataWyp; //(data wypożyczenia)
        public DateTime dataZwr; //(data zwrotu)
        public string marka; //(marka pojazdu)
        public string model; //(model pojazdu)
        public DateTime data_prod; //(data produkcji)
        public double value; //(wartość samochodu)
        public double amortyzacja; //(koszty amortyzacji samochodu – 10% wartości r/r) 
        public double odometer; //(licznik – przebieg samochodu)

        public Vehicle(){
            cena_za_dobe = 100;
            name = "Testowy użytkownik";
            balance = 0;
            term = 0;
            dataWyp = DateTime.UtcNow.ToLocalTime();
            dataZwr = new DateTime();
            marka = "Nieznana";
            model = "Nieznany";
            data_prod = new DateTime(2010);
            value = 0;
            amortyzacja = 0;
            odometer = 0;
        }

        public Vehicle(
                double cena,
                string nam,
                DateTime datWyp,
                DateTime datZwr,
                DateTime dat_prod,
                double val,
                double odom
            )
        {
            cena_za_dobe = cena;
            name = nam;
            dataWyp = datWyp;
            dataZwr = datZwr;
            data_prod = dat_prod;
            value = val;
            odometer = odom;
            marka = "Nieznana";
            model = "Nieznany";
            calculateTermAndBalance();
            calculateDepreciation();
        }

        public Vehicle(
                double cena,
                string nam,
                DateTime datWyp,
                DateTime datZwr,
                DateTime dat_prod,
                double val,
                double odom,
                string mark
            )
        {
            cena_za_dobe = cena;
            name = nam;
            dataWyp = datWyp;
            dataZwr = datZwr;
            data_prod = dat_prod;
            value = val;
            odometer = odom;
            marka = mark;
            model = "Nieznany";
            calculateTermAndBalance();
            calculateDepreciation();
        }

        public Vehicle(
                double cena,
                string nam,
                DateTime datWyp,
                DateTime datZwr,
                DateTime dat_prod,
                double val,
                double odom,
                string mark,
                string mode
            )
        {
            cena_za_dobe = cena;
            name = nam;
            dataWyp = datWyp;
            dataZwr = datZwr;
            data_prod = dat_prod;
            value = val;
            odometer = odom;
            marka = mark;
            model = mode;
            calculateTermAndBalance();
            calculateDepreciation();
        }

        private void calculateTermAndBalance(){
            int dni_bez_promocji = 0;
            int dni_z_rabatem = 0;
            // Dla uproszczenia pomijam scenariusze bardzo długiego wynajmu
            if(dataWyp.Year == 2020 && dataZwr.Year == 2021){
                term = 366 - dataWyp.DayOfYear + dataZwr.DayOfYear;
                if(dataZwr.DayOfYear > 59 && dataZwr.DayOfYear < 178){
                    dni_z_rabatem += dataZwr.DayOfYear - 59;
                } else if(dataZwr.DayOfYear > 177){
                    dni_z_rabatem += 118;
                }
                dni_bez_promocji = term - dni_z_rabatem;
            } else if(dataWyp.Year == 2021 || dataZwr.Year == 2021){
                dni_bez_promocji += dataWyp.Year == 2021 && dataWyp.DayOfYear < 60 ? 60 - dataWyp.DayOfYear : 0;
                dni_bez_promocji += dataZwr.Year == 2021 && dataZwr.DayOfYear > 177 ? dataZwr.DayOfYear - 177 : 0;
                term = dataWyp.Year == 2021 && dataZwr.Year == 2021 ? (dataZwr - dataWyp).Days : 366 - dataWyp.DayOfYear + dataZwr.DayOfYear;
                dni_z_rabatem = term - dni_bez_promocji;
            } else{
                term = (dataZwr - dataWyp).Days;
                dni_bez_promocji = term;
            }
            double cena_z_rabatem = cena_za_dobe - (cena_za_dobe*promocja);
            string cena_ost = String.Format("{0:0.00}",(dni_z_rabatem * cena_z_rabatem + cena_za_dobe*dni_bez_promocji));
            balance = Convert.ToDouble(cena_ost);
        }

        private void calculateDepreciation(){
            DateTime current_time = DateTime.UtcNow.ToLocalTime();
            int year_to_year = ((current_time - data_prod).Days/365);
            double depreciation = 0;
            for(int i = year_to_year; i>0; --i){
                depreciation += (value - depreciation)*0.1;
            }
            amortyzacja = depreciation;
        }


        public override string ToString()
        {
            string result = "\n";
            result += "Cena za dobę: " + cena_za_dobe + " PLN";
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

        public void present(){
            Console.WriteLine(ToString());
        }
    }
}