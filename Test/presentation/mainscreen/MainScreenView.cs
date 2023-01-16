using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.domain.model;

internal interface MainScreenView : View
{

    void showProductObjects(List<ProductObject> objects);


    void showRootProductObjects(List<ProductObject> objects);
    void showMessage(string message);

    void showAtributes(List<ProductObjectAtribute> atributes);

    

}