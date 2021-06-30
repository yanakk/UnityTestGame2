//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public isPlayerComponent isPlayer { get { return (isPlayerComponent)GetComponent(GameComponentsLookup.isPlayer); } }
    public bool hasisPlayer { get { return HasComponent(GameComponentsLookup.isPlayer); } }

    public void AddisPlayer(bool newIsplayer) {
        var index = GameComponentsLookup.isPlayer;
        var component = (isPlayerComponent)CreateComponent(index, typeof(isPlayerComponent));
        component.isplayer = newIsplayer;
        AddComponent(index, component);
    }

    public void ReplaceisPlayer(bool newIsplayer) {
        var index = GameComponentsLookup.isPlayer;
        var component = (isPlayerComponent)CreateComponent(index, typeof(isPlayerComponent));
        component.isplayer = newIsplayer;
        ReplaceComponent(index, component);
    }

    public void RemoveisPlayer() {
        RemoveComponent(GameComponentsLookup.isPlayer);
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

    static Entitas.IMatcher<GameEntity> _matcherisPlayer;

    public static Entitas.IMatcher<GameEntity> isPlayer {
        get {
            if (_matcherisPlayer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.isPlayer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherisPlayer = matcher;
            }

            return _matcherisPlayer;
        }
    }
}
