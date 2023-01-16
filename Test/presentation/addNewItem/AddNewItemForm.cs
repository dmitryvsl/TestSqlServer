using Test.domain.model;
using Test.presentation.mainscreen;

namespace Test.presentation.addNewItem
{
    public partial class AddNewItemForm : Form, AddNewItemView
    {
        public AddNewItemForm(int parentId, OnElementAddedCallback callback, TreeNode selectedNode)
        {
            InitializeComponent();
            this.parentId = parentId;
            this.callback = callback;
            presenter = new AddNewItemPresenter(this, new DataRepositoryImpl());
            presenter.fetchObjects(parentId);
            this.selectedNode = selectedNode;
        }

        private int parentId;
        private AddNewItemPresenter presenter;
        private OnElementAddedCallback callback;
        private TreeNode selectedNode;
        private List<ObjectItem> items;

        private void saveButton_Click(object sender, EventArgs e)
        {
            string type = this.typeTextBox.Text;
            string product = this.productTextBox.Text;
            string linkName = this.linkNameTextBox.Text;
            presenter.addLink(parentId, type, product, linkName);
        }

        public void showMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void closeForm(int insertedId)
        {
            callback.onElementAdded(selectedNode, new ProductObject(parentId, typeTextBox.Text, productTextBox.Text, insertedId));
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (selectObjectComboBox.SelectedIndex != -1)
            {
                int childId = items.First(item => item.product == selectObjectComboBox.SelectedItem).id;
                presenter.addLink(parentId, childId, existingObjectLinkNameTextBox.Text);
            }
        }

        public void closeForm()
        {
            ObjectItem item = items.First(item => item.product == selectObjectComboBox.SelectedItem);
            callback.onElementAdded(selectedNode, new ProductObject(parentId, item.type, item.product, item.id));
            this.Close();
        }

        void AddNewItemView.addComboBoxElements(List<ObjectItem> items)
        {
            this.items = items;
            foreach (ObjectItem item in items)
                selectObjectComboBox.Items.Add(item.product);
        }
    }
}
