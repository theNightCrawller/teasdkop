
namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            CsvDatabase database = new CsvDatabase("db/person.csv");
            Building appartment = new Building("apartment complex1", "randomAdress 123");

            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add Person to database");
                Console.WriteLine("2. Delete Person by ID from database");
                Console.WriteLine("3. Get All People in database");
                Console.WriteLine("4. Update Person by ID in database");
                Console.WriteLine("5. Manage the building");
                Console.WriteLine("6. Exit");


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
                            database.AddPerson(new Employee(id, name, department));
                        }
                        else
                        {
                            database.AddPerson(new Person(id, name));
                        }
                        break;
                    case "2":
                        Console.Write("Enter ID to delete: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        database.DeletePersonById(deleteId);
                        break;
                    case "3":
                        List<Person> people = database.GetAllPeople();
                        foreach (var person in people)
                        {
                            Console.WriteLine($"ID: {person.Id}, Name: {person.Name}");
                        }
                        break;
                    case "4":
                        Console.Write("Enter ID to update: ");
                        int updateId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        database.UpdatePersonById(updateId, new Person(updateId.ToString(), newName));
                        break;
                    case "5":
                        appartment.StartBuildingManagement();
                        break;
                    case "6":
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
    }

}

