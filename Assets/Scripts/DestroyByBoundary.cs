using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{

    private void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject);
    }
}
