using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {

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

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        InitializeCharacter();
    }
	
	protected void InitializeCharacter()
    {
        data = GameManagerController.Instance.GetCharacterData(index);
        //animator.SetInteger("selectedAnim", data.currentAnimation);
        UpdateCharacter();
    }

    public void UpdateCharacter()
    {
        UpdateAnimation();
        UpdateStyle();
    }

    public void UpdateAnimation()
    {
        animator.SetInteger("selectedAnim", data.currentAnimation);
    }

    public void UpdateAnimation(int anim)
    {
        data.currentAnimation = anim;
        animator.SetInteger("selectedAnim", data.currentAnimation);
    }

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
}
