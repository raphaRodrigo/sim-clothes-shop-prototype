using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHatModifier", menuName = "ScriptableObjects/PlayerHatModifier")]
public class PlayerHatModifier : PlayerModifier {

    public override void Modify<T>(GameObject gameObject, T modifier) {
        if (gameObject.transform.GetChild(0).TryGetComponent(out PlayerVisuals visuals))
            visuals.HatRenderer.SetTexture(modifier as Texture2D);
    }
}
