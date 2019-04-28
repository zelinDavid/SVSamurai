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
    public const int GamePlayer = 1;
    public const int GameTestOne = 2;
    public const int GameCameraStateListener = 3;
    public const int GameTestOneListener = 4;

    public const int TotalComponents = 5;

    public static readonly string[] componentNames = {
        "GameCameraState",
        "GamePlayer",
        "GameTestOne",
        "GameCameraStateListener",
        "GameTestOneListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Game.CameraState),
        typeof(Game.PlayerComponent),
        typeof(Game.TestOne),
        typeof(GameCameraStateListenerComponent),
        typeof(GameTestOneListenerComponent)
    };
}
