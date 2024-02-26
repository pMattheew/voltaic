class CLI(Storage s)
{
    const string CoolLogo = @" __      __   _ _        _      
 \ \    / /  | | |      (_)     
  \ \  / /__ | | |_ __ _ _  ___ 
   \ \/ / _ \| | __/ _` | |/ __|
    \  / (_) | | || (_| | | (__ 
     \/ \___/|_|\__\__,_|_|\___|
                                ";

    string? Result;
    string? Error;
    readonly Storage Storage = s;

    public void Show()
    {
        ResetView();
        Console.WriteLine(@$" ⁜ Welcome to Voltaic© CLI! ⁜

   Select an option to continue
 
 ➜  1 • Create new processor
 ➜  2 • List active processors
 ➜  3 • Remove processors
 ➜  4 • Buy processors
 ➜  5 • Sell processors
 {Result + Error}
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
        ResetView();
        bool exit = false;
        switch (answer)
        {
            case 1:
                this.Storage.CreateProcessor();
                this.Result = "\n ⁜ Processor created successfully! \n";
                break;
            case 2:
                this.ListProcessorsCLI();

                break;
            case 3:
                Console.WriteLine("Removing...");
                this.Result = "\n ⁜ Processor removed successfully! \n";
                break;
            case 4:
                this.Storage.Buy();
                break;
            case 5:
                this.Storage.Sell();
                break;
            case 0:
                Console.WriteLine("\n ⁜  Exiting Voltaic© CLI...\n ⁜  It is sad to see you go =(\n");
                exit = true;
                break;
        }
        if (!exit) this.Show();
    }

    private static void ResetView()
    {
        Console.Clear();
        Console.WriteLine(CoolLogo);
    }

    private void ListProcessorsCLI()
    {
        bool back = false;

        while (!back) 
        {
            Console.WriteLine($"\n ⁜  There are a total of {this.Storage.Processors.Count} processors:\n");
            this.Storage.ListProcessors();
            int res = Input.GetInt("\nSend \"0\" to return.");
            if(res == 0) back = true;
        }
    }
}