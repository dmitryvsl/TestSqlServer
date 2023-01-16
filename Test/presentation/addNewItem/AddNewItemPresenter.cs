using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.domain.model;

namespace Test.presentation.addNewItem
{
    internal class AddNewItemPresenter : Presenter
    {
        private AddNewItemView addNewItemView;
        private DataRepository repository;

        public AddNewItemPresenter(AddNewItemView addNewItemView, DataRepository repository)
        {
            this.addNewItemView = addNewItemView;
            this.repository = repository;
        }

        public void addLink(int parentId, string type, string product, string linkName)
        {
            int insertedId = repository.linkWithNewObject(parentId, type, product, linkName);
            if (insertedId != -1)
            {
                addNewItemView.showMessage("Элемент успешно сохранен");
                addNewItemView.closeForm(insertedId);
            }
            else
                addNewItemView.showMessage("Произошла ошибка во время сохранения файла");

        }

        public void addLink(int parentId, int childId, string linkName)
        {
            bool isSuccessed = repository.linkWithExistingObject(parentId, childId, linkName);
            if (isSuccessed)
            {
                addNewItemView.showMessage("Элемент успешно сохранен");
                addNewItemView.closeForm();
            }
            else
                addNewItemView.showMessage("Произошла ошибка во время сохранения файла");

        }


        public void fetchObjects(int childId)
        {
            List<ObjectItem> items = repository.fetchObjectItems(childId);
            addNewItemView.addComboBoxElements(items);
        }
    }
}
