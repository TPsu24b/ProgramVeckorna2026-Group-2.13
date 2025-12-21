using UnityEngine;
[CreateAssetMenu]
public class AttackType : ScriptableObject
{
    [SerializeField]
    int damage, linger;
    [SerializeField]
    GameObject hitbox;
    
}
