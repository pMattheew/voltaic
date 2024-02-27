using System.Globalization;

class CLI(Storage s)
{
    const string CoolLogo = @" __      __   _ _        _      
 \ \    / /  | | |      (_)     
  \ \  / /__ | | |_ __ _ _  ___ 
   \ \/ / _ \| | __/ _` | |/ __|
    \  / (_) | | || (_| | | (__ 
     \/ \___/|_|\__\__,_|_|\___|
                                ";

    string? _error;
    string? Error
    {
        get { return _error; }
        set { _error = String.IsNullOrEmpty(value) ? "" : $"\n ×  {value}\n"; }
    }

    string? _result;
    string? Result
    {
        get { return _result; }
        set { _result = String.IsNullOrEmpty(value) ? "" : $"\n ⁜  {value}\n"; }
    }
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

        this.Error = "";
        this.Result = "";

        int answer = Input.GetInt("");

        if (answer >= 2 && answer <= 5 && !this.Storage.HasProcessors())
        {
            this.Error = "There is no processors to do this action. Try creating some.";
            this.Show();
        }
        else
            this.Decide(answer);
    }

    private void Decide(int answer)
    {
        ResetView();
        bool exit = false;
        switch (answer)
        {
            case 1:
                this.Storage.CreateProcessor();
                this.Result = "Processor created successfully!";
                break;
            case 2:
                this.ListProcessorsCLI();
                break;
            case 3:
                this.RemoveProcessorCLI();
                this.Result = "Processor removed successfully!";
                break;
            case 4:
                this.TradeProcessorsCLI();
                break;
            case 5:
                this.TradeProcessorsCLI(true);
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
            int res = Input.GetInt("\n •  Send \"0\" to return.");
            if (res == 0) back = true;
        }
    }

    private void TradeProcessorsCLI(bool sell = false)
    {
        int total = this.Storage.Processors.Count;

        void TradeProcessor(int index)
        {
            Processor p = this.Storage.Processors[index];
            string model = p.ModelName;
            if (sell && p.Quantity == 0)
                this.Error = $"You need to have at least one item of \"{model}\" in storage before selling.";
            else
            {
                Console.WriteLine($"\n •  Selected processor: \"{model}\"");
                int quantity = Input.GetInt($" •  How many processors you'd like to {(sell ? "sell" : "buy more")}?");
                if (sell)
                    this.Storage.SellProcessor(index, quantity);
                else
                    this.Storage.BuyProcessor(index, quantity);
                this.Result = $"{(sell ? "Sale" : "Purchase")} successful! You {(sell ? "sold" : "bought")} {quantity} processors model \"{model}\"";
            }
        }

        if (total == 1)
            TradeProcessor(0);
        else
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine($"\n ⁜  Choose which processor you want to {(sell ? "sell" : "buy")}:\n");
                this.Storage.ListProcessors(true);
                int res = Input.GetInt($"{Error} •  Send a listed number to select a processor\n •  Send \"0\" to return.");
                if (res == 0)
                    back = true;
                else
                {
                    if (res > total || res < 0)
                        this.Error = $"You must select a processor between 1 and {total}";
                    else
                    {
                        int index = res - 1;
                        TradeProcessor(index);
                        back = true;
                    }
                }
            }
        }
    }

    private void RemoveProcessorCLI()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine($"\n ⁜  Choose which processor you want to remove:\n");
            this.Storage.ListProcessors(true);
            int res = Input.GetInt($"{Error} •  Send a listed number to select a processor\n •  Send \"0\" to return.");
            if (res == 0)
                back = true;
            else
            {
                this.Storage.RemoveProcessor(res - 1);
                back = true;
            }
        }
    }
}