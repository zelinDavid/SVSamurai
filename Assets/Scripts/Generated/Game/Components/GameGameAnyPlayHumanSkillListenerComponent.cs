//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameAnyPlayHumanSkillListenerComponent gameAnyPlayHumanSkillListener { get { return (GameAnyPlayHumanSkillListenerComponent)GetComponent(GameComponentsLookup.GameAnyPlayHumanSkillListener); } }
    public bool hasGameAnyPlayHumanSkillListener { get { return HasComponent(GameComponentsLookup.GameAnyPlayHumanSkillListener); } }

    public void AddGameAnyPlayHumanSkillListener(System.Collections.Generic.List<IGameAnyPlayHumanSkillListener> newValue) {
        var index = GameComponentsLookup.GameAnyPlayHumanSkillListener;
        var component = (GameAnyPlayHumanSkillListenerComponent)CreateComponent(index, typeof(GameAnyPlayHumanSkillListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameAnyPlayHumanSkillListener(System.Collections.Generic.List<IGameAnyPlayHumanSkillListener> newValue) {
        var index = GameComponentsLookup.GameAnyPlayHumanSkillListener;
        var component = (GameAnyPlayHumanSkillListenerComponent)CreateComponent(index, typeof(GameAnyPlayHumanSkillListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameAnyPlayHumanSkillListener() {
        RemoveComponent(GameComponentsLookup.GameAnyPlayHumanSkillListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameAnyPlayHumanSkillListener;

    public static Entitas.IMatcher<GameEntity> GameAnyPlayHumanSkillListener {
        get {
            if (_matcherGameAnyPlayHumanSkillListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameAnyPlayHumanSkillListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameAnyPlayHumanSkillListener = matcher;
            }

            return _matcherGameAnyPlayHumanSkillListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddGameAnyPlayHumanSkillListener(IGameAnyPlayHumanSkillListener value) {
        var listeners = hasGameAnyPlayHumanSkillListener
            ? gameAnyPlayHumanSkillListener.value
            : new System.Collections.Generic.List<IGameAnyPlayHumanSkillListener>();
        listeners.Add(value);
        ReplaceGameAnyPlayHumanSkillListener(listeners);
    }

    public void RemoveGameAnyPlayHumanSkillListener(IGameAnyPlayHumanSkillListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameAnyPlayHumanSkillListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameAnyPlayHumanSkillListener();
        } else {
            ReplaceGameAnyPlayHumanSkillListener(listeners);
        }
    }
}
