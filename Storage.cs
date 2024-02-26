class Storage 
{
    public List<Processor> Processors = [];

    string? Error;

    public bool HasProcessors()
    {
        return this.Processors.Count > 0;
    }

    public void CreateProcessor()
    {
        this.Processors.Add(new Processor());
    }

    public void ListProcessors()
    {
        foreach (Processor p in this.Processors)
        {
            p.Display();
        }
    }

    public void Buy()
    {
        if(!this.HasProcessors()) this.Error = "There is no products to buy. Try creating some.";
    }

    public void Sell()
    {
        if(!this.HasProcessors()) this.Error = "There is no products to sell. Try creating some.";
    }
}