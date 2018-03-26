using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuitMenuController : MonoBehaviour {

    protected CanvasGroup canvas;
    public Button yesButton;
    public Button noButton;

    // Use this for initialization
    void Awake () {
        canvas = GetComponent<CanvasGroup>();
        yesButton.onClick.AddListener(OnYesButtonPressed);
        noButton.onClick.AddListener(OnNoButtonPressed);
    }

    private void OnDestroy()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
    }

    private void OnNoButtonPressed()
    {
        Hide();
    }

    private void OnYesButtonPressed()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void Show () {
        canvas.DOFade(1f, .5f);
        canvas.interactable = canvas.blocksRaycasts = true;
	}

    public void Hide()
    {
        canvas.DOFade(0f, .3f);
        canvas.interactable = canvas.blocksRaycasts = false;
    }
}
