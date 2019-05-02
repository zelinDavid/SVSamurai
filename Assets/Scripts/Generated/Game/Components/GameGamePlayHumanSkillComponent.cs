//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gamePlayHumanSkillEntity { get { return GetGroup(GameMatcher.GamePlayHumanSkill).GetSingleEntity(); } }
    public Game.PlayHumanSkillComponent gamePlayHumanSkill { get { return gamePlayHumanSkillEntity.gamePlayHumanSkill; } }
    public bool hasGamePlayHumanSkill { get { return gamePlayHumanSkillEntity != null; } }

    public GameEntity SetGamePlayHumanSkill(int newSkillCode) {
        if (hasGamePlayHumanSkill) {
            throw new Entitas.EntitasException("Could not set GamePlayHumanSkill!\n" + this + " already has an entity with Game.PlayHumanSkillComponent!",
                "You should check if the context already has a gamePlayHumanSkillEntity before setting it or use context.ReplaceGamePlayHumanSkill().");
        }
        var entity = CreateEntity();
        entity.AddGamePlayHumanSkill(newSkillCode);
        return entity;
    }

    public void ReplaceGamePlayHumanSkill(int newSkillCode) {
        var entity = gamePlayHumanSkillEntity;
        if (entity == null) {
            entity = SetGamePlayHumanSkill(newSkillCode);
        } else {
            entity.ReplaceGamePlayHumanSkill(newSkillCode);
        }
    }

    public void RemoveGamePlayHumanSkill() {
        gamePlayHumanSkillEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.PlayHumanSkillComponent gamePlayHumanSkill { get { return (Game.PlayHumanSkillComponent)GetComponent(GameComponentsLookup.GamePlayHumanSkill); } }
    public bool hasGamePlayHumanSkill { get { return HasComponent(GameComponentsLookup.GamePlayHumanSkill); } }

    public void AddGamePlayHumanSkill(int newSkillCode) {
        var index = GameComponentsLookup.GamePlayHumanSkill;
        var component = (Game.PlayHumanSkillComponent)CreateComponent(index, typeof(Game.PlayHumanSkillComponent));
        component.SkillCode = newSkillCode;
        AddComponent(index, component);
    }

    public void ReplaceGamePlayHumanSkill(int newSkillCode) {
        var index = GameComponentsLookup.GamePlayHumanSkill;
        var component = (Game.PlayHumanSkillComponent)CreateComponent(index, typeof(Game.PlayHumanSkillComponent));
        component.SkillCode = newSkillCode;
        ReplaceComponent(index, component);
    }

    public void RemoveGamePlayHumanSkill() {
        RemoveComponent(GameComponentsLookup.GamePlayHumanSkill);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGamePlayHumanSkill;

    public static Entitas.IMatcher<GameEntity> GamePlayHumanSkill {
        get {
            if (_matcherGamePlayHumanSkill == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GamePlayHumanSkill);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGamePlayHumanSkill = matcher;
            }

            return _matcherGamePlayHumanSkill;
        }
    }
}
