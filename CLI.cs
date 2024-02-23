class CLI
{
    const string CoolLogo = @" __      __   _ _        _      
 \ \    / /  | | |      (_)     
  \ \  / /__ | | |_ __ _ _  ___ 
   \ \/ / _ \| | __/ _` | |/ __|
    \  / (_) | | || (_| | | (__ 
     \/ \___/|_|\__\__,_|_|\___|
                                ";

    string? Result;
    public void Show()
    {
        Console.Clear();
        Console.WriteLine(CoolLogo);
        Console.WriteLine(@$" ⁜ Welcome to Voltaic© CLI! ⁜

   Select an option to continue
 
 ➜  1 • Create new processor
 ➜  2 • List active processors
 ➜  3 • Remove processors
 ➜  4 • Buy processors
 ➜  5 • Sell processors
 {Result}
 ➜  0 • Exit");
        Console.Write("\n >  ");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int answer))
            this.Decide(answer);
        else
            this.Show();
    }

    private void Decide(int answer)
    {
        bool exit = false;
        switch (answer)
        {
            case 1:
                Console.WriteLine("Creating...");
                this.Result = "\n ⁜ Processor created successfully! \n";
                break;
            case 2:
                Console.WriteLine("Listing...");
                break;
            case 3:
                Console.WriteLine("Removing...");
                this.Result = "\n ⁜ Processor removed successfully! \n";
                break;
            case 4:
                Console.WriteLine("Buying...");
                break;
            case 5:
                Console.WriteLine("Selling...");
                break;
            case 0:
                Console.WriteLine("\n ⁜  Exiting Voltaic© CLI...\n ⁜  It is sad to see you go =(\n");
                exit = true;
                break;
        }
        if (!exit) this.Show();
    }
    
    private void Create()
    {
        
    }
}