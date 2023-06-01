using SideLoader;
using System;
using System.Diagnostics;

namespace OutwardModTemplate
{
    public class SL_LearnRecipeEffect : SL_Effect, ICustomModel
    {
        public Type SLTemplateModel => typeof(SL_LearnRecipeEffect);
        public Type GameModel => typeof(LearnRecipeEffect);

        public string RecipeUID;

        public override void ApplyToComponent<T>(T component)
        {
            LearnRecipeEffect learnRecipeEffect = component as LearnRecipeEffect;
            learnRecipeEffect.RecipeUID = RecipeUID;
        }

        public override void SerializeEffect<T>(T effect)
        {
            LearnRecipeEffect learnRecipeEffect = effect as LearnRecipeEffect;
            this.RecipeUID = learnRecipeEffect.RecipeUID;
        }
    }

    public class LearnRecipeEffect : Effect, ICustomModel
    {
        public string RecipeUID;

        public Type SLTemplateModel => typeof(SL_LearnRecipeEffect);

        public Type GameModel => typeof(LearnRecipeEffect);

        public override void ActivateLocally(Character _affectedCharacter, object[] _infos)
        {
            if (!_affectedCharacter.Inventory.RecipeKnowledge.IsRecipeLearned(RecipeUID))
            {
                Recipe FoundRecipe = TryFindRecipe(RecipeUID);

                if (FoundRecipe != null)
                {
                    _affectedCharacter.Inventory.RecipeKnowledge.LearnRecipe(FoundRecipe);
                }
                else
                {
                    StormCancer_MasterChef.Log.LogMessage($"LearnRecipeEffect :: Cannot find Recipe with UID {RecipeUID}");
                }  
            }
        }


        private Recipe TryFindRecipe(string RecipeUID)
        {
            foreach (var item in RecipeManager.Instance.m_recipes)
            {
                if (item.Value.UID == RecipeUID)
                {
                    return item.Value;
                }
            }

            return null;
        }
    }



}
