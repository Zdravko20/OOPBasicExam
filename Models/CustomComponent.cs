namespace SystemSplit.Models
{
    public abstract class CustomComponent
    {
        protected CustomComponent(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }
    }
}
