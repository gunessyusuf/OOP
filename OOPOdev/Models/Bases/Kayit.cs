namespace OOPOdev.Models.Bases
{
    public abstract class Kayit
    {
        public int Id { get; set; }

        

        protected Kayit() 
        {
            
        }

        protected Kayit(int id) 
        {
            Id = id;
        }
    }
}
