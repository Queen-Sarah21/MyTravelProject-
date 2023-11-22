using System;
using System.Xml.Linq;
using static FinalExam_QueenSarah.MyTravel;
using static System.Formats.Asn1.AsnWriter;

namespace FinalExam_QueenSarah
{
    public class MyTravel
    {
        #region VARIABLES
        public static Client[] clients = new Client[NUMBER_OF_CLIENTS];
        public static int indexClients = 0;
        public static Flight[] flights = new Flight[NUMBER_OF_FLIGHTS];
        public static int indexFlights = 0;
        public static int option = 0;
        #endregion
        #region Constants
        const int MIN_ID_VALUE = 1;
        const int MAX_ID_VALUE = int.MaxValue;
        const int NUMBER_OF_CLIENTS = 10;
        const int NUMBER_OF_FLIGHTS = 20;
        #endregion
        #region STRUCTS
        public struct Client
        {
            public int Id;
            public string UserName;
            public Client(int id, string userName)
            {
                Id = id;
                UserName = userName;
            }
        }
        public struct Flight
        {
            public int Id;
            public string CityOrigin;
            public string CityDestination;
            public string DateOfDeparture;
            public int HourOfDeparture;

            public Flight(int id, string cityOrigin, string cityDestination, string dateOfDeparture, int hourOfDeparture)
            {
                Id = id;
                CityOrigin = cityOrigin;
                CityDestination = cityDestination;
                DateOfDeparture = dateOfDeparture;
                HourOfDeparture = hourOfDeparture;
            }
        }
        #endregion STRUCTS

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                switch (option)
                {
                    case 1:
                        CreateOneFlight();
                        break;

                    case 2:
                        CreateOneClient();

                        break;

                    case 3:
                        DisplayAllFlights();
                        break;

                    case 4:
                        DisplayAllClients();
                        break;

                    case 5:
                        ModifyOneFlight();
                        break;

                    case 6:
                        ModifyOneClient();
                        break;

                    case 7:
                        Exit();
                        break;


                    case 8:
                        Console.WriteLine("ASSIGN ONE CLIENT TO A FLIGHT");
                        Console.Write("Enter existing flight ID: ");
                        int existingFlightId = ReadInteger(MIN_ID_VALUE, MAX_ID_VALUE);
                        bool flightExists = Array.Exists(flights, flight => flight.Id == existingFlightId);
                        if (flightExists == true)
                        {
                            Console.Write("Enter existing client ID: ");
                            int existingClientId = ReadInteger(MIN_ID_VALUE, MAX_ID_VALUE);
                            bool clientExists = Array.Exists(clients, client => client.Id == existingClientId);
                            if (clientExists == true)
                            {
                                //clients[indexClients] = Flight myNewestFlight;
                                Console.WriteLine("The clientID has been assined to the flightID successfully");
                            }
                            else if (clientExists == false)
                            {
                                Console.WriteLine("Client doesn't exist");
                            }
                        }
                        else if (flightExists == false)
                        {
                            Console.WriteLine("Flight doesn't exist");
                        }

                        break;
                }
            }
            
        }
        public static void DisplayMenu()
        {
            Console.WriteLine("-------------------------");
            Console.Write("MY TRAVEL  \n" +
                "1. Create one flight  \n" +
                "2. Create one client \n" +
                "3. Display all flights \n" +
                "4. Display all clients \n" +
                "5. Modify one flight \n" +
                "6. Modify one client \n" +
                "7. Exit the application \n" +
                "Enter your choice: ");

            option = ReadInteger(1, 7);

            Console.WriteLine("-------------------------");
        }
        private static void CreateOneFlight()
        {
            Console.WriteLine("CREATE ONE FLIGHT");
            if (indexFlights <= flights.Length)
            {
                Console.Write("Enter flight id: ");
                int flightId = ReadInteger(MIN_ID_VALUE, MAX_ID_VALUE);
                Console.Write("Enter city of origin: ");
                string cityOfOrigin = ReadString();
                Console.Write("Enter city of destination: ");
                string cityOfDestination = ReadString();
                Console.Write("Enter date of departure: ");
                string dateOfDeparture = ReadString();
                Console.Write("Enter hour of departure: ");
                int hourOfDeparture = ReadInteger();
                Flight myFlight = new Flight(flightId, cityOfOrigin, cityOfDestination, dateOfDeparture, hourOfDeparture);
                flights[indexFlights] = myFlight;
                indexFlights++;
                Console.WriteLine("The flight has been created successfully");
            }
            else
            {
                Console.WriteLine("You have reached the maximum number of flights");
            }
        }
        private static void CreateOneClient()
        {
            Console.WriteLine("CREATE ONE CLIENT");
            if (indexClients <= clients.Length)
            {
                Console.Write("Enter client id: ");
                int clientId = ReadInteger(MIN_ID_VALUE, MAX_ID_VALUE);
                Console.Write("Enter client user name: ");
                string clientName = ReadString();
                Client myClient = new Client(clientId, clientName);
                clients[indexClients] = myClient;
                indexClients++;
                Console.WriteLine("The client has been created successfully");
            }
            else
            {
                Console.WriteLine("You have reached the maximum number of clients");
            }
        }
        private static void DisplayAllFlights()
        {
            Console.WriteLine("DISPLAY ALL FLIGHTS");
            if (indexFlights > 0)
            {
                for (int i = 0; i < indexFlights; i++)
                {
                    Flight myFlight = flights[i];
                    Console.Write($"Id: {myFlight.Id}\t");
                    Console.Write($"City of origin: {myFlight.CityOrigin}\t");
                    Console.Write($"City of destination: {myFlight.CityDestination}\t");
                    Console.Write($"Date of departure: {myFlight.DateOfDeparture}\t");
                    Console.Write($"Hour of departure: {myFlight.HourOfDeparture}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("There are no flights to display.");
            }
        }
        private static void DisplayAllClients()
        {
            Console.WriteLine("DISPLAY ALL CLIENTS");
            if (indexClients > 0)
            {
                for (int i = 0; i < indexClients; i++)
                {
                    Client myClient = clients[i];
                    Console.Write($"Id: {myClient.Id}\t");
                    Console.Write($"User Name: {myClient.UserName}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("There are no clients to display.");
            }
        }
        private static void ModifyOneFlight()
        {
            Console.WriteLine("MODIFY ONE FLIGHT");
            Console.Write("Enter existing flight ID: ");
            int existingFlightId = ReadInteger(MIN_ID_VALUE, MAX_ID_VALUE);
            bool flightExists = Array.Exists(flights, flight => flight.Id == existingFlightId);
            if (flightExists == true)
            {
                Console.Write("Enter city of origin: ");
                string newCityOfOrigin = ReadString();
                Console.Write("Enter city of destination: ");
                string newCityOfDestination = ReadString();
                Console.Write("Enter date of departure: ");
                string newDateOfDeparture = ReadString();
                Console.Write("Enter hour of departure: ");
                int newHourOfDeparture = ReadInteger();
                Flight myNewFlight = new Flight(existingFlightId, newCityOfOrigin, newCityOfDestination, newDateOfDeparture, newHourOfDeparture);
                flights[indexFlights] = myNewFlight;
                indexFlights++;
                Console.WriteLine("This flight has been updated successfully");
            }
            else if (flightExists == false)
            {
                Console.WriteLine("Flight doesn't exist");
            }
        }
        private static void ModifyOneClient()
        {
            Console.WriteLine("MODIFY ONE CLIENT");
            Console.Write("Enter existing client ID: ");
            int existingClientId = ReadInteger(MIN_ID_VALUE, MAX_ID_VALUE);
            bool clientExists = Array.Exists(clients, client => client.Id == existingClientId);
            if (clientExists == true)
            {
             Console.Write("Enter client user name: ");
            string newClientName = ReadString();
            Client myNewClient = new Client(existingClientId, newClientName);
            clients[indexClients] = myNewClient;
            indexClients++;
            Console.WriteLine("This client has been updated successfully");
            }
            else if(clientExists == false)
            {
                Console.WriteLine("Client doesn't exist");
            }
        }
        public static void Exit()
        {
            Console.WriteLine("Are you sure to exit? Enter 1 for yes, or 0 for no.");
            int exit = ReadInteger(0, 1);
            if (exit == 1)
            {
                Console.WriteLine("Bye!");
                Environment.Exit(0);
            }
        }
        #region OTHER FUNCTIONS
        public static int ReadInteger()
        {
            int toReturn = 0;
            while (!Int32.TryParse(Console.ReadLine(), out toReturn))
            {
                Console.Write("Invalid integer value, please try again: ");
            }

            return toReturn;
        }
        public static int ReadInteger(int min, int max)
        {
            int toReturn = ReadInteger();
            while (!IsWithinRange(toReturn, min, max))
            {
                Console.Write($"The value must be between {min} and {max}. Please try again: ");
                toReturn = ReadInteger();
            }

            return toReturn;
        }
        public static int ReadInteger(int min)
        {
            int toReturn = ReadInteger();
            while (toReturn < min)
            {
                Console.Write($"The value must be greather than or equal to {min}. Please try again: ");
                toReturn = ReadInteger();
            }

            return toReturn;
        }
        public static bool IsWithinRange(int num, int min, int max)
        {
            return num >= min && num <= max;
        }
        public static string ReadString()
        {
            string toReturn = null;
            while (String.IsNullOrEmpty(toReturn))
            {
                toReturn = Console.ReadLine();
            }

            return toReturn;
        }
        #endregion
    
    }
}