

namespace app
{
    public class Building(string name, string address)
    {
        public TemperatureControlDevice temperatureControlDevice = new TemperatureControlDevice("temp Device");
        public PowerGridControlDevice powerGridControlDevice = new PowerGridControlDevice("power gird");
        public LightingControlDevice lightingControlDevice = new LightingControlDevice("lights controls");
        public List<Person> ListOfPeopleWhoEntered = [];
        public string Name = name;
        public string Address = address;
        public bool isOpen = true;

        public void EnterTheBuilding(Person person)
        {
            CsvDatabase database = new CsvDatabase("db/person.csv");
            List<Person> authorizedPeople = database.GetAllPeople();

            ListOfPeopleWhoEntered.Add(person);

            System.Console.WriteLine($"{person} entered the building");
            if (!authorizedPeople.Any(p => p.Id == person.Id))
            {
                System.Console.WriteLine($"{person} is not authorized to enter");
                Issues breakIn = new Issues("Intruder");
                breakIn.Alarm();
            }

        }

        public void WhoIsInBuilding()
        {
            foreach (var person in ListOfPeopleWhoEntered)
            {
                System.Console.WriteLine($"{person} is in the building");
            }
        }

        public void ExitTheBuilding(string personId)
        {
            Person personExiting = ListOfPeopleWhoEntered.FirstOrDefault(person => person.Id == personId);

            if (personExiting != null)
            {
                ListOfPeopleWhoEntered.Remove(personExiting);
                System.Console.WriteLine($"{personExiting} exited the building");
            }
            else
            {
                System.Console.WriteLine($"person with this id: {personId} is not in building");
            }

        }
        public void CloseGates()
        {
            if (PowerGridControlDevice.IsGridOn)
            {
                System.Console.WriteLine("closing the gates");
                isOpen = false;
            }
            else
            {
                System.Console.WriteLine("power is off");
            }
        }

        public void OpenGates()
        {
            if (PowerGridControlDevice.IsGridOn)
            {
                System.Console.WriteLine("opening the gates");
                isOpen = true;
            }
            else
            {
                System.Console.WriteLine("power is off");
            }
        }
        public void StartBuildingManagement()
        {
            bool running = true;
            while (running)
            {
                System.Console.WriteLine($"Managing building: {Name}");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Enter the building");
                Console.WriteLine("2. Exit the building");
                Console.WriteLine("3. View who is currently in the building");
                Console.WriteLine("4. Check if gates are open");
                Console.WriteLine("5. Close gates");
                Console.WriteLine("6. Open gates");
                Console.WriteLine("7. Report issue");
                Console.WriteLine("8. Turn on Temperature Control Device");
                Console.WriteLine("9. Turn off Temperature Control Device");
                Console.WriteLine("10. Adjust Temperature");
                Console.WriteLine("11. View current Temperature");
                Console.WriteLine("12. Turn on Lighting Control Device");
                Console.WriteLine("13. Turn on Power Grid Control Device");
                Console.WriteLine("14. Turn off Power Grid Control Device");
                Console.WriteLine("15. Turn on Lighting Control Device");
                Console.WriteLine("16. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter ID: ");
                        string id = Console.ReadLine();
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Is this an employee? (Y/N): ");
                        string isEmployeeInput = Console.ReadLine();
                        if (isEmployeeInput.ToLower() == "y")
                        {
                            Console.Write("Enter Department: ");
                            string department = Console.ReadLine();
                            EnterTheBuilding(new Employee(id, name, department));
                        }
                        else
                        {
                            EnterTheBuilding(new Person(id, name));
                        }
                        break;
                    case "2":
                        Console.Write("Enter ID to delete: ");
                        string deleteId = Console.ReadLine();
                        ExitTheBuilding(deleteId);
                        break;
                    case "3":
                        WhoIsInBuilding();
                        break;
                    case "4":
                        Console.WriteLine(isOpen ? "Gates are already open." : "Gates are closed.");
                        break;
                    case "5":
                        CloseGates();
                        break;
                    case "6":
                        OpenGates();
                        break;
                    case "7":
                        ReportIssue();
                        break;
                    case "8":
                        temperatureControlDevice.TurnOn();
                        break;
                    case "9":
                        temperatureControlDevice.TurnOff();
                        break;
                    case "10":
                        Console.Write("Enter desired temperature: ");
                        int desiredTemp = Convert.ToInt32(Console.ReadLine());
                        temperatureControlDevice.AdjustTemperature(desiredTemp);
                        break;
                    case "11":
                        temperatureControlDevice.CurrentTemeparture();
                        break;
                    case "12":
                        lightingControlDevice.TurnOn();
                        break;
                    case "13":
                        powerGridControlDevice.TurnOn();
                        break;
                    case "14":
                        powerGridControlDevice.TurnOff();
                        break;
                    case "15":
                        lightingControlDevice.TurnOff();
                        break;
                    case "16":
                        running = false;
                        Console.WriteLine("Exiting program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public void ReportIssue()
        {
            Console.Write("Enter issue description: ");
            string issueDescription = Console.ReadLine();
            Issues newIssue = new Issues(issueDescription);
            newIssue.Alarm();
        }
    }
}