//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ItemComponent item { get { return (ItemComponent)GetComponent(GameComponentsLookup.Item); } }
    public bool hasItem { get { return HasComponent(GameComponentsLookup.Item); } }

    public void AddItem(string newName) {
        var index = GameComponentsLookup.Item;
        var component = (ItemComponent)CreateComponent(index, typeof(ItemComponent));
        component.name = newName;
        AddComponent(index, component);
    }

    public void ReplaceItem(string newName) {
        var index = GameComponentsLookup.Item;
        var component = (ItemComponent)CreateComponent(index, typeof(ItemComponent));
        component.name = newName;
        ReplaceComponent(index, component);
    }

    public void RemoveItem() {
        RemoveComponent(GameComponentsLookup.Item);
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

    static Entitas.IMatcher<GameEntity> _matcherItem;

    public static Entitas.IMatcher<GameEntity> Item {
        get {
            if (_matcherItem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Item);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherItem = matcher;
            }

            return _matcherItem;
        }
    }
}
