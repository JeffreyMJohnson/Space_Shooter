using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public float speed;

    private Rigidbody rBody;

	void Start () {
        rBody = GetComponent<Rigidbody>();
        rBody.velocity = transform.forward * speed;
	}
}
