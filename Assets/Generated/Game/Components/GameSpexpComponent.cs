//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SpexpComponent spexp { get { return (SpexpComponent)GetComponent(GameComponentsLookup.Spexp); } }
    public bool hasSpexp { get { return HasComponent(GameComponentsLookup.Spexp); } }

    public void AddSpexp(double newSpexp) {
        var index = GameComponentsLookup.Spexp;
        var component = (SpexpComponent)CreateComponent(index, typeof(SpexpComponent));
        component.spexp = newSpexp;
        AddComponent(index, component);
    }

    public void ReplaceSpexp(double newSpexp) {
        var index = GameComponentsLookup.Spexp;
        var component = (SpexpComponent)CreateComponent(index, typeof(SpexpComponent));
        component.spexp = newSpexp;
        ReplaceComponent(index, component);
    }

    public void RemoveSpexp() {
        RemoveComponent(GameComponentsLookup.Spexp);
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

    static Entitas.IMatcher<GameEntity> _matcherSpexp;

    public static Entitas.IMatcher<GameEntity> Spexp {
        get {
            if (_matcherSpexp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Spexp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpexp = matcher;
            }

            return _matcherSpexp;
        }
    }
}
