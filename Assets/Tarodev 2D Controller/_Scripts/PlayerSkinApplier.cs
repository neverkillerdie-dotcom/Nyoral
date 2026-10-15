using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSkinApplier : MonoBehaviour
{
    private void OnEnable()
    {
        if (SkinSelector.selectedSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = SkinSelector.selectedSprite;
        }
    }
}
