using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RainbowColorLerpAction : MonoBehaviour, IPressable
{
    //The image in which the random color action will affect
    [SerializeField] Image selectedImage;

    Color selectedImageStartColor;
    Color nextColor = Color.magenta;

    int colorCounter = -1;

    bool isActivated = false;
    void Start()
    {
        EnsureValidData();
    }

    void EnsureValidData()
    {
        if (selectedImage)
            selectedImageStartColor = selectedImage.color;
        else throw new Exception("Insert an image in the inspector for " + GetType().ToString() + " of object " + gameObject.name);
    }

    public void Press()
    {
        if (isActivated)
        {
            DeactivateRainbowColorLerp();
        }
        else
            StartCoroutine(RandomColorLerp(2f));
    }

    private void DeactivateRainbowColorLerp() 
    {
        StopAllCoroutines();
        selectedImage.color = selectedImageStartColor;
        isActivated = false;
    }

    private void GetNextColor() 
    {
        switch (colorCounter) 
        {
            case 0:
                nextColor = Color.red;
                break;
            case 1:
                nextColor = Color.yellow;
                break;
            case 2:
                nextColor = Color.green;
                break;
            case 3:
                nextColor = Color.blue;
                break;

            default:
                colorCounter = -1;
                nextColor = Color.magenta;
                break;
        }
        colorCounter++;
    }

    IEnumerator RandomColorLerp(float duration)
    {
        isActivated = true;
        float time = 0;
        Color startColor = selectedImage.color;
        Color endColor = nextColor;
        GetNextColor();

        while (time < duration)
        {
            selectedImage.color = Color.Lerp(startColor, endColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        selectedImage.color = endColor;
        StartCoroutine(RandomColorLerp(duration));
    }
}
