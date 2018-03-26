using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {

    #region Properties
    public GameManagerController.CHARACTERINDEX index;

    protected CharacterCustomizableData data;
    public CharacterCustomizableData Data
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
            UpdateCharacter();
        }
    }

    protected Animator animator;

    public Renderer render;

    #endregion

    #region Lifecycle
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start () {
        InitializeCharacter();
    }
    #endregion

    #region Character
    protected void InitializeCharacter()
    {
        data = GameManagerController.Instance.GetCharacterData(index);
        UpdateCharacter();
    }

    public void UpdateCharacter()
    {
        UpdateAnimation();
        UpdateStyle();
    }
    #endregion

    #region Animation
    public void UpdateAnimation()
    {
        animator.SetInteger("selectedAnim", data.currentAnimation);
    }

    public void UpdateAnimation(int anim)
    {
        data.currentAnimation = anim;
        animator.SetInteger("selectedAnim", data.currentAnimation);
    }
    #endregion

    #region Style
    internal void UpdateStyle(CharacterStyle style)
    {
        data.currentStyle = style.Id;
        render.material.mainTexture = style.Texture;
    }

    internal void UpdateStyle()
    {
        CharacterStyle s = GameManagerController.Instance.styles[data.currentStyle];
        render.material.mainTexture = s.Texture;
    }
    #endregion
}
