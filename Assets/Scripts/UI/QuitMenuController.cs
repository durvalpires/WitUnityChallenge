using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuitMenuController : MonoBehaviour {

    #region Properties
    protected CanvasGroup canvas;
    public Button yesButton;
    public Button noButton;
    #endregion

    #region Lifecycle
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
    #endregion

    #region Callbacks
    private void OnNoButtonPressed()
    {
        Hide();
    }

    private void OnYesButtonPressed()
    {
        Application.Quit();
    }
    #endregion

    #region Show/Hide
    public void Show () {
        canvas.DOFade(1f, .5f);
        canvas.interactable = canvas.blocksRaycasts = true;
	}

    public void Hide()
    {
        canvas.DOFade(0f, .3f);
        canvas.interactable = canvas.blocksRaycasts = false;
    }
    #endregion
}
