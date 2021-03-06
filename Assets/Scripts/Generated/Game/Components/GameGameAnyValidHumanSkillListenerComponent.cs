//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameAnyValidHumanSkillListenerComponent gameAnyValidHumanSkillListener { get { return (GameAnyValidHumanSkillListenerComponent)GetComponent(GameComponentsLookup.GameAnyValidHumanSkillListener); } }
    public bool hasGameAnyValidHumanSkillListener { get { return HasComponent(GameComponentsLookup.GameAnyValidHumanSkillListener); } }

    public void AddGameAnyValidHumanSkillListener(System.Collections.Generic.List<IGameAnyValidHumanSkillListener> newValue) {
        var index = GameComponentsLookup.GameAnyValidHumanSkillListener;
        var component = (GameAnyValidHumanSkillListenerComponent)CreateComponent(index, typeof(GameAnyValidHumanSkillListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameAnyValidHumanSkillListener(System.Collections.Generic.List<IGameAnyValidHumanSkillListener> newValue) {
        var index = GameComponentsLookup.GameAnyValidHumanSkillListener;
        var component = (GameAnyValidHumanSkillListenerComponent)CreateComponent(index, typeof(GameAnyValidHumanSkillListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameAnyValidHumanSkillListener() {
        RemoveComponent(GameComponentsLookup.GameAnyValidHumanSkillListener);
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

    static Entitas.IMatcher<GameEntity> _matcherGameAnyValidHumanSkillListener;

    public static Entitas.IMatcher<GameEntity> GameAnyValidHumanSkillListener {
        get {
            if (_matcherGameAnyValidHumanSkillListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameAnyValidHumanSkillListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameAnyValidHumanSkillListener = matcher;
            }

            return _matcherGameAnyValidHumanSkillListener;
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

    public void AddGameAnyValidHumanSkillListener(IGameAnyValidHumanSkillListener value) {
        var listeners = hasGameAnyValidHumanSkillListener
            ? gameAnyValidHumanSkillListener.value
            : new System.Collections.Generic.List<IGameAnyValidHumanSkillListener>();
        listeners.Add(value);
        ReplaceGameAnyValidHumanSkillListener(listeners);
    }

    public void RemoveGameAnyValidHumanSkillListener(IGameAnyValidHumanSkillListener value, bool removeComponentWhenEmpty = true) {
        var listeners = gameAnyValidHumanSkillListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveGameAnyValidHumanSkillListener();
        } else {
            ReplaceGameAnyValidHumanSkillListener(listeners);
        }
    }
}
