using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Walking : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    private Vector3 movement;

    public float jump_force;

    public KeyCode run;

    private Rigidbody rig;
    private Animator anim;
    public float moveSpeed = 20.0f;
    public Vector3 direcaoDoPulo = new Vector3(0, 1, 0);
    [Range(1, 20)]
    public float forcaDoPulo = 5.0f;
    [Range(0.5f, 10.0f)]
    public float DistanciaDoChao = 1;
    [Range(0.5f, 5.0f)]
    public float TempoPorPulo = 1.5f;
    public LayerMask LayersNaoIgnoradas = -1;
    private bool estaNoChao, contar = false;
    private float cronometro = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        jump();
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        if (xAxis == 1)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), moveSpeed);

        }

        if (xAxis == -1)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * moveSpeed);

        }

        if (zAxis == 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * moveSpeed);
        }


        if (zAxis == -1)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -180, 0), Time.deltaTime * moveSpeed);

        }

    }
        

    private void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0f, vertical);
    }

    private void FixedUpdate()
    {
        move();
        Run();
    }

    private void move()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
    void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(direcaoDoPulo * forcaDoPulo, ForceMode.Impulse);
            estaNoChao = false;
            contar = true;
        }

        if (contar == true)
        {
            cronometro += Time.deltaTime;
        }
        if (cronometro >= TempoPorPulo)
        {
            contar = false;
            cronometro = 0;
        }
    
        {
           
        }
    }
    void Run()
    {
        if (Input.GetKey(run))
        {
            speed = 15f;
        }
    }
}

