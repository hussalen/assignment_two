using assignment_two.utils;

namespace assignment_two.containers
{
    public class RefrigeratedContainer : Container, IHazardNotifier
    {
        private ContainerUtils cu;
        
        public RefrigeratedContainer(ContainerUtils cu, uint maxPayLoad) : base(cu, maxPayLoad)
        {
            this.cu = cu;
        }

        protected override ContainerUtils.ContainerType SnContainerType
        {
            get { return ContainerUtils.ContainerType.Refrigerated; }
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