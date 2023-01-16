namespace Test.domain.model
{
    public class ProductObject
    {
        public int parentId { get; private set; }
        public int childId { get; private set; }

        public string type { get; private set; }
        public string product { get; private set; }


        public ProductObject(int id, string type, string product, int childId)
        {
            this.parentId = id;
            this.type = type;
            this.product = product;
            this.childId = childId;
        }
    }
}
