
using Test.domain.model;

namespace Test.presentation.addNewItem
{
    internal interface AddNewItemView : View
    {
        void showMessage(string message);

        void closeForm(int insertedId);
        void closeForm();

        void addComboBoxElements(List<ObjectItem> items);
    }
}
