using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMovement : MonoBehaviour
{
    private int fallSpeed = 4;
    private int destroyTime = 30;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

     
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Destruir el objeto si la colisión tiene el tag "tagejemplo"
       

        if(collider.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }



}
