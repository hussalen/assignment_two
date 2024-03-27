namespace assignment_two
{
    public abstract class Cargo
    {
        public int Mass {get;}
        public string Name {get;}
        private string type;

        public Cargo(string name)
        {
            Name = name;
             
        }
    }
}