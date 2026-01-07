using UnityEngine;
using UnityEngine.InputSystem;

public class QuickTimeManager : MonoBehaviour
{
    [SerializeField]
    InputActionReference[] inputActionRef;
    [SerializeField]
    QuickTimeList quickTimeList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QTMannager();
    }
    //loop for qt
    void QTMannager()
    {
        
    }
}
