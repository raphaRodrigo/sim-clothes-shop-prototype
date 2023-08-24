using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LayeredRenderer : MonoBehaviour {

    [SerializeField] private LayeredRenderer baseRenderer, culledBy;
    [SerializeField] private Texture2D _spriteSetTexture;
    [SerializeField] private string spriteSetTexturesPath;

    private List<Texture2D> spriteSetTextures = new();
    private Dictionary<Texture2D, Sprite[]> spriteSets = new();
    private SpriteRenderer spriteRenderer;
    private Sprite currentSprite;
    private int currentSpriteIndex;

    public bool HasTexture => _spriteSetTexture;

    private event Action<int> onBaseSpriteChanged;


    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CollectionsSetup();
    }

    private void OnEnable() {
        if (baseRenderer != this)
            baseRenderer.onBaseSpriteChanged += OnBaseSpriteChanged;
    }

    private void OnDisable() {
        if (baseRenderer != this)
            baseRenderer.onBaseSpriteChanged -= OnBaseSpriteChanged;
    }

    private void Update() {
        if (culledBy)
            spriteRenderer.enabled = !culledBy.HasTexture;

        if (baseRenderer == this && currentSprite != spriteRenderer.sprite) {
            currentSprite = spriteRenderer.sprite;
            currentSpriteIndex = Array.FindIndex(
                spriteSets[_spriteSetTexture], i => i == currentSprite
            );
            baseRenderer.onBaseSpriteChanged(currentSpriteIndex);
        }
    }

    private void CollectionsSetup() {
        spriteSetTextures.AddRange(
            Resources.LoadAll<Texture2D>(spriteSetTexturesPath)
        );

        for (int i = 0; i < spriteSetTextures.Count; i++) {
            string spriteSetPath =
                spriteSetTexturesPath + "/" + spriteSetTextures[i].name;
            spriteSets.Add(
                spriteSetTextures[i], Resources.LoadAll<Sprite>(spriteSetPath)
            );
        }
    }

    private void OnBaseSpriteChanged(int index) {
        if (_spriteSetTexture)
            spriteRenderer.sprite = spriteSets[_spriteSetTexture][index];
    }

    public void SetTexture(Texture2D spriteSetTexture) {
        _spriteSetTexture = spriteSetTexture;
        spriteRenderer.sprite = null;
    }
}
