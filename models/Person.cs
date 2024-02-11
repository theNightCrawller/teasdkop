
namespace app
{
    public class Person(string id, string name)
    {
        public string Id { get; set; } = id;
        public string Name { get; set; } = name;

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
