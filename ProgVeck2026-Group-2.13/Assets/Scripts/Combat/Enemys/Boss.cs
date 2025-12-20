using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    EnemyStats stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats.LoadResources();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
