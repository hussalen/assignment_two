namespace assignment_two.src
{
    public class OverfillException : Exception
    {
        public OverfillException(string message)
            : base(message) { }
    }
}
