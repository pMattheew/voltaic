class Processor
{
    public string ModelName { get; set; }
    public float Price { get; set; }
    public int Quantity = 0;
    public int NumberOfCores { get; set; }
    public float ClockSpeed { get; set; }
    public string Architecture { get; set; }

    public Processor()
    {
        this.ModelName = Input.GetString(" •  What epic name shall we bestow upon this chip?", "That cool processor");

        this.Price = Input.GetFloat(" •  Market domination comes at a price. What'll it be?");

        this.NumberOfCores = Input.GetInt(" •  One core, two cores, let's go for broke! How many cores?");

        this.ClockSpeed = Input.GetFloat(" •  Need for speed? Push those clock cycles to the limit! What's the clock speed?");

        this.Architecture = Processor.SetArchitecture();
    }

    static string SetArchitecture()
    {

        string result = "";
        bool isValidArchitecture = false;
        string sentence = " •  The blueprint matters! What kind of architecture are we building with? (x86) (x64)";

        while (!isValidArchitecture)
        {
            string input = Input.GetString(sentence);
            bool is86or64 = input.Equals("x86", StringComparison.OrdinalIgnoreCase) || input.Equals("x64", StringComparison.OrdinalIgnoreCase);
            if (is86or64)
            {
                result = input;
                isValidArchitecture = true;
            }
            else
                sentence = "Invalid architecture. Send \"x86\" or \"x64\" to be valid.";
        }

        return result;
    }

    public void Display()
    {
        Console.WriteLine($" ${this.Price} un. • {this.Quantity} in storage • [{this.Architecture}] {this.ModelName} {this.NumberOfCores} core(s) {this.ClockSpeed} GHz");
    }


}