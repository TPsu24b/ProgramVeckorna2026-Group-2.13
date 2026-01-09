using System.IO;
using UnityEngine;

public class SavePointManager : MonoBehaviour
{
    [SerializeField]
    Transform currentSavePoint, player;
    void Awake()
    {
        string data = File.ReadAllText(Application.persistentDataPath);
        currentSavePoint = JsonUtility.FromJson<Transform>(data);
    }
    public void UpdateSavePoint(Transform transform)
    {
        currentSavePoint = transform;
        SaveData();
    }
    void SaveData()
    {
        string data = JsonUtility.ToJson(currentSavePoint);
        File.WriteAllText(Application.persistentDataPath, data);
    }
    public void LoadLocation()
    {
        player.position = currentSavePoint.position;
    }
}
