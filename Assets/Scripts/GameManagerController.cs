using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManagerController : GenericSingleton<GameManagerController>
{

    public override void Awake()
    {
        base.Awake();
        charactersData = new CharacterCustomizableData[2];
        inputOutputController = new IOController();
        SetAnimationDictionary();
        SetStyleDictionary();
    }

    void Start () {
        ServiceSections.Instance.selected = ServiceSections.SECTION.INTRO;
	}


    #region Animation
    public int numberOfAnimations = 4;

    public Dictionary<int, string> animationNames;

    public void SetAnimationDictionary()
    {
        animationNames = new Dictionary<int, string>();
        animationNames.Add(0, "Idle");
        animationNames.Add(1, "Kick");
        animationNames.Add(2, "Dodge");
        animationNames.Add(3, "Punch");
    }
    #endregion

    #region Style
    public int numberOfStyles = 3;

    public Dictionary<int, CharacterStyle> styles;

    public void SetStyleDictionary()
    {
        styles = new Dictionary<int, CharacterStyle>();
        styles.Add(0, new CharacterStyle(0, "Yellow", Resources.Load<Texture>("Yellow") as Texture));
        styles.Add(1, new CharacterStyle(1, "Purple", Resources.Load<Texture>("Purple") as Texture));
        styles.Add(2, new CharacterStyle(2, "Pink", Resources.Load<Texture>("Pink") as Texture));
    }
    #endregion

    #region Characters
    protected CHARACTERINDEX characterSelectedIndex;

    public void SetSelectedCharacter(CHARACTERINDEX c)
    {
        characterSelectedIndex = c;
    }

    public CHARACTERINDEX GetSelectedCharacter()
    {
        return characterSelectedIndex;
    }

    public enum CHARACTERINDEX
    {
        ONE = 1,
        TWO = 2
    }

    protected CharacterCustomizableData[] charactersData;

    public CharacterCustomizableData GetCharacterData(CHARACTERINDEX i) {
        return charactersData[(int)i - 1];
    }

    #endregion

    #region I/O
    protected IOController inputOutputController;

    public void SaveCharacterData(Character c)
    {
        inputOutputController.SaveCharacterDataToDisk(c);
    }

    public void SaveCharacterData(CHARACTERINDEX index, CharacterCustomizableData data)
    {
        inputOutputController.SaveCharacterDataToDisk(index, data);
    }

    public CharacterCustomizableData LoadCharacterData(CHARACTERINDEX index)
    {
        return inputOutputController.LoadCharacterDataFromDisk(index);
    }

    public void UpdateCharactersDataFromDisk()
    {
        charactersData[0] = LoadCharacterData(CHARACTERINDEX.ONE);
        charactersData[1] = LoadCharacterData(CHARACTERINDEX.TWO);
    }
    #endregion
}