using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (null != gameControllerObject)
        {
            gameController = gameControllerObject.GetComponent<GameController>();

        }
        if(null == gameController)
        {
            Debug.Log("Cannot find GameController script.");
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Boundary")
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        if (col.tag == "Player")
        {
            Instantiate(playerExplosion, col.transform.position, col.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        Destroy(col.gameObject);
        Destroy(gameObject);
    }

}
