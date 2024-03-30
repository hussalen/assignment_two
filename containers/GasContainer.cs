using assignment_two.utils;

namespace assignment_two.containers
{
    public class GasContainer : Container, IHazardNotifier
    {
        private ContainerUtils cu;

        public GasContainer(ContainerUtils cu, uint maxPayLoad)
            : base(cu, maxPayLoad)
        {
            this.cu = cu;
        }

        protected override ContainerUtils.ContainerType SnContainerType
        {
            get { return ContainerUtils.ContainerType.Gas; }
        }

        public override void LoadContainer(Cargo cargo)
        {
            switch (cargo.Type)
            {
                case cargoutils.CargoType.Hazardous:
                    IHazardNotifier.SendHazardAlert(SerialNumber);
                    break;
                case cargoutils.CargoType.Gas:
                    break;
                default:
                    throw new Exception("Unexpected type: " + cargo.Type);
            }
            base.LoadContainer(cargo);
        }

        public override void EmptyCargo()
        {
            base.EmptyCargo();
            TareWeight *= 1 / 20;
        }
    }
}
