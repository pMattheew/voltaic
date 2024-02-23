class Storage 
{
    public List<Processor> Processors = [];

    public bool HasProcessors()
    {
        return this.Processors.Count > 0;
    }
}