using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public float xRange;

    public float botLimit;
    public float topLimit;
    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        this.speed = 15.0f;
        this.xRange = 20.0f;
        this.topLimit = 7.0f;
        this.botLimit = -2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //control limite izquierdo
        if (transform.position.x < -xRange )
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //control limite derecho
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //control limite inferior
        if (transform.position.z < botLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, botLimit);
        }
        //control limite superior
        if (transform.position.z > topLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topLimit);
        }

        this.horizontalInput = Input.GetAxis("Horizontal");
        this.verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * this.horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * this.verticalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Dispara la comida
            //Instantiate crea un prefab en la posicion actual del jugador
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
