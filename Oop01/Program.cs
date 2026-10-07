using Oop04.Delivery;
using Oop04.Interfaces;
using Oop04.Shipments;

namespace Oop04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("          DELIVERY SYSTEM");
            Console.WriteLine("========================================");

            #region Create Delivery Center & Driver

            DeliveryCenter center = new DeliveryCenter("Cairo Delivery Center");

            Driver driver = new Driver("Moustafa Ahmed");
            center.Driver = driver;

            Console.WriteLine("\nDelivery Center");
            Console.WriteLine($"Driver: {center.Driver.Name}");

            #endregion

            #region Create Shipments

            StandardShipment standardShipment = new StandardShipment(
                "Laptop",
                3,
                80,
                "SH001",
                new DeliveryAddress("Cairo", "Main Street", 10));

            ExpressShipment expressShipment = new ExpressShipment(
                "Mobile",
                2,
                60,
                "SH002",
                new DeliveryAddress("Cairo", "Nile Street", 20),
                30);

            InternationalShipment internationalShipment = new InternationalShipment(
                "Television",
                8,
                120,
                "SH003",
                new DeliveryAddress("Cairo", "Airport Street", 30),
                "Germany",
                100);

            #endregion

            #region Add Shipments

            center.AddShipment(standardShipment);
            center.AddShipment(expressShipment);
            center.AddShipment(internationalShipment);

            #endregion

            #region Shipment Details

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Shipment Details");
            Console.WriteLine("----------------------------------------");

            center.PrintAllShipments();

            #endregion

            #region Delivery Helper

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Delivery Helper");
            Console.WriteLine("----------------------------------------");

            DeliveryHelper.PrintShipmentDetails(standardShipment);
            DeliveryHelper.PrintShipmentDetails(expressShipment);
            DeliveryHelper.PrintShipmentDetails(internationalShipment);

            #endregion

            #region Shipment Array

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Shipment Array");
            Console.WriteLine("----------------------------------------");

            Shipment[] shipments =
            {
                standardShipment,
                expressShipment,
                internationalShipment
            };

            foreach (Shipment shipment in shipments)
            {
                shipment.PrintShipment();
            }

            #endregion

            #region Update Weight - Overloading

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Updating Weight");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"Original Weight: {standardShipment.Weight} KG");

            standardShipment.UpdateWeight(5);
            Console.WriteLine($"Updated Weight: {standardShipment.Weight} KG");

            standardShipment.UpdateWeight(5, 0.5m);
            Console.WriteLine($"Updated Weight After Packing: {standardShipment.Weight} KG");

            #endregion

            #region Generate Customs Report

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Customs Report");
            Console.WriteLine("----------------------------------------");

            PriorityInternationalShipment priorityShipment =
                new PriorityInternationalShipment(
                    "Television",
                    8,
                    120,
                    "SH004",
                    new DeliveryAddress("Cairo", "Airport Street", 30),
                    "Germany",
                    100);

            Console.WriteLine(priorityShipment.GenerateCustomsReport());

            #endregion

            #region Sealed Class

            CompletedShipment completedShipment =
                new CompletedShipment(
                    "Documents",
                    1,
                    50,
                    "SH005",
                    new DeliveryAddress("Cairo", "Tahrir Street", 15));

            #endregion

            #region Tracking Status

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Tracking Status");
            Console.WriteLine("----------------------------------------");

            center.PrintTrackingStatuses();

            #endregion

            #region Insurance

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Insurance");
            Console.WriteLine("----------------------------------------");

            DeliveryReport report = new DeliveryReport();

            Console.WriteLine(
                $"Standard Shipment Insurance: {standardShipment.CalculateInsurance():0.00} EGP");

            Console.WriteLine(
                $"Express Shipment Insurance: {expressShipment.CalculateInsurance():0.00} EGP");

            Console.WriteLine(
                $"International Shipment Insurance: {internationalShipment.CalculateInsurance():0.00} EGP");

            #endregion

            #region Interface Polymorphism

            ITrackable[] trackableShipments =
            {
                standardShipment,
                expressShipment,
                internationalShipment
            };

            IInsurable[] insurableShipments =
            {
                standardShipment,
                expressShipment,
                internationalShipment
            };

            foreach (ITrackable shipment in trackableShipments)
            {
                shipment.GetTrackingStatus();
            }

            foreach (IInsurable shipment in insurableShipments)
            {
                shipment.CalculateInsurance();
            }

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Interface Polymorphism");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Interface Polymorphism Demonstrated Successfully");

            #endregion

            #region Remove Shipment

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Remove Shipment");
            Console.WriteLine("----------------------------------------");

            bool removed = center.RemoveShipment("SH002");

            Console.WriteLine(
                removed
                ? "Shipment SH002 Removed Successfully."
                : "Shipment SH002 Not Found.");

            #endregion

            Console.WriteLine("\n========================================");
            Console.WriteLine("                 END");
            Console.WriteLine("========================================");

        }
    }
}