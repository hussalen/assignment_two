using assignment_two.src.cargos;
using assignment_two.utils;

namespace assignment_two.src.containers
{
    public class GasContainer : Container, IHazardNotifier
    {
        private ContainerUtils cu;

        public GasContainer(ContainerUtils containerUtils, uint maxPayLoad)
            : base(containerUtils, maxPayLoad)
        {
            this.cu = containerUtils;
        }

        protected override ContainerUtils.ContainerType SnContainerType
        {
            get { return ContainerUtils.ContainerType.Gas; }
        }

        public override void LoadContainer(Cargo cargo)
        {
            switch (cargo.Type)
            {
                case CargoUtils.CargoType.Hazardous:
                    IHazardNotifier.SendHazardAlert(SerialNumber);
                    break;
                case CargoUtils.CargoType.Gas:
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
