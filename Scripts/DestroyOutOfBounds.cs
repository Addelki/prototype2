using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    private float leftBound = 30.0f;
    private float rightBound = -30.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Posicion del GameObject
        float zeta = transform.position.z;
        float equis = transform.position.x;
        //Se destuye si sale fuera de rango.
        if (zeta > this.topBound)
        {
            Destroy(gameObject);
        }
        else if (zeta < lowerBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (equis < rightBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        else if (equis > leftBound)
        {
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
    }
}
