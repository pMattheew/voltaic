class Storage 
{
    public List<Processor> Processors = [];

    public string? Error;

    public bool HasProcessors()
    {
        return this.Processors.Count > 0;
    }

    public void CreateProcessor()
    {
        this.Processors.Add(new Processor());
    }

    public void ListProcessors(bool withIndex = false)
    {
        for (int i = 0; i < this.Processors.Count; i++)
        {
            if (withIndex)
                Console.Write($" ({i + 1}) ➜  ");
            this.Processors[i].Display();
        }
    }

    public void BuyProcessor(int index, int quantity)
    {
        this.Processors[index].Quantity += quantity;
    }

    public void SellProcessor(int index, int quantity)
    {
        this.Processors[index].Quantity -= quantity;
    }

    public void RemoveProcessor (int index)
    {
        this.Processors.RemoveAt(index);
    }
}