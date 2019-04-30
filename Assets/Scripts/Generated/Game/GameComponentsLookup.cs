//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int GameCameraState = 0;
    public const int GameEndHumanSkill = 1;
    public const int GameHumanBehaviourState = 2;
    public const int GamePlayerAniState = 3;
    public const int GamePlayer = 4;
    public const int GameStartHumanSkill = 5;
    public const int GameAnyEndHumanSkillListener = 6;
    public const int GameAnyStartHumanSkillListener = 7;
    public const int GameCameraStateListener = 8;

    public const int TotalComponents = 9;

    public static readonly string[] componentNames = {
        "GameCameraState",
        "GameEndHumanSkill",
        "GameHumanBehaviourState",
        "GamePlayerAniState",
        "GamePlayer",
        "GameStartHumanSkill",
        "GameAnyEndHumanSkillListener",
        "GameAnyStartHumanSkillListener",
        "GameCameraStateListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Game.CameraState),
        typeof(Game.EndHumanSkillComponent),
        typeof(Game.HumanBehaviourStateComponent),
        typeof(Game.PlayerAniState),
        typeof(Game.PlayerComponent),
        typeof(Game.StartHumanSkillComponent),
        typeof(GameAnyEndHumanSkillListenerComponent),
        typeof(GameAnyStartHumanSkillListenerComponent),
        typeof(GameCameraStateListenerComponent)
    };
}
