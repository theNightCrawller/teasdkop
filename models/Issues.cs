namespace app
{
    public class Issues(string issue)
    {
        public string Issue = issue;
        
        public void Alarm()
        {
            System.Console.WriteLine($"Warrning {Issue}");
        }
    }
}