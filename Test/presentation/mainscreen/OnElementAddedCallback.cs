using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.domain.model;

namespace Test.presentation.mainscreen
{
    public interface OnElementAddedCallback
    {
        public void onElementAdded(TreeNode node, ProductObject product);
    }
}
