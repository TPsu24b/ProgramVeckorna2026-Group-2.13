using System.IO;
using UnityEngine;

public class SavePointManager : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Vector3 posData;
    void Awake()
    {
        try
        {
            string data = File.ReadAllText(Application.persistentDataPath + "/savePoint.json");
            posData = JsonUtility.FromJson<Vector3>(data);
        }
        catch
        {
            Debug.Log($"{this}: no data exist, no prob tho!");
        }
    }
    public void UpdateSavePoint(Transform transform)
    {
        posData = transform.position;
        SaveData();
    }
    void SaveData()
    {
        string data = JsonUtility.ToJson(posData, true);
        File.WriteAllText(Application.persistentDataPath + "/savePoint.json", data);
    }
    public void LoadLocation()
    {
        player.position = posData;
    }
}
