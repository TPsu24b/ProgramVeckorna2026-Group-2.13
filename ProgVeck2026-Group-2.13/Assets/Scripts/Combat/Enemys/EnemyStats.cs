using UnityEngine;
[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    [SerializeField]
    int health, movmentSpeed;
    [SerializeField]
    string resourcesDirectory;
    AttackType[] attackTypes;
    //loads attackTypes out of the resources folder
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
    public int GetMovmentSpeed()
    {   return movmentSpeed;  }
}
