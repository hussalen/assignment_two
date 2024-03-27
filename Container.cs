using System.Globalization;
using assignment_two.utils;

namespace assignment_two
{
    public abstract class Container
    {
        // Container dimensions
        private int mass;
        private int height;
        private int tareWeight;
        private int depth;

        public static string SnContainerType { get; set; } = nameof(ContainerUtils.ContainerType.Default);
        public string SerialNumber { get; set; }
        private static int snUniqueNum;
        public int MaxPayload { get; set; }

        private List<Cargo> container;

        private ContainerUtils cu;

        public Container(ContainerUtils cu, int maxPayLoad)
        {
            this.cu = cu;

            SerialNumber = "KON-" + SnContainerType + "-" + ++snUniqueNum;
            container = [];
            tareWeight = 0;
            MaxPayload = maxPayLoad;
        }

        public abstract void EmptyCargo();

        public void LoadContainer(Cargo cargo) {
            if (cargo.Mass > tareWeight || cargo.Mass > MaxPayload) 
            {
                throw new OverfillException("Mass > maxPayload");
            }
            tareWeight += cargo.Mass;
            container.Add(cargo);
            Console.WriteLine("Adding cargo '" + cargo.Name + "' , weight of cargo: " + cargo.Mass 
            + ", current weight of container: " + tareWeight);
        }

        public void SetContainerType(ContainerUtils.ContainerType ct)
        {
            SnContainerType = nameof(ct);
            SerialNumber = "KON-" + SnContainerType + "-" + snUniqueNum;
        }
    }
}