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
        attackTypes = Resources.LoadAll<AttackType>(resourcesDirectory);
    }
    public int GetHealth()
    {   return health;  }
    public int GetSpeed()
    {   return speed;  }
}
