using UnityEngine;

public class DoorMechanism : SwitchReciever
{
    [SerializeField] Transform doorLeft, doorRight;
    [SerializeField] float startZOffset, endZOffset, timeToOpen, moveDistance;
    private float elapsedTime;
    [SerializeField] private bool doorOpen = false, active;
    [SerializeField] private float startZ, endZ;
    public override void Use()
    {
        StartDoorLoop(!doorOpen);
        doorOpen = !doorOpen;
    }
    public void StartDoorLoop(bool openDoor)
    {
        if(openDoor) //if opening
        {
            startZ = doorLeft.localPosition.z;
            endZ = endZOffset;
        }
        else if(!openDoor) //if closing
        {
            startZ = doorLeft.localPosition.z;
            endZ = startZOffset;
        }
        if(active)
            elapsedTime = 0;
        active = true;
    }
    void Update()
    {
        if(active)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / timeToOpen;

            doorLeft.localPosition = Vector3.Lerp(new Vector3(doorLeft.localPosition.x, doorLeft.localPosition.y, startZ), new Vector3(doorLeft.localPosition.x, doorLeft.localPosition.y, endZ), t);
            doorRight.localPosition = Vector3.Lerp(new Vector3(doorRight.localPosition.x, doorRight.localPosition.y, -startZ), new Vector3(doorRight.localPosition.x, doorRight.localPosition.y, -endZ), t);
            if(t >= 1f)
            {
                elapsedTime = 0;
                active = false;
                Debug.Log("Door finished");
            }
        }
    }
}
