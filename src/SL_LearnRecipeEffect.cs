using SideLoader;
using System;

namespace OutwardModTemplate
{
    public class SL_LearnRecipeEffect : SL_Effect, ICustomModel
    {
        public Type SLTemplateModel => typeof(SL_LearnRecipeEffect);
        public Type GameModel => typeof(LearnRecipeEffect);

        public int RecipeID;

        public override void ApplyToComponent<T>(T component)
        {
            SL_LearnRecipeEffect learnRecipeEffect = component as SL_LearnRecipeEffect;
            learnRecipeEffect.RecipeID = RecipeID;
        }

        public override void SerializeEffect<T>(T effect)
        {
            SL_LearnRecipeEffect learnRecipeEffect = effect as SL_LearnRecipeEffect;
            this.RecipeID = learnRecipeEffect.RecipeID;
        }
    }

    public class LearnRecipeEffect : Effect
    {
        public int RecipeID;

        public override void ActivateLocally(Character _affectedCharacter, object[] _infos)
        {
            Item theItem = ResourcesPrefabManager.Instance.GetItemPrefab(RecipeID);

            if (theItem != null && theItem is RecipeItem recipeItem)
            {
                if (!_affectedCharacter.Inventory.RecipeKnowledge.IsRecipeLearned(recipeItem.UID))
                {
                    _affectedCharacter.Inventory.RecipeKnowledge.LearnRecipe(recipeItem.Recipe);
                }

            }

        }
    }

}
