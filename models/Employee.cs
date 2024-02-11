namespace app
{
    public class Employee(string id, string name, string department) : Person(id, name)
    {
        public string Department  = department;
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name} department:{Department}";
        }
    }
}