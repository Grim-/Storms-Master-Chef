using SideLoader;
using System;

namespace OutwardModTemplate
{
    public class SL_UnLearnRecipeEffect : SL_Effect, ICustomModel
    {
        public Type SLTemplateModel => typeof(SL_UnLearnRecipeEffect);
        public Type GameModel => typeof(UnLearnRecipeEffect);

        public int RecipeID;

        public override void ApplyToComponent<T>(T component)
        {
            SL_UnLearnRecipeEffect learnRecipeEffect = component as SL_UnLearnRecipeEffect;
            learnRecipeEffect.RecipeID = RecipeID;
        }

        public override void SerializeEffect<T>(T effect)
        {
            SL_UnLearnRecipeEffect learnRecipeEffect = effect as SL_UnLearnRecipeEffect;
            this.RecipeID = learnRecipeEffect.RecipeID;
        }
    }

    public class UnLearnRecipeEffect : Effect
    {
        public int RecipeID;

        public override void ActivateLocally(Character _affectedCharacter, object[] _infos)
        {
            Item theItem = ResourcesPrefabManager.Instance.GetItemPrefab(RecipeID);

            if (theItem != null && theItem is RecipeItem recipeItem)
            {
                if (_affectedCharacter.Inventory.RecipeKnowledge.IsItemLearned(RecipeID))
                {
                    _affectedCharacter.Inventory.RecipeKnowledge.RemoveItem(RecipeID);
                }

            }

        }
    }
}
