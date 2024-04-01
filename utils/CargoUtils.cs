namespace assignment_two.utils
{
    public class CargoUtils
    {
        private Dictionary<CargoProductType, float> productTemp;

        public enum CargoType
        {
            Hazardous,
            Ordinary,
            Gas,
        }

        public enum CargoProductType
        {
            None,
            Bananas,
            Chocolate,
            Fish,
            Meat,
            IceCream,
            FrozenPizza,
            Cheese,
            Sausages,
            Butter,
            Eggs
        }

        public float GetTempForProduct(CargoProductType prodType)
        {
            return productTemp[prodType];
        }

        private CargoUtils()
        {
            productTemp = new Dictionary<CargoProductType, float>()
            {
                { CargoProductType.Bananas, 13.3f },
                { CargoProductType.Chocolate, 18 },
                { CargoProductType.Fish, 2 },
                { CargoProductType.Meat, -15 },
                { CargoProductType.IceCream, -18 },
                { CargoProductType.FrozenPizza, -30 },
                { CargoProductType.Cheese, 7.2f },
                { CargoProductType.Sausages, 5 },
                { CargoProductType.Butter, 20.5f },
                { CargoProductType.Eggs, 19 }
            };
        }

        private static CargoUtils instance = null;
        public static CargoUtils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CargoUtils();
                }
                return instance;
            }
        }
    }
}
