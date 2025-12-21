using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    int health;
    public void UpdateHealth(int updateHealth)
    {   health += updateHealth;  }
    public int GetHealth()
    {   return health;  }
}
