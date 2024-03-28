using System.Globalization;
using assignment_two.utils;

namespace assignment_two.containers
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        private ContainerUtils cu;
        private int maxPayload;
        public LiquidContainer(ContainerUtils cu, int maxPayLoad) : base(cu, maxPayLoad)
        {
            SnContainerType = ContainerUtils.ContainerType.Liquid;
            this.cu = cu;
            maxPayload = maxPayLoad;
        }

        public override void EmptyCargo()
        {
            CargoContainer = [];
            TareWeight = 0;
        }

        public void SendHazardAlert()
        {
            
            Console.WriteLine("Warning! Hazardous cargo has been added.");
        }
    }
}