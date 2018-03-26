using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GenericUIController : MonoBehaviour {

    public Button quitButton;
    protected CanvasGroup quitButtonCanvas;
    public QuitMenuController quitMenu;

	// Use this for initialization
	void Awake () {
        quitButtonCanvas = quitButton.gameObject.GetComponent<CanvasGroup>();
        ServiceSections.Instance.onSelectedChanged += OnSectionChanged;
        quitButton.onClick.AddListener(OnQuitButtonPressed);
	}

    private void OnDestroy()
    {
        quitButton.onClick.RemoveAllListeners();
        ServiceSections.Instance.onSelectedChanged -= OnSectionChanged;
    }

    private void OnSectionChanged(ServiceSections.SECTION selected)
    {
        if(selected == ServiceSections.SECTION.INTRO)
        {
            quitButtonCanvas.DOFade(0f, .3f);
            quitButtonCanvas.interactable = quitButtonCanvas.blocksRaycasts = false;
        }
        else
        {
            quitButtonCanvas.DOFade(1f, .3f);
            quitButtonCanvas.interactable = quitButtonCanvas.blocksRaycasts = true;
        }
    }

    private void OnQuitButtonPressed()
    {
        quitMenu.Show();
    }
}
