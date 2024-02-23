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
        this.ResetView();
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
        this.ResetView();
        bool exit = false;
        switch (answer)
        {
            case 1:
                this.Create();
                this.Result = "\n ⁜ Processor created successfully! \n";
                break;
            case 2:
                this.List();
                break;
            case 3:
                Console.WriteLine("Removing...");
                this.Result = "\n ⁜ Processor removed successfully! \n";
                break;
            case 4:
                this.Buy();
                break;
            case 5:
                this.Sell();
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
        this.Storage.Processors.Add(new Processor());
    }

    private void List()
    {
        
        bool exit = false;

        while (!exit) 
        {
            Console.WriteLine($"\n ⁜  There are a total of {this.Storage.Processors.Count} processors:\n");
            foreach (Processor p in this.Storage.Processors)
            {
                Console.WriteLine($" •  ({p.Architecture}) {p.ModelName} {p.NumberOfCores} core(s) {p.ClockSpeed} GHz | {p.Quantity} in storage");
            }
            int res = Input.GetInt("\nSend \"0\" to return.");
            if(res == 0) exit = true;
        }

    }

    private void Remove()
    {

    }

    private void Buy()
    {
        if(!this.Storage.HasProcessors()) this.Error = "\n ×  There is no products to buy. Try creating some.\n";
    }

    private void Sell()
    {
        if(!this.Storage.HasProcessors()) this.Error = "\n ×  There is no products to sell. Try creating some.\n";

    }

    private void ResetView()
    {
        Console.Clear();
        Console.WriteLine(CoolLogo);
    }
}