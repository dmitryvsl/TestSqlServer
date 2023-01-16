using Test.domain.model;
using Test.domain.repository;

namespace Test.presentation
{
    internal class MainScreenPresenter : Presenter
    {
        public MainScreenPresenter(MainScreenView view, DataRepository repository, DatabaseExporter exporter)
        {
            mainScreenView = view;
            this.repository = repository;
            this.exporter = exporter;
        }

        private MainScreenView mainScreenView;
        private DataRepository repository;
        private DatabaseExporter exporter;

        public void fetchProductObjects(List<int> childIds)
        {
            if (childIds.Count == 0) return;


            Response<List<ProductObject>> data = repository.fetchData(childIds);

            if (data is Response<List<ProductObject>>.Error)
            {
                mainScreenView.showMessage(((Response<List<ProductObject>>.Error)data).message);
                return;
            }
            List<ProductObject> products = ((Response<List<ProductObject>>.Success)data).data;

            mainScreenView.showProductObjects(products);
        }


        public void fetchRootProductObjects()
        {
            Response<List<ProductObject>> data = repository.fetchData();
            if (data is Response<List<ProductObject>>.Error)
            {
                mainScreenView.showMessage(((Response<List<ProductObject>>.Error)data).message);
                return;
            }

            List<ProductObject> products = ((Response<List<ProductObject>>.Success)data).data;

            mainScreenView.showRootProductObjects(products);
        }


        public void fetchProductObjectAtributes(int id)
        {
            mainScreenView.showAtributes(repository.fetchProductObjectAtributes(id));
        }


        public void deleteItem(int parentId)
        {
            repository.deleteLink(parentId);
        }

        public void exportToXml(string path)
        {
            exporter.export($"{path}\\database.xml");
        }
    }
}

