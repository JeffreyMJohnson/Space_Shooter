using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float fireRate;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

    private Rigidbody rBody;
    private AudioSource audio;
    private float nextFire = 0.0f;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rBody.velocity = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);

        rBody.position = new Vector3(
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rBody.position.z, boundary.zMin, boundary.zMax));

        rBody.rotation = Quaternion.Euler(0, 0, rBody.velocity.x * -tilt);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audio.Play();
        }

    }
}
