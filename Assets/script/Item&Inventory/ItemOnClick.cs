using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemOnClick: MonoBehaviour, IPointerClickHandler
{
    public UnityEvent leftClick;
    public UnityEvent rightClick;
    public Slot slotPrefab;
    private GameContext _contexts;
    private int BItemNum = 3;
    IGroup<GameEntity> _items;
    IGroup<GameEntity> _Bag;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            leftClick.Invoke();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rightClick.Invoke();
    }

    void Start()
    {
        Contexts contexts = GameController.GetContext();
        _contexts = contexts.game;
        leftClick.AddListener(new UnityAction(ButtonLeftClick));
        rightClick.AddListener(new UnityAction(ButtonRightClick));
    }

    private void ButtonLeftClick()
    {
        Debug.Log("Button Left Click");
    }

    private void ButtonRightClick()
    {
        Debug.Log("Button Right Click");
        int now_iid = slotPrefab.slotitemid;        // item id
        _items = _contexts.GetGroup(GameMatcher.isTaken2Battle);
        int count = 0;
        foreach (GameEntity e in _items) if (e.isTaken2Battle.istaken2battle) count++;

        foreach (GameEntity e in _items)
        {
            if (e.itemIndex.id == now_iid)
            {
                if(count <= BItemNum-1) e.ReplaceisTaken2Battle(!e.isTaken2Battle.istaken2battle);      // 一定要用replace
                else if (e.isTaken2Battle.istaken2battle) e.ReplaceisTaken2Battle(!e.isTaken2Battle.istaken2battle);    // 超数时只能减少
                //e.ReplaceisTaken2Battle(!e.isTaken2Battle.istaken2battle);
                break;
            }
        }
        
    }

}
