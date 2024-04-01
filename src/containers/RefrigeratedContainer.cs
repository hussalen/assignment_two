using System.Diagnostics;
using assignment_two.src.cargos;
using assignment_two.utils;

namespace assignment_two.src.containers
{
    public class RefrigeratedContainer : Container, IHazardNotifier
    {
        private ContainerUtils cu;
        private CargoUtils cargoUtils;

        private CargoUtils.CargoProductType productType;
        private int maxTemperature;

        public RefrigeratedContainer(
            ContainerUtils containerUtils,
            CargoUtils cargoUtils,
            uint maxPayLoad,
            CargoUtils.CargoProductType productType,
            int maxTemperature
        )
            : base(containerUtils, maxPayLoad)
        {
            this.cu = containerUtils;
            this.cargoUtils = cargoUtils;
            this.productType = productType;
            this.maxTemperature = maxTemperature;

            if (productType != CargoUtils.CargoProductType.None)
            {
                if (cargoUtils.GetTempForProduct(productType) >= maxTemperature)
                {
                    throw new Exception(
                        "Failed to create container: temperature of product "
                            + productType
                            + " is greater than/equal to max temperature of container ("
                            + maxTemperature
                            + " degrees celsius)"
                    );
                }
            }
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
                case CargoUtils.CargoType.Ordinary:
                    break;
                default:
                    throw new Exception("Unexpected type: " + cargo.Type);
            }
        }

        public override void EmptyCargo()
        {
            TareWeight = 0;
            base.EmptyCargo();
        }

        public override string ToString()
        {
            return base.ToString()
                + ", Product Type: "
                + productType
                + ", Max Temperature: "
                + maxTemperature;
        }
    }
}
