using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public void SetSize(float w,float h)
    {
        BoxCollider boxcollider = GetComponent<BoxCollider>();

        boxcollider.size = new Vector3(w, 10, h);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
