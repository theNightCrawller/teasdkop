namespace app
{
    public class CsvDatabase(string filePath)
    {
        private string _filePath = filePath;

        public void AddPerson(Person person)
        {
            try
            {
                string data;
                if (person is Employee)
                {
                    Employee employee = (Employee)person;
                    data = $"{employee.Id},{employee.Name},{employee.Department}";
                }
                else
                {
                    data = $"{person.Id},{person.Name}";
                }

                using (StreamWriter writer = File.AppendText(_filePath))
                {
                    writer.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }
        public void DeletePersonById(int id)
        {
            string[] lines = File.ReadAllLines(_filePath);

            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 1 && int.TryParse(parts[0], out int currentId))
                    {

                        if (currentId != id)
                        {
                            writer.WriteLine(line);
                        }
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public List<Person> GetAllPeople()
        {
            List<Person> people = new List<Person>();
            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 2)
                        {
                            string id = parts[0];
                            string name = parts[1];

                            if (parts.Length >= 3)
                            {
                                string department = parts[2];
                                people.Add(new Employee(id, name, department));
                            }
                            else
                            {
                                people.Add(new Person(id, name));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return people;
        }
        public void UpdatePersonById(int id, Person updatedPerson)
        {
            string[] lines = File.ReadAllLines(_filePath);

            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 1 && int.TryParse(parts[0], out int currentId))
                    {
                        if (currentId == id)
                        {
                            writer.WriteLine($"{updatedPerson.Id},{updatedPerson.Name}");
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

    }
}
