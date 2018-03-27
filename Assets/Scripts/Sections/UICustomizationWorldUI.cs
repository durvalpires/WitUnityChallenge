using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UICustomizationWorldUI : View {

    #region Properties
    public TMP_InputField nameInput;
    public TextMeshProUGUI animationName;
    public Button animationLeftArrow;
    public Button animationRightArrow;
    public TextMeshProUGUI styleName;
    public Button styleLeftArrow;
    public Button styleRightArrow;
    public Button discardButton;
    public Button saveButton;

    public RectTransform downButtonsRect;
    public RectTransform customizationMenuRect;
    protected float targetDownButtonsRectYvalue = -13.2f;
    protected float targetCustomizationMenuRectXvalue = 0;
    protected float animationDuration = .3f;

    CharacterCustomizableData editableData;

    public CharacterContainer characterContainer;
    #endregion

    #region Events
    public delegate void AnimationChangedArgs(int anim);
    public event AnimationChangedArgs OnAnimationChangedArgs;
    public delegate void StyleChangedArgs(CharacterStyle newStyle);
    public event StyleChangedArgs OnStyleChangedArgs;
    #endregion

    #region Lifecycle
    private void Awake()
    {
        editableData = new CharacterCustomizableData();
        discardButton.onClick.AddListener(OnDiscardPressed);
        saveButton.onClick.AddListener(OnSavePressed);
        animationLeftArrow.onClick.AddListener(OnAnimLeftArrowPressed);
        animationRightArrow.onClick.AddListener(OnAnimRightArrowPressed);
        styleLeftArrow.onClick.AddListener(OnStyleLeftArrowPressed);
        styleRightArrow.onClick.AddListener(OnStyleRightArrowPressed);
        

        OnAnimationChangedArgs += characterContainer.OnAnimationChanged;
        OnStyleChangedArgs += characterContainer.OnStyleChanged;
    }

    void Start () {
        SetupInfo();
        AnimateIn();
	}

    private void OnDestroy()
    {
        OnStyleChangedArgs -= characterContainer.OnStyleChanged;
        OnAnimationChangedArgs -= characterContainer.OnAnimationChanged;

        animationRightArrow.onClick.RemoveAllListeners();
        animationLeftArrow.onClick.RemoveAllListeners();
        saveButton.onClick.RemoveAllListeners();
        discardButton.onClick.RemoveAllListeners();
    }
    #endregion

    #region Info
    private void SetupInfo()
    {
        CharacterCustomizableData initialData = GameManagerController.Instance.GetCharacterData(GameManagerController.Instance.GetSelectedCharacter());
        editableData.name = initialData.name;
        editableData.currentAnimation = initialData.currentAnimation;
        editableData.currentStyle = initialData.currentStyle;

        nameInput.text = editableData.name;
        animationName.text = GameManagerController.Instance.animationNames[editableData.currentAnimation];
        styleName.text = GameManagerController.Instance.styles[editableData.currentStyle].Name;
    }
    #endregion

    #region Callbacks
    private void OnAnimRightArrowPressed()
    {
        SoundManager.Instance.PlaySfx(SoundManager.SFX.OPTIONSWITCH);

        editableData.currentAnimation++;

        if (editableData.currentAnimation == GameManagerController.Instance.numberOfAnimations)
        {
            editableData.currentAnimation = 0;
        }
       
        animationName.text = GameManagerController.Instance.animationNames[editableData.currentAnimation];

        if (OnAnimationChangedArgs != null) OnAnimationChangedArgs(editableData.currentAnimation);
    }

    private void OnAnimLeftArrowPressed()
    {
        SoundManager.Instance.PlaySfx(SoundManager.SFX.OPTIONSWITCH);

        editableData.currentAnimation--;

        if (editableData.currentAnimation == -1)
        {
            editableData.currentAnimation = GameManagerController.Instance.numberOfAnimations - 1;
        }

        animationName.text = GameManagerController.Instance.animationNames[editableData.currentAnimation];

        if (OnAnimationChangedArgs != null) OnAnimationChangedArgs(editableData.currentAnimation);
    }

    private void OnStyleRightArrowPressed()
    {
        SoundManager.Instance.PlaySfx(SoundManager.SFX.OPTIONSWITCH);

        editableData.currentStyle++;

        if (editableData.currentStyle == GameManagerController.Instance.numberOfStyles)
        {
            editableData.currentStyle = 0;
        }

        styleName.text = GameManagerController.Instance.styles[editableData.currentStyle].Name;

        if (OnStyleChangedArgs != null) OnStyleChangedArgs(GameManagerController.Instance.styles[editableData.currentStyle]);
    }

    private void OnStyleLeftArrowPressed()
    {
        SoundManager.Instance.PlaySfx(SoundManager.SFX.OPTIONSWITCH);

        editableData.currentStyle--;

        if (editableData.currentStyle == -1)
        {
            editableData.currentStyle = GameManagerController.Instance.numberOfStyles - 1;
        }

        styleName.text = GameManagerController.Instance.styles[editableData.currentStyle].Name;

        if (OnStyleChangedArgs != null) OnStyleChangedArgs(GameManagerController.Instance.styles[editableData.currentStyle]);
    }

    private void OnDiscardPressed()
    {
        SoundManager.Instance.PlaySfx(SoundManager.SFX.NEGATIVE);

        SceneManager.LoadSceneAsync(1);
        ServiceSections.Instance.selected = ServiceSections.SECTION.VISUALIZATION;
    }

    private void OnSavePressed()
    {
        SoundManager.Instance.PlaySfx(SoundManager.SFX.POSITIVE);

        GameManagerController.Instance.SaveCharacterData(GameManagerController.Instance.GetSelectedCharacter(), editableData);
        GameManagerController.Instance.UpdateCharactersDataFromDisk();
        SceneManager.LoadSceneAsync(1);
        ServiceSections.Instance.selected = ServiceSections.SECTION.VISUALIZATION;
    }

    public void OnNameChanged(string s)
    {
        editableData.name = nameInput.text;
    }
    #endregion

    #region Show Animation
    private void AnimateIn()
    {
        downButtonsRect.DOAnchorPosY(targetDownButtonsRectYvalue, animationDuration);
        CanvasGroup downButtonsCanvas = downButtonsRect.GetComponent<CanvasGroup>();
        downButtonsCanvas.DOFade(1f, animationDuration);
        downButtonsCanvas.blocksRaycasts = downButtonsCanvas.interactable = true;

        customizationMenuRect.DOAnchorPosX(targetCustomizationMenuRectXvalue, animationDuration);
        CanvasGroup customizationMenuCanvas = customizationMenuRect.GetComponent<CanvasGroup>();
        customizationMenuCanvas.DOFade(1f, animationDuration);
        customizationMenuCanvas.blocksRaycasts = customizationMenuCanvas.interactable = true;
    }
    #endregion
}
