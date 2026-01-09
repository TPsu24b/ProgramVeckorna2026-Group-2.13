using System.Collections;
using System.Threading;
using Unity.Mathematics;
using Unity.VisualScripting;
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
    [SerializeField]
    PlayerInput player;
    //loop for qt
    public IEnumerator QTMannager()
    {
        player.SwitchCurrentActionMap("QuickTime");
        foreach(BaseEvent quickTimeEvent in eventList.quickTimeEvents)
        {
            EventPrefab newEvent = Instantiate(eventPrefab, Vector3.zero, quaternion.identity, transform).GetComponent<EventPrefab>();
            newEvent.transform.localPosition = quickTimeEvent.position;
            newEvent.shrinkDuration = quickTimeEvent.lifeTime;
            newEvent.inputAction = inputActionRef[quickTimeEvent.keyToPress];
            yield return new WaitForSeconds(quickTimeEvent.delay);
        }
        player.SwitchCurrentActionMap("Movement");
    }
    public void UpdateCompletedEvents(int i)
    {
        eventsCompleted += i;
    }
}
