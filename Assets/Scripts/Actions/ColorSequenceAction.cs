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

    IEnumerator corResetButtons;
    IEnumerator corColorSequence;

    public void Press()
    {
        pressCounter++;
        corColorSequence = ColorSequence();
        StartCoroutine(corColorSequence);
    }

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

    IEnumerator ColorSequence()
    {
        int currentPressCount = pressCounter;

        if (corResetButtons != null) StopCoroutine(corResetButtons);

        yield return new WaitForSeconds(2);
        SwitchBetweenColors();

        //Reset if no further input
        if (currentPressCount == pressCounter)
        {
            corResetButtons = ResetButtonWhenAllowed();
            StartCoroutine(corResetButtons);
        }
    }

    IEnumerator ResetButtonWhenAllowed() 
    {
        int currentPressCount = pressCounter;

        yield return new WaitForSeconds(5);
        if (currentPressCount == pressCounter)
        {
            ResetValues();
        }
    }

    void ResetValues() 
    {
        pressCounter = 0;
        selectedImage.color = selectedImageStartColor;
    }

    private void SwitchBetweenColors()
    {
        switch (pressCounter)
        {
            case 1:
                selectedImage.color = Color.blue;
                break;
            case 2:
                selectedImage.color = Color.red;
                break;
            case 5:
                selectedImage.color = new Color32(157, 3, 252, 255);
                break;
            default:
                break;
        }
    }
}
