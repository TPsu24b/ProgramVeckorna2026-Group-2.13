using Unity.Mathematics;
using UnityEngine;

public class EventPrefab : MonoBehaviour
{
    //the sizes for the timer
    private Vector3 startScale, endScale = new Vector3(0.75f, 0.75f, 0.75f);
    public float shrinkDuration = 2f;
    private float elapsedTime;
    public Transform toShrink;
    void Start()
    {
        startScale = toShrink.localScale;
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
            Destroy(gameObject);
        }
    }
}
