using UnityEngine;
[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    [SerializeField]
    int health, speed;
    [SerializeField]
    string resourcesDirectory;
    AttackType[] attackTypes;
    public void LoadResources()
    {
        try
        {
            attackTypes = Resources.LoadAll<AttackType>(resourcesDirectory);
            Debug.Log($"{this}: loaded resourses at {resourcesDirectory}");
        }
        catch
        {
            Debug.Log($"{this}: Failed to load resources type <AttackType> at {resourcesDirectory}");
        }
    }
    public int GetHealth()
    {   return health;  }
    public int GetSpeed()
    {   return speed;  }
}
