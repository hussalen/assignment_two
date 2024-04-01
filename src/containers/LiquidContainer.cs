using assignment_two.src.cargos;
using assignment_two.utils;

namespace assignment_two.src.containers
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        private ContainerUtils cu;

        public LiquidContainer(ContainerUtils containerUtils, uint maxPayLoad)
            : base(containerUtils, maxPayLoad)
        {
            this.cu = containerUtils;
        }

        protected override ContainerUtils.ContainerType SnContainerType
        {
            get { return ContainerUtils.ContainerType.Liquid; }
        }

        public override void LoadContainer(Cargo cargo)
        {
            base.LoadContainer(cargo);
            uint maxForType;
            switch (cargo.Type)
            {
                case CargoUtils.CargoType.Ordinary:
                    maxForType = MaxPayload * 9 / 10;
                    break;
                case CargoUtils.CargoType.Hazardous:
                    maxForType = MaxPayload / 2;
                    IHazardNotifier.SendHazardAlert(SerialNumber);
                    break;
                default:
                    throw new Exception("Unexpected type: " + cargo.Type);
            }
            if (cargo.Mass > maxForType)
            {
                Console.WriteLine(
                    nameof(cargo.Type)
                        + " Mass ("
                        + cargo.Mass
                        + ") > "
                        + maxForType * 100.0 / MaxPayload
                        + "% of maxPayload ("
                        + maxForType
                        + ")"
                );
            }
        }

        public override void EmptyCargo()
        {
            base.EmptyCargo();
            TareWeight = 0;
        }
    }
}
