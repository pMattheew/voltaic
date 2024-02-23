namespace voltaic;

class Program
{
    static void Main(string[] args)
    {
        Storage s = new();
        CLI voltaic = new(s);
        voltaic.Show();
    }
}
