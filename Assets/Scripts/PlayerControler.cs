using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{
    public enum Direction
    {
        Left, Right
    }

    Animator anim;
    [SerializeField] private jetpack _jetpack;
    private bool isStunned = false;
    private bool _inGround = false;
    [SerializeField] private int Speed;
    private Rigidbody2D rb;
    AudioManager audioManager;
    
    


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        walk();

        if (_inGround == true && _jetpack._flying == false && isStunned == false)
        {
            _jetpack.regenerate();
        }

        if (Input.GetAxis("Vertical") > 0 && isStunned == false)
        {
            
            audioManager.PlaySFX(audioManager.jetpack);
            _jetpack.flyUp();
        }
        if (Input.GetAxis("Vertical") < 0.1 && isStunned == false)
        {
            audioManager.StopSFX(audioManager.jetpack);
            _jetpack.stopFlying();
        }
    }


    void Update()
    {
        


        if (Input.GetAxis("Horizontal") > 0 && isStunned == false)
        {
            _jetpack.flyHorizontal(jetpack.Direction.Right);
            transform.localScale = new Vector3(-1, 1, 1);
            

        }
        if (Input.GetAxis("Horizontal") < 0 && isStunned == false)
        {
            _jetpack.flyHorizontal(jetpack.Direction.Left);
            transform.localScale = new Vector3(1, 1, 1);


        }

        

      
        


        //animation controller


        anim.SetBool("Running", Input.GetAxis("Horizontal") != 0 && _inGround == true);
        anim.SetBool("isFlying",_jetpack._flying == true);
        //anim.SetTrigger("Hit",);





    }

    public void WalkDirection(Direction direction)
    {
        if (direction == Direction.Left)
        {
            rb.AddForce(Vector2.left * Speed);
        }
        else
        {
            rb.AddForce(Vector2.right * Speed);
        }
    }

    public void walk()
    {
        if (_inGround && _jetpack._flying == false)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                WalkDirection(Direction.Right);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                WalkDirection(Direction.Left);
            }

        }
    }



    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _inGround = true;
        }
            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _inGround = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Destruir el objeto si la colisión tiene el tag "tagejemplo"


        if (collider.gameObject.CompareTag("GoodItem"))
        {
            audioManager.PlaySFX(audioManager.hit);
            ParticleSystem particles = collider.GetComponentInChildren<ParticleSystem>();
            if (particles != null)
            {
                // Desvincular las partículas del objeto para que sigan visibles tras su destrucción
                particles.transform.parent = null;

                // Emitir partículas
                particles.Play();

                // Destruir el objeto original
                Destroy(collider.gameObject);

                // Destruir las partículas después de que terminen
                Destroy(particles.gameObject, particles.main.duration);
            }
            _jetpack.Energy += 100;
        }
        else if (collider.gameObject.CompareTag("BadItem"))
        {
            audioManager.PlaySFX(audioManager.hit);
            ParticleSystem particles = collider.GetComponentInChildren<ParticleSystem>();
            if (particles != null)
            {
                // Desvincular las partículas del objeto para que sigan visibles tras su destrucción
                particles.transform.parent = null;

                // Emitir partículas
                particles.Play();

                // Destruir el objeto original
                Destroy(collider.gameObject);

                // Destruir las partículas después de que terminen
                Destroy(particles.gameObject, particles.main.duration);
            }

            anim.SetTrigger("Hit");
            _jetpack._flying = false;
            _jetpack.Energy = 0;
            ApplyStun(1);

        }
    }


    public void ApplyStun(float duration)
    {
        // Llama a la corrutina para manejar el tiempo de stun
        StartCoroutine(Stun(duration));
    }

    private IEnumerator Stun(float duration)
    {
        isStunned = true; // Activar el stun
        yield return new WaitForSeconds(duration); // Esperar el tiempo de duración
        isStunned = false; // Desactivar el stun
    }
}
