namespace assignment_two
{
    abstract class Container
    {
        // Container dimensions
        private int mass;
        private int height;
        private int tareWeight;
        private int depth;

        private const string snFirstPart = "KON";
        private const string snContainerType = "C";
        private string serialNumber = snFirstPart + "-" + snContainerType + "-";
        private int snUniqueNum = 1;
        private int maxPayload;

        public abstract void emptyCargo();
        public abstract void loadCargo(int mass);

    }
}