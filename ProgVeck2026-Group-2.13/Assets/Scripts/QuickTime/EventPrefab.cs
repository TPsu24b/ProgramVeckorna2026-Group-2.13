using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventPrefab : MonoBehaviour
{
    //the sizes for the timer
    private Vector3 startScale, endScale = new Vector3(0.75f, 0.75f, 0.75f);
    [SerializeField]
    float pressZoneScale;
    public float shrinkDuration = 2f;
    private float elapsedTime;
    public Transform toShrink;
    public InputActionReference inputAction;
    public TextMeshProUGUI text;
    void Start()
    {
        startScale = toShrink.localScale;
        manager = transform.parent.GetComponent<EventManager>();
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / shrinkDuration;

        toShrink.localScale = Vector3.Lerp(startScale, endScale, t);

        // Optional: stop once finished
        if (t >= 1f)
        {
            Debug.Log($"{this}: QT finished");
            manager.UpdateCompletedEvents(-1);
            Destroy(gameObject);
        }
        if(inputAction.action.IsPressed())
            ButtonPressed();
    }
    EventManager manager;
    public void ButtonPressed()
    {
        bool b = QuickTimeEventMissedOrHit();
        if(b)
        {
            manager.UpdateCompletedEvents(1);
        }
        else if(!b)
        {
            manager.UpdateCompletedEvents(-1);
        }
        Destroy(gameObject);
    }
    public bool QuickTimeEventMissedOrHit()
    {
        if(toShrink != null)
        {
            if(toShrink.localScale.x <= pressZoneScale)
            {
                Debug.Log($"{this}: Green zone");
                return true;
            }
            else if(toShrink.localScale.x >= pressZoneScale)
            {
                Debug.Log($"{this}: RED zone");
                return false;
            }
        }
        return false;
    }
}
