using System.Globalization;
using assignment_two.utils;

namespace assignment_two.containers
{
    public class LiquidContainer : Container
    {
        public LiquidContainer(ContainerUtils cu, int maxPayLoad) : base(cu, maxPayLoad)
        {
            SnContainerType = nameof(ContainerUtils.ContainerType.Liquid);
        }

        public override void EmptyCargo()
        {
            container = [];
            tareHeight = 0;
        }
    }
}