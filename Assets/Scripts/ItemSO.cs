﻿using System;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO")]
public class ItemSO : ScriptableObject {

    [Serializable]
    private struct Modifier {
        [field: SerializeField] public PlayerModifier playerModifier { get; private set; }
        [field: SerializeField] public Object value { get; private set; }
    }

    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int Price { get; private set; }

    [SerializeField] private Modifier[] modifiers;


    public void PerformAction(GameObject gameObject) {
        for (int i = 0; i < modifiers.Length; i++)
            modifiers[i].playerModifier.Modify(gameObject, modifiers[i].value);
    }

    public void ClearAction(GameObject gameObject) {
        for (int i = 0; i < modifiers.Length; i++)
            modifiers[i].playerModifier.Modify<Object>(gameObject, null);
    }
}
