namespace assignment_two.src.cargos
{
    public interface IHazardNotifier
    {
        public static void SendHazardAlert(string serialNumber)
        {
            Console.WriteLine(
                "Warning! Hazardous cargo has been added. Serial number: " + serialNumber
            );
        }
    }
}
