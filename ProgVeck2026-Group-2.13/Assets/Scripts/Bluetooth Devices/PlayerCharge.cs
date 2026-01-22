using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharge : MonoBehaviour
{
    [SerializeField] private InputActionReference chargeInput;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private LayerMask layerMask;
    private bool lastChargeState;
    private float timeElapsed, chargeTime;
    [SerializeField] private float _radius, reach;
    void Update()
    {
        bool charging = chargeInput.action.IsPressed();
        if(charging == lastChargeState)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= chargeTime)
                ShootProjectile();
        }
        else
        {
            
        }
    }
    void ActivateNearbyOutput()
    {
        Output[] outputs = GetNearByOutputs(_radius);
        for(int i = 0; i < outputs.Length; i++)
            outputs[i].Use();
    }
    void ShootProjectile()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, reach, layerMask);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.orange);
    }
    Output[] GetNearByOutputs(float radius)
    {
        Collider[] c = Physics.OverlapSphere(
            transform.position,
            radius,
            layerMask
            );
        List<Output> outputs = new List<Output>();
        foreach(Collider colliderToGet in c)
            outputs.Add(colliderToGet.GetComponent<Output>());
        return outputs.ToArray();
    }
}
