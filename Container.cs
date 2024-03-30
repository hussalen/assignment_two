using assignment_two.utils;

namespace assignment_two
{
    public abstract class Container
    {
        // Container dimensions
        private uint mass;
        private uint height;
        public uint TareWeight { get; set; }
        private uint depth;

        protected abstract ContainerUtils.ContainerType SnContainerType { get; }
        protected string SerialNumber { get; private set; }
        private static int snUniqueNum;
        protected uint MaxPayload { get; private set; }

        public Cargo? cargo;

        private ContainerUtils cu;

        protected Container(ContainerUtils cu, uint maxPayLoad)
        {
            this.cu = cu;

            SerialNumber = "KON-" + SnContainerType.ToString()[0] + "-" + ++snUniqueNum;
            TareWeight = 0;
            MaxPayload = maxPayLoad;
        }

        public virtual void EmptyCargo()
        {
            if (cargo != null)
            {
                cargo = null;
                Console.WriteLine(
                    "Container "
                        + SerialNumber
                        + " that contained "
                        + SnContainerType
                        + " has been emptied."
                );
                return;
            }
            Console.WriteLine("EmptyCargo() failed: Container is already empty.");
        }

        public virtual void LoadContainer(Cargo cargo)
        {
            TareWeight += cargo.Mass;
            if (cargo.Mass > TareWeight || cargo.Mass > MaxPayload)
            {
                throw new OverfillException(
                    "Mass ( " + cargo.Mass + ") > maxPayload (" + MaxPayload + ")"
                );
            }
            this.cargo = cargo;
            Console.WriteLine(
                "Adding cargo '"
                    + cargo.Name
                    + "' , weight of cargo: "
                    + cargo.Mass
                    + ", current weight of container: "
                    + TareWeight
            );
            Console.WriteLine("Max payload weight of " + SerialNumber + ": " + MaxPayload);
        }

        public void SetContainerType(ContainerUtils.ContainerType ct)
        {
            SerialNumber = "KON-" + SnContainerType.ToString()[0] + "-" + snUniqueNum;
        }
    }
}
