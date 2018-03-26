using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IOController {

	public void SaveCharacterDataToDisk(Character c)
    {
        string filePath = Path.Combine(Application.dataPath, c.index.ToString() + ".json");

        if (File.Exists(filePath))
        {
            string json = JsonUtility.ToJson(c.Data);
            File.WriteAllText(filePath, json);
        }
    }

    public void SaveCharacterDataToDisk(GameManagerController.CHARACTERINDEX index, CharacterCustomizableData data)
    {
        string filePath = Path.Combine(Application.dataPath, index.ToString() + ".json");

        if (File.Exists(filePath))
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(filePath, json);
        }
    }

    public CharacterCustomizableData LoadCharacterDataFromDisk(GameManagerController.CHARACTERINDEX i)
    {
        string filePath = Path.Combine(Application.dataPath, i.ToString() + ".json");

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            CharacterCustomizableData cData = JsonUtility.FromJson<CharacterCustomizableData>(dataAsJson);
            return cData;
        }

        return null;
    }
}
