using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    InputActionReference[] inputActionRef;
    [SerializeField]
    EventList eventList;
    [SerializeField]
    GameObject eventPrefab;
    [SerializeField]
    int eventsCompleted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QTMannager();
    }
    //loop for qt
    void QTMannager()
    {
        foreach(BaseEvent quickTimeEvent in eventList.quickTimeEvents)
        {
            EventPrefab newEvent = Instantiate(eventPrefab, Vector3.zero, quaternion.identity, transform).GetComponent<EventPrefab>();
            newEvent.transform.localPosition = quickTimeEvent.position;
            newEvent.shrinkDuration = quickTimeEvent.lifeTime;
            newEvent.inputAction = inputActionRef[quickTimeEvent.keyToPress];
        }
    }
    public void UpdateCompletedEvents(int i)
    {
        eventsCompleted += i;
    }
}
