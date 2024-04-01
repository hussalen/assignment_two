using assignment_two.src.containers;

namespace assignment_two.utils
{
    public class ContainerUtils
    {
        private ContainerUtils() { }

        public enum ContainerType
        {
            Default,

            Liquid,
            Gas,
            Refrigerated
        }

        private static ContainerUtils instance = null;
        public static ContainerUtils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContainerUtils();
                }
                return instance;
            }
        }
    }
}
