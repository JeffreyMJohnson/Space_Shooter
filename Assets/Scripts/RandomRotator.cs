using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

    private Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();

        rBody.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
