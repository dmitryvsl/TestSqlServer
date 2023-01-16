
using System.Xml.Linq;
using Test.data.repository;
using Test.domain.model;
using Test.presentation;
using Test.presentation.addNewItem;
using Test.presentation.mainscreen;

namespace Test
{
    public partial class MainScreen : Form, MainScreenView, OnElementAddedCallback
    {

        private List<ProductNode> lastVisibleNodes = new List<ProductNode>();
        private MainScreenPresenter presenter;


        public MainScreen()
        {
            InitializeComponent();
            presenter = new MainScreenPresenter(this, new DataRepositoryImpl(), new XmlDatabaseExporter());
            presenter.fetchRootProductObjects();

        }

        public void showProductObjects(List<ProductObject> objects)
        {
            List<ProductNode> cachedNodes = new List<ProductNode>(lastVisibleNodes);
            lastVisibleNodes.Clear();
            foreach (ProductObject obj in objects)
            {
                foreach (ProductNode productNode in cachedNodes)
                {
                    if (productNode.childId == obj.parentId)
                    {
                        TreeNode node = new TreeNode();

                        node.Text = obj.product + obj.childId;
                        node.Name = "id" + obj.childId;

                        productNode.node.Nodes.Add(node);

                        lastVisibleNodes.Add(new ProductNode(obj.childId, node));
                    }
                }
            }

        }

        private void productObjectsTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            List<int> childIds = getChildIdsFromNodes();

            presenter.fetchProductObjects(childIds);

        }

        public void showMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void showRootProductObjects(List<ProductObject> objects)
        {
            List<int> addedProductParentIds = new List<int>();
            foreach (ProductObject obj in objects)
            {
                if (addedProductParentIds.FindIndex(parentId => parentId == obj.parentId) == -1)
                {
                    TreeNode node = new TreeNode();

                    node.Text = obj.product;
                    node.Name = "id" + obj.parentId;
                    productObjectsTree.Nodes.Add(node);

                    lastVisibleNodes.Add(new ProductNode(obj.parentId, node));
                    addedProductParentIds.Add(obj.parentId);
                }

            }

            List<int> childIds = getChildIdsFromNodes();
            presenter.fetchProductObjects(childIds);
        }

        private List<int> getChildIdsFromNodes()
        {
            List<int> childIds = new List<int>();
            foreach (ProductNode productNode in lastVisibleNodes)
            {
                childIds.Add(productNode.childId);
            }
            return childIds;

        }


        public void showAtributes(List<ProductObjectAtribute> atributes)
        {
            atributesContentLabel.Text = "";
            foreach (ProductObjectAtribute atribute in atributes)
            {
                atributesContentLabel.Text = atribute.name.Trim(' ') + ": " + atribute.value + "\n";
            }
        }

        private void productObjectsTree_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            productObjectsTree.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Left)
            {
                presenter.fetchProductObjectAtributes(int.Parse(e.Node.Name.Substring(2)));
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == contextMenuStrip1.Items[0].Name)
            {
                TreeNode node = productObjectsTree.SelectedNode;
                AddNewItemForm form = new AddNewItemForm(int.Parse(node.Name.Substring(2)), this, productObjectsTree.SelectedNode);
                form.Show();
            }
            else if (e.ClickedItem.Name == contextMenuStrip1.Items[1].Name)
            {
                presenter.deleteItem(int.Parse(productObjectsTree.SelectedNode.Name.Substring(2)));
                productObjectsTree.SelectedNode.Remove();
            }
        }

        public void onElementAdded(TreeNode selectedNode, ProductObject productObject)
        {
            TreeNode node = new TreeNode();

            node.Text = productObject.product;
            node.Name = "id" + productObject.childId;

            selectedNode.Nodes.Add(node);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = null;
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                    path = dialog.SelectedPath;
            if (path != null) presenter.exportToXml(path);
        }
    }

    class ProductNode
    {
        public int childId { get; private set; }

        public TreeNode node { get; private set; }

        public ProductNode(int childId, TreeNode node)
        {
            this.childId = childId;
            this.node = node;
        }
    }
}
