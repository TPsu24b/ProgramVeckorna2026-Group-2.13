using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventManager : MonoBehaviour
{
    [Header("Event ref")]
    [SerializeField] InputActionReference[] inputActionRef;
    [SerializeField] EventList eventList;
    [SerializeField] GameObject eventPrefab, tutorial;
    [Header("Player ref")]
    [SerializeField] GameObject playerOBJ;
    [SerializeField] PlayerInput player;
    [Header("Event info")]
    public List<EventPrefab> activeEvents = new List<EventPrefab>();
    [SerializeField] int eventsCompleted;
    private Vector3 nextPos, previousePos;
    [Header("Lerp Movment")]
    [SerializeField] private bool atCorrectPos;
    [SerializeField] private float moveSpeed; 
    private float elapsedTime;
    //loop for qt
    void Start()
    {
        tutorial.SetActive(true);
        StartCoroutine(QTMannager());
    }
    public IEnumerator QTMannager()
    {
        yield return new WaitForSeconds(5);
        tutorial.SetActive(false);
        player.SwitchCurrentActionMap("QuickTime");
        foreach(BaseEvent quickTimeEvent in eventList.quickTimeEvents)
        {
            EventPrefab newEvent = Instantiate(eventPrefab, Vector3.zero, quaternion.identity, transform).GetComponent<EventPrefab>();
            newEvent.transform.localPosition = quickTimeEvent.position;
            newEvent.shrinkDuration = quickTimeEvent.lifeTime;
            newEvent.inputAction = inputActionRef[quickTimeEvent.keyToPress];
            newEvent.text.text = inputActionRef[quickTimeEvent.keyToPress].action.GetBindingDisplayString();
            activeEvents.Add(newEvent);
            yield return new WaitForSeconds(quickTimeEvent.lifeTime + 1f);
        }
        player.SwitchCurrentActionMap("Movement");
        yield return StartCoroutine(QTMannager());
    }
    public void UpdateCompletedEvents(int updatePos, float moveSpeed)
    {
        eventsCompleted += updatePos;
        nextPos.y += updatePos;
        atCorrectPos = false;
        this.moveSpeed = moveSpeed;
    }
    //next pos thingy
    void Update()
    {
        if(playerOBJ.transform.position == nextPos && !atCorrectPos)
        {
            previousePos = nextPos;
            atCorrectPos = true;
            elapsedTime = 0;
        }
        else if(!atCorrectPos)
        {    
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveSpeed;
            playerOBJ.transform.position = Vector3.Lerp(previousePos, nextPos, t);
        }
    }
}
