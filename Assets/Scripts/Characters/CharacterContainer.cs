using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour {

    #region Properties
    public Character character1Prefab;
    public Character character2Prefab;

    protected Character customizableCharacter;
    #endregion

    void Awake () {
        SetupCharacter();
	}

    #region Character
    private void SetupCharacter()
    {
        switch (GameManagerController.Instance.GetSelectedCharacter())
        {
            case GameManagerController.CHARACTERINDEX.ONE:
                {
                    customizableCharacter = Instantiate(character1Prefab, this.transform);
                    //customizableCharacter.Data = GameManagerController.Instance.GetCharacterData(GameManagerController.CHARACTERINDEX.ONE);

                    break;
                }
            case GameManagerController.CHARACTERINDEX.TWO:
                {
                    customizableCharacter = Instantiate(character2Prefab, this.transform);
                    //customizableCharacter.Data = GameManagerController.Instance.GetCharacterData(GameManagerController.CHARACTERINDEX.TWO);
                    break;
                }
        }

    }

    public void InjectDataOnCharacter(CharacterCustomizableData data)
    {
        customizableCharacter.Data = data;
    }
    #endregion

    #region Callbacks
    public void OnNameChanged(string name)
    {
        customizableCharacter.Data.name = name;
    }

    public void OnAnimationChanged(int anim)
    {
        customizableCharacter.UpdateAnimation(anim);
    }

    public void OnStyleChanged(CharacterStyle newStyle)
    {
        customizableCharacter.UpdateStyle(newStyle);
    }
    #endregion
}
