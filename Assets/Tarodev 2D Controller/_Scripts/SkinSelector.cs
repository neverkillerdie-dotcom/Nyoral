using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class SkinData
{
    public string countryName;
    public Sprite characterSprite;
}

public class SkinSelector : MonoBehaviour
{
    public SkinData[] skins = new SkinData[11];
    public int totalSkinCount = 11;

    public TMP_Text countryNameText;
    public TMP_Text countText;
    public Image characterImage;
    public Image characterImageright;
    public Image characterImageleft;
    public SpriteRenderer PlayerController;
    [SerializeField] private Image _dead;

    public static int currentSkin = 0;
    public static Sprite selectedSprite;

    private void OnEnable()
    {
        UpdateSkinUI();
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectPreviousSkin();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SelectNextSkin();
        }
    }

    public void SelectPreviousSkin()
    {
        if (skins.Length == 0)
        {
            return;
        }

        currentSkin--;

        if (currentSkin < 0)
        {
            currentSkin = skins.Length - 1;
        }

        UpdateSkinUI();
    }

    public void SelectNextSkin()
    {
        if (skins.Length == 0)
        {
            return;
        }

        currentSkin++;

        if (currentSkin >= skins.Length)
        {
            currentSkin = 0;
        }

        UpdateSkinUI();
    }

    private void UpdateSkinUI()
    {
        if (skins.Length == 0)
        {
            return;
        }

        int right = currentSkin + 1;
        int left = currentSkin - 1;

        if (right >= skins.Length)
        {
            right = 0;
        }

        if (left < 0)
        {
            left = skins.Length - 1;
        }

        SkinData selectedSkin = skins[currentSkin];
        selectedSprite = selectedSkin.characterSprite;

        countryNameText.text = selectedSkin.countryName;
        countText.text = (currentSkin + 1) + "/" + totalSkinCount;
        characterImageleft.sprite = skins[left].characterSprite;
        characterImage.sprite = skins[currentSkin].characterSprite;
        characterImageright.sprite = skins[right].characterSprite;

        //이거 고치는데 3일 걸림 버그중 가장 오래걸린듯 tq//
        if (PlayerController != null)
        {
            PlayerController.sprite = selectedSprite;
        }
    }
}