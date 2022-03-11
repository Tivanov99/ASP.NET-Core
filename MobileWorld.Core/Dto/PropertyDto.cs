namespace MobileWorld.Core.Dto
{
    public class PropertyDto
    {
        public PropertyDto(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }

        public object? Value { get; set; }
    }
}
