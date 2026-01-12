using Assets.Scripts.Bluetooth_Devices;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DoorMechanism : MonoBehaviour
{
    public float speed, moveDistance;
    Rigidbody rb1,rb2;
    public GameObject door1, door2;
    [SerializeField] SwitchReciever doorSwitch;
    [SerializeField] Vector3 doorStartPos1, doorStartPos2;
    [SerializeField] Vector3 doorEndPos1, doorEndPos2;
    void Start()
    {
        rb1 = door1.GetComponent<Rigidbody>();
        rb2 = door2.GetComponent<Rigidbody>();
        doorStartPos1 = rb1.position;
        doorStartPos2 = rb2.position;
        doorEndPos1 = rb1.position + new Vector3(0, 0, moveDistance);
        doorEndPos2 = rb2.position + new Vector3(0, 0, -moveDistance);

    }

    // Update is called once per frame
    void Update()
    {
        if (doorSwitch.mode == true)
        {
            Vector3.Lerp(doorStartPos1, doorEndPos1, speed);
            Vector3.Lerp(doorStartPos2, doorEndPos2, speed);
        }
        else
        {
            rb1.position = doorStartPos1;
            rb2.position = doorStartPos2;
        }
    }
}
