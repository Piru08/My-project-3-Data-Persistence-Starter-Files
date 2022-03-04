using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string playerName;
    public string playername;
    public int BestPoint;
    public InputField field;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void InputName()
    {
        playername = field.text;
        if (playername == null)
        {
            playername = "Some player";
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int BestPoint;
    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.BestPoint = BestPoint;
        data.PlayerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPoint = data.BestPoint;
            playerName = data.PlayerName;
        }
    }
}
