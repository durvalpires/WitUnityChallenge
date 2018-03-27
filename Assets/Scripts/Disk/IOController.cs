using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IOController {

	public void SaveCharacterDataToDisk(Character c)
    {
        string filePath = Path.Combine(Application.persistentDataPath, c.index.ToString() + ".json");

        if (File.Exists(filePath))
        {
            string json = JsonUtility.ToJson(c.Data);
            File.WriteAllText(filePath, json);
        }
    }

    public void SaveCharacterDataToDisk(GameManagerController.CHARACTERINDEX index, CharacterCustomizableData data)
    {
        string filePath = Path.Combine(Application.persistentDataPath, index.ToString() + ".json");


            string json = JsonUtility.ToJson(data);
            File.WriteAllText(filePath, json);
    }

    public CharacterCustomizableData LoadCharacterDataFromDisk(GameManagerController.CHARACTERINDEX i)
    {
        string filePath = Path.Combine(Application.persistentDataPath, i.ToString() + ".json");
        CharacterCustomizableData cData = null;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            cData = JsonUtility.FromJson<CharacterCustomizableData>(dataAsJson);
            return cData;
        }
        else
        {
            cData = CreateNewCharacter();
            SaveCharacterDataToDisk(i, cData);
        }

        return cData;
    }

    private CharacterCustomizableData CreateNewCharacter()
    {
        CharacterCustomizableData newChar =  new CharacterCustomizableData();
        newChar.name = "New Character";
        newChar.currentAnimation = 0;
        newChar.currentStyle = 0;
        return newChar;
    }
}
