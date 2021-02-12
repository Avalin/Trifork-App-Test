using UnityEngine;
using UnityEngine.UI;

public class RandomSpriteSwapAction : MonoBehaviour, IPressable
{
    [SerializeField] Image selectedImage;
    [Range(0, 100)]
    [SerializeField] int maxSprites;
    [SerializeField] bool loadShroomSprites;

    Sprite[] sprites;

    void Start()
    {
        LoadSprites();
    }

    public void SelectRandomShroomSprite() 
    {
        var newSprite = sprites[Random.Range(0, maxSprites)];
        if (selectedImage.sprite == newSprite) SelectRandomShroomSprite();
        else selectedImage.sprite = newSprite;
    }

    public void Press()
    {
        SelectRandomShroomSprite();
    }

    private void LoadSprites() 
    {
        if(loadShroomSprites) sprites = Resources.LoadAll<Sprite>("Graphics/shrooms");
    }
}
