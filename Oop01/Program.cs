using Oop04.Delivery;
using Oop04.Interfaces;
using Oop04.Shipments;
using Oop04.Extensions;

namespace Oop04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task 2 & 3 & 4 
            DeliveryUtilities.PrintSystemTitle();

            #region Create Delivery Center & Driver

            DeliveryCenter center = new ("Cairo Delivery Center");

            Driver driver = new ("Moustafa Ahmed");
            center.Driver = driver;

            Console.WriteLine("\nDelivery Center");
            Console.WriteLine($"Driver: {center.Driver.Name}");

            #endregion

            #region Create Shipments

            StandardShipment standardShipment = new (
                "Laptop",
                3,
                80,
                "SH001",
                new DeliveryAddress("Cairo", "Main Street", 10));

            ExpressShipment expressShipment = new (
                "Mobile",
                2,
                60,
                "SH002",
                new DeliveryAddress("Cairo", "Nile Street", 20),
                30);

            InternationalShipment internationalShipment = new(
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

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Shipment Details");
            DeliveryUtilities.PrintSeparator(); ;

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
            [
                standardShipment,
                expressShipment,
                internationalShipment
            ];

            foreach (Shipment shipment in shipments)
            {
                shipment.PrintShipment();
            }

            #endregion

            #region Generate Customs Report

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Customs Report");
            Console.WriteLine("----------------------------------------");

            PriorityInternationalShipment priorityShipment =
                new (
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
                new (
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

            DeliveryReport report = new();

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
                Console.WriteLine(shipment.GetTrackingStatus());
            }

            foreach (IInsurable shipment in insurableShipments)
            {
                Console.WriteLine($"Insurance Cost: {shipment.CalculateInsurance():0.00} EGP");
            }

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Interface Polymorphism");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Interface Polymorphism Demonstrated Successfully");

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
            #endregion

            #region task 5
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Creating Shipments...");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Standard Shipment CreateD....");
            Console.WriteLine("Express Shipment Created......");
            Console.WriteLine("International Shipment Created...... \r\n");
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");

            #region Object Copy
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Object Copy");
            DeliveryUtilities.PrintSeparator();
            Shipment shipment1 = new StandardShipment("SH001", 10m, 50m, "TRACK001", new DeliveryAddress("City1", "Street1", 1));
            Shipment shipment2 = shipment1;

            Console.WriteLine($"Original Shipment HashCode: {shipment1.GetHashCode()}");
            Console.WriteLine($"Assigned Shipment HashCode: {shipment2.GetHashCode()}");
            // Shipment 1 and Shipment 2 have the same hash code (reference copy)
            // Shipment 3 has a different hash code (shallow copy)
            Console.WriteLine("---------------------------------------------------------");
            #endregion

            #region ShallowCopy
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Shallow Copy");
            DeliveryUtilities.PrintSeparator();

            Console.WriteLine($"Original Shipment City: {shipment1.Destination.City}");
            Console.WriteLine($"Copied Shipment City: {shipment1.Destination.City}\r\n");

            Shipment shallowShipment = shipment1.ShallowCopy();

            //------------------------------------
            //--------After Modification----------
            //------------------------------------
            shallowShipment.Description = "SH004";
            shallowShipment.Weight = 20m;
            shallowShipment.Destination.City = "City2";

            Console.WriteLine("Shallow Copy After Modification: \r\n");
            Console.WriteLine($"Original Shipment City: {shipment1.Destination.City}");
            Console.WriteLine($"Shallow Copy City: {shallowShipment.Destination.City}");

            Console.WriteLine("---------------------------------------------------------");
            #endregion

            #region Deep Copy
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Deep Copy");
            DeliveryUtilities.PrintSeparator();

            Shipment originalShipment = new StandardShipment("SH000", 30m, 90m, "TRACK001", new DeliveryAddress("Cairo", "Abbass", 1));
            Shipment deepcopy = originalShipment.DeepCopy();
            Console.WriteLine("Deep Copy Before Modification:");
            Console.WriteLine($"Original City: {originalShipment.Destination.City}");
            Console.WriteLine($"Copied City: {deepcopy.Destination.City} \r\n");

            deepcopy.Destination.City = "Giza";

            Console.WriteLine("Changing copied shipment address...\r\n");
            Console.WriteLine($"Original City: {originalShipment.Destination.City}");
            Console.WriteLine($"Copied City: {deepcopy.Destination.City}\r\n");

            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(originalShipment.Destination, deepcopy.Destination)}");
            #endregion

            #region Static Field
            Console.WriteLine("--------------Total Shipments Created------------------");
            Console.WriteLine(Shipment.TotalShipmentsCreated);
            Shipment shipment5 = new StandardShipment("SH005", 10m, 50m, "TRACK002", new DeliveryAddress("City3", "Street3", 3));
            Console.WriteLine(Shipment.TotalShipmentsCreated);

            #endregion

            #region Static Method
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            Shipment shipment6 = new StandardShipment("SH006", 15m, 70m, "TRACK003", new DeliveryAddress("City4", "Street4", 4));
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            #endregion

            #region partial class
            Console.WriteLine("---------------------------------");
            Console.WriteLine("--------Tracking Status--------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine(originalShipment.GetTrackingStatus());
            originalShipment.UpdateTrackingStatus("In Transit");
            Console.WriteLine(originalShipment.GetTrackingStatus());
            #endregion

            #region Extension Methods
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();

            Shipment standard = new StandardShipment("SH007", 3m, 30m, "TRACK004", new DeliveryAddress("City5", "Street5", 5));
            standard.UpdateTrackingStatus("In Transit");
            Console.WriteLine(standard.GetSummary());

            Shipment express = new ExpressShipment("SH008", 2m, 60m, "TRACK005", new DeliveryAddress("City6", "Street6", 6),50);
            express.UpdateTrackingStatus("Out For Delivery");
            Console.WriteLine(express.GetSummary());

            Shipment international = new InternationalShipment("SH009", 8m, 90m, "TRACK006", new DeliveryAddress("City7", "Street7", 7), "USA", 100);
            international.UpdateTrackingStatus("Delivered");
            Console.WriteLine(international.GetSummary());
            //Check if the shipments are delivered using the extension method.
            Console.WriteLine(ShipmentExtensions.IsDelivered(international));
            Console.WriteLine(ShipmentExtensions.IsDelivered(standard));
            #endregion

            #region Partial Method
            DeliveryUtilities.PrintSeparator();
            standard.UpdateTrackingStatus("Out For Delivery");
            DeliveryUtilities.PrintSeparator();
            #endregion
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment Completed");
            DeliveryUtilities.PrintSeparator();
            #endregion
        }
    }
}