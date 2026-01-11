namespace ArtLib2
{
    public class Art
    {
        public int Id { get; set; }
        public string ArtName { get; set; }
        public string ArtType { get; set; }
        public int Price { get; set; }

        public Art(string name, string type, int price)
        {
            ArtName = name;
            ArtType = type;
            Price = price;
        }

        public Art()
        {
            
        }
        public override string ToString()
        {
            return $"Art [Id={Id}, ArtName={ArtName}, ArtType={ArtType}, Price={Price}]";
        }
    }
}
