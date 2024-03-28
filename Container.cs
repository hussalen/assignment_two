using System.Globalization;
using assignment_two.utils;

namespace assignment_two
{
    public abstract class Container
    {
        // Container dimensions
        private int mass;
        private int height;
        public int TareWeight { get; set; }
        private int depth;

        public static ContainerUtils.ContainerType SnContainerType { get; set; } = ContainerUtils.ContainerType.Default;
        public string SerialNumber { get; set; }
        private static int snUniqueNum;
        public int MaxPayload { get; set; }

        public List<Cargo> CargoContainer;

        private ContainerUtils cu;

        public Container(ContainerUtils cu, int maxPayLoad)
        {
            this.cu = cu;

            SerialNumber = "KON-" + SnContainerType + "-" + ++snUniqueNum;
            CargoContainer = [];
            TareWeight = 0;
            MaxPayload = maxPayLoad;
        }

        public abstract void EmptyCargo();

        public void LoadContainer(Cargo cargo) {
            if (cargo.Mass > TareWeight || cargo.Mass > MaxPayload) 
            {
                throw new OverfillException("Mass > maxPayload");
            }
            TareWeight += cargo.Mass;
            CargoContainer.Add(cargo);
            Console.WriteLine("Adding cargo '" + cargo.Name + "' , weight of cargo: " + cargo.Mass 
            + ", current weight of container: " + TareWeight);
        }

        public void SetContainerType(ContainerUtils.ContainerType ct)
        {
            SnContainerType = ct;
            SerialNumber = "KON-" + nameof(SnContainerType) + "-" + snUniqueNum;
        }
    }
}