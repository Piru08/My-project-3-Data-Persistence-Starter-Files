using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string PlayerName;
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
        if (PlayerName == null)
        {
            PlayerName = "Some player";
        }
    }

    public void InputName()
    {
            PlayerName = field.text;
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
        data.PlayerName = PlayerName;

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
            PlayerName = data.PlayerName;
        }
    }
}
