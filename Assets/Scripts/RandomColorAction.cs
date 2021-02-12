using UnityEngine;
using UnityEngine.UI;

public class RandomColorAction : MonoBehaviour, IPressable
{
    //The image in which the random color action will affect
    [SerializeField] Image selectedImage;

    public void Press()
    {
        Color randomColor = Random.ColorHSV(0f, 1f, 0f, 1f, 1f, 1f);
        selectedImage.color = randomColor;
    }
}
