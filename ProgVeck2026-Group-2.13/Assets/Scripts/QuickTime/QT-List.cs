using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu]
public class EventList : ScriptableObject
{
    [Header("A list of the QT events and what order they appear in\nLife Time is the time you have to interact with the event\nKey To Press represents an index for QTM inputs\nDelay is the delay for the next event to spawn\nPosition is the pos of the event on the screen")]
    public List<BaseEvent> quickTimeEvents = new List<BaseEvent>();
}
