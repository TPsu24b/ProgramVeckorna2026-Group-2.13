using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class QuickTimeList : ScriptableObject
{
    public List<QuickTimeEvent> quickTimeEvents = new List<QuickTimeEvent>();
}
