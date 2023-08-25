using UnityEngine;

[CreateAssetMenu(fileName = "PlayerOutfitModifier", menuName = "ScriptableObjects/PlayerOutfitModifier")]
public class PlayerOutfitModifier : PlayerModifier {

    public override void Modify<T>(GameObject gameObject, T modifier) {
        if (gameObject.TryGetComponent(out PlayerVisuals visuals))
            visuals.OutfitRenderer.SetTexture(modifier as Texture2D);
    }
}
