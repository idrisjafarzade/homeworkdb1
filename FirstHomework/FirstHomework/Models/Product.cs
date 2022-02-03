namespace FirstHomework.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Categorie Categorie{ get; set; }
        public Type Type { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Price + " " + Categorie.Name + " " + Type.Name;
        }

    }
}
