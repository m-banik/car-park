using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using VehicleSpace;
using CarSpace;
using MuscleSpace;
using TruckSpace;

namespace AppSapce {

    class App {

        static void Main(string[] args) {
            string file_name = "";
            List<Vehicle> vehicles = new List<Vehicle>();
            if(args.Length == 1) {
                file_name = args[0].Length > 0 && args[0].Contains(".") ? args[0] : "vehicles_data.dat";
                generateSamples(file_name);
            } else if(args.Length >= 9) {
                file_name = args.Length == 10 && args[9].Length > 0 && args[9].Contains(".") ? args[9] : "vehicles_data.dat";
                vehicles.Add(
                    new Vehicle(
                        Convert.ToDouble(args[0]),
                        args[1],
                        new DateTime(
                            Convert.ToInt16(args[2].Substring(0,4)),
                            Convert.ToInt16(args[2].Substring(5,2)),
                            Convert.ToInt16(args[2].Substring(8,2))
                        ),
                        new DateTime(
                            Convert.ToInt16(args[3].Substring(0,4)),
                            Convert.ToInt16(args[3].Substring(5,2)),
                            Convert.ToInt16(args[3].Substring(8,2))
                        ),
                        new DateTime(
                            Convert.ToInt16(args[4].Substring(0,4)),
                            Convert.ToInt16(args[4].Substring(5,2)),
                            Convert.ToInt16(args[4].Substring(8,2))
                        ),
                        Convert.ToDouble(args[5]),
                        Convert.ToDouble(args[6]),
                        args[7],
                        args[8]
                    )
                );
                writeFile(file_name, vehicles);
                readFile(file_name);
            } else {
                Console.WriteLine("Przykład obiektu:");
                Car car = new Car(
                    100,
                    "Jacek Kwiatkowski",
                    new DateTime(2021, 2, 1, 00, 00, 00),
                    new DateTime(2021, 6, 30, 00, 00, 00),
                    new DateTime(2019, 1, 1, 15, 32, 00),
                    100000,
                    2000
                );
                car.present();
            }
        }

        static void generateSamples(string file_name){
            Console.WriteLine(
                "Dane przykładowe - wygenerowane w oparciu o klasy, zapisane i odczytane z pliku:"
            );
            List<Vehicle> vehicles = new List<Vehicle>();
            /* Pierwszy pojazd jest starszy, niż przewidział opis projektu,
            ale chciałem oddać działającą obsługę amortyzacji */
            vehicles.Add(new Car(
            100,
            "Jacek Kwiatkowski",
            new DateTime(2021, 2, 1, 00, 00, 00),
            new DateTime(2021, 6, 30, 00, 00, 00),
            new DateTime(2019, 1, 1, 15, 32, 00),
            100000,
            2000
            ));
            vehicles.Add(new Car(
            110,
            "Jan Kowalski",
            new DateTime(2020, 12, 31, 12, 30, 00),
            new DateTime(2021, 3, 2, 14, 20, 00),
            new DateTime(2020, 1, 1, 15, 32, 00),
            100000,
            2000,
            "Fullback"
            ));
            vehicles.Add(new Muscle(
            200,
            "Piotr Nowak",
            new DateTime(2020, 5, 1, 12, 00, 00),
            new DateTime(2020, 6, 1, 12, 00, 00),
            new DateTime(2020, 1, 5, 12, 00, 00),
            180000,
            1000
            ));
            vehicles.Add(new Truck(
            180,
            "Artur Malinowski",
            new DateTime(2020, 6, 5, 00, 00, 00),
            new DateTime(2020, 6, 15, 00, 00, 00),
            new DateTime(2020, 1, 10 , 00, 00, 00),
            200000,
            2000
            ));
            writeFile(file_name, vehicles);
            readFile(file_name);
        }

        private static void writeFile(string file_name,List<Vehicle> data) {
            Stream stream = File.Open(file_name, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try {
                formatter.Serialize(stream, data);
            } catch(Exception error) {
                Console.WriteLine("Nieudana serializacja. Przyczyna: " + error.Message);
                throw;
            } finally {
                stream.Close();
            }
        }

        private static void readFile(string file_name) {
            Stream stream = File.Open(file_name, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Vehicle> vehicles = new List<Vehicle>();
            try{  
                vehicles = (List<Vehicle>)formatter.Deserialize(stream);
            } catch(Exception error) {
                Console.WriteLine("Nieudana serializacja. Przyczyna: " + error.Message);
                throw;
            } finally {
                stream.Close();
            }
            if(vehicles.Count > 0){
              for(int i = 0; i < vehicles.Count; ++i){
                  vehicles[i].present();
              }
            } else{
              Console.WriteLine("Lista z danymi o pojazdach jest pusta");
            }
        }
    }
}