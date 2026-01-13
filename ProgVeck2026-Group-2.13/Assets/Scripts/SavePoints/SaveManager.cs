using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] string data;
    [SerializeField] ASyncLoader loader;
    void Awake()
    {
        try
        {
            string data = File.ReadAllText(Application.persistentDataPath + "/savePoint.json");
            this.data = JsonUtility.FromJson<string>(data);
        }
        catch
        {
            Debug.Log($"{this}: no data exist, no prob tho!");
        }
    }
    public void SaveData(string sceneName)
    {
        string data = JsonUtility.ToJson(sceneName, true);
        File.WriteAllText(Application.persistentDataPath + "/savePoint.json", data);
    }
    public void LoadScene()
    {
        loader.LoadLevelBtn(data);
    }
}
