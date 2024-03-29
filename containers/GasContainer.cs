using assignment_two.utils;

namespace assignment_two.containers
{
    public class GasContainer : Container, IHazardNotifier
    {
        private ContainerUtils cu;
        
        public GasContainer(ContainerUtils cu, uint maxPayLoad) : base(cu, maxPayLoad)
        {
            SnContainerType = ContainerUtils.ContainerType.Liquid;
            this.cu = cu;
        }

        public override void LoadContainer(Cargo cargo)
        {
            base.LoadContainer(cargo);
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
        }

        protected override void EmptyCargo()
        {
            cargo = null;
            TareWeight *= 1/20;
        }
    }
}