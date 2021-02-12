using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorSequenceAction : MonoBehaviour, IPressable
{
    //The image in which the color sequence action will affect
    [SerializeField] Image selectedImage;

    int pressCounter = 0;
    Color selectedImageStartColor;
    bool isChangingColor = false;
    bool isResetAllowed = false;

    public void Press()
    {
        pressCounter++;
        StartCoroutine(ColorSequence());
        StartCoroutine(ResetButtonWhenAllowed());
    }

    void Start()
    {
        EnsureValidData();
    }

    void EnsureValidData() 
    {
        if (selectedImage)
            selectedImageStartColor = selectedImage.color;
        else throw new Exception("Insert an image in the inspector for ColorSequenceAction of object " + gameObject.name);
    }

    IEnumerator ColorSequence() 
    {
        //Ensure only one ColorSequence coroutine is running
        if (isChangingColor) yield break;
        isChangingColor = true;

        yield return new WaitForSeconds(2);
        switch (pressCounter)
        {
            case 1:
                selectedImage.color = Color.blue;
                break;
            case 2:
                selectedImage.color = Color.red;
                break;
            case 5:
                selectedImage.color = new Color(1, 0, 1, 1);
                break;
            default:
                //Reset();
                break;
        }
        pressCounter = 0;
        isChangingColor = false;
        isResetAllowed = true;
    }

    IEnumerator ResetButtonWhenAllowed() 
    {
        yield return new WaitUntil(() => isResetAllowed);
        int currentPressCount = pressCounter;

        yield return new WaitForSeconds(5);
        if (currentPressCount == pressCounter && isResetAllowed)
        {
            ResetValues();
        }
        isResetAllowed = false;
        StartCoroutine(ResetButtonWhenAllowed());
    }

    void ResetValues() 
    {
        pressCounter = 0;
        selectedImage.color = selectedImageStartColor;
    }
}
