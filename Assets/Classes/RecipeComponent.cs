using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts;

namespace Assets.Classes
{
    [Serializable]
    public class RecipeComponent
    {
        public IngredientData secondIngredient;
        public IngredientData result;
    }

}
