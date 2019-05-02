//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.PlayerAniState gamePlayerAniState { get { return (Game.PlayerAniState)GetComponent(GameComponentsLookup.GamePlayerAniState); } }
    public bool hasGamePlayerAniState { get { return HasComponent(GameComponentsLookup.GamePlayerAniState); } }

    public void AddGamePlayerAniState(Game.PlayerAniIndex newAniIndex) {
        var index = GameComponentsLookup.GamePlayerAniState;
        var component = (Game.PlayerAniState)CreateComponent(index, typeof(Game.PlayerAniState));
        component.AniIndex = newAniIndex;
        AddComponent(index, component);
    }

    public void ReplaceGamePlayerAniState(Game.PlayerAniIndex newAniIndex) {
        var index = GameComponentsLookup.GamePlayerAniState;
        var component = (Game.PlayerAniState)CreateComponent(index, typeof(Game.PlayerAniState));
        component.AniIndex = newAniIndex;
        ReplaceComponent(index, component);
    }

    public void RemoveGamePlayerAniState() {
        RemoveComponent(GameComponentsLookup.GamePlayerAniState);
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

    static Entitas.IMatcher<GameEntity> _matcherGamePlayerAniState;

    public static Entitas.IMatcher<GameEntity> GamePlayerAniState {
        get {
            if (_matcherGamePlayerAniState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GamePlayerAniState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGamePlayerAniState = matcher;
            }

            return _matcherGamePlayerAniState;
        }
    }
}