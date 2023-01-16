using Test.domain.model;

internal interface DataRepository
{

    Response<List<ProductObject>> fetchData();

    Response<List<ProductObject>> fetchData(List<int> childIds);

    List<ProductObjectAtribute> fetchProductObjectAtributes(int productId);

    public int linkWithNewObject(int parentId, string type, string product, string linkName);

    public bool linkWithExistingObject(int parentId, int c, string linkName);

    public void deleteLink(int parentId);

    public List<ObjectItem> fetchObjectItems(int childId);
}
