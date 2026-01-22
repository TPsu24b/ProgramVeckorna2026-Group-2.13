using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharge : MonoBehaviour
{
    [SerializeField] private InputActionReference chargeInput;
    [SerializeField] private LayerMask layerMask;
    private bool lastChargeState;
    private float timeElapsed;
    [SerializeField] private float _radius, reach, chargeTime;
    void Update()
    {
        bool charging = chargeInput.action.IsPressed();
        if(charging != lastChargeState)
        {
            timeElapsed += Time.deltaTime;
        }
        else 
        {
            if(timeElapsed >= chargeTime && chargeInput.action.WasReleasedThisDynamicUpdate())
            {
                ShootProjectile();
                timeElapsed = 0;
                Debug.Log($"{this}: Shoot");
            }
            else if(chargeInput.action.WasReleasedThisDynamicUpdate())
            {
                ActivateNearbyOutput();
                timeElapsed = 0;
                Debug.Log($"{this}: Manual");
            }
            charging = lastChargeState;
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
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, reach, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.orange);
            hit.collider.gameObject.GetComponent<Output>().Use();
        }
        else 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.orange);
        }
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
    void OnDrawGizmos()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
