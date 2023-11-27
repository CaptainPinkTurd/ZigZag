using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBevavior : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;
    private bool fadeOut = false;
    public void ONButtonPressed()
    {
        fadeOut = true;
        CharacterMovementScript.animator.SetBool("gameStarted", true);
    }
    private void Update()
    {
        if (fadeOut)
        {
            if(canvas.alpha > 0)
            {
                canvas.alpha -= Time.deltaTime * 2;
            }
            else 
            {
                fadeOut = false;
            }
        }
    }
}
