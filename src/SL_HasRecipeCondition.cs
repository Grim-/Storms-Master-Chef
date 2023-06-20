using SideLoader;
using System;

namespace OutwardModTemplate
{
    public class SL_HasRecipeCondition : SL_EffectCondition, ICustomModel
    {
        public Type SLTemplateModel => typeof(SL_HasRecipeCondition);
        public Type GameModel => typeof(LearnCustomRecipeEffect);

        public string RecipeUID;

        public override void ApplyToComponent<T>(T component)
        {
            SL_HasRecipeCondition learnRecipeEffect = component as SL_HasRecipeCondition;

            learnRecipeEffect.RecipeUID = RecipeUID;
        }

        public override void SerializeEffect<T>(T effect)
        {
            SL_HasRecipeCondition learnRecipeEffect = effect as SL_HasRecipeCondition;
            this.RecipeUID = learnRecipeEffect.RecipeUID;
        }
    }

    public class HasRecipeCondition : EffectCondition
    {
        public string RecipeUID;

        public override bool CheckIsValid(Character _affectedCharacter)
        {
            return _affectedCharacter.Inventory.RecipeKnowledge.IsRecipeLearned(RecipeUID);

        }
    }
}
