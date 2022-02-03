namespace FirstHomework.Models
{
    public class Type
    {   
        public int Id { get; set; } 
        public string Name { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
}
