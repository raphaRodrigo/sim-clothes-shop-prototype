using UnityEngine;

public abstract class PlayerModifier : ScriptableObject {

    public abstract void Modify<T>(GameObject gameObject, T modifier);
}
