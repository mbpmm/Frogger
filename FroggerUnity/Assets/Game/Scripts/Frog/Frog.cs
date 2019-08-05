using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public FrogController frogAnim;
    public Rigidbody rb;
    private float t;
    private float t2;
    private Vector3 pos2;
    private Quaternion rot2;
    private float timer;
    private bool isLeft;
    private bool isRight;
    private bool isForward;
    private bool isBack;
    private bool onGround;
    void Start()
    {
        isForward = true;
        pos2 = new Vector3(0, 0.51f,0);
        rot2 = transform.rotation;
        frogAnim = GetComponent<FrogController>();
        rb = GetComponent<Rigidbody>();
    }
    public float tiempoDeSalto = 0;
    public float tiempoDeSaltoTotal = 0.5f;
    public Vector3 lastPos;
    public Vector3 newPos;
    // Update is called once per frame
    void FixedUpdate()
    {
        t += Time.deltaTime*2f;
        //transform.position = Vector3.Lerp(transform.position, pos2, t);
        tiempoDeSalto += Time.deltaTime;
        if ( tiempoDeSalto / tiempoDeSaltoTotal <= 1)
            rb.MovePosition(Vector3.Lerp(lastPos, newPos, tiempoDeSalto / tiempoDeSaltoTotal));

        if (tiempoDeSalto / tiempoDeSaltoTotal > 1 && (tiempoDeSalto / tiempoDeSaltoTotal <1.5F))
            rb.transform.position = newPos;


        //rb.MovePosition(Vector3.Lerp(transform.position, pos2, t));
        timer += Time.deltaTime;
        t2 += Time.deltaTime * 2f;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot2, t2);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveForward();
            Invoke("Idle2", 0.5f);
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBack();
            Invoke("Idle2", 0.5f);
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
            Invoke("Idle2", 0.5f);
            timer = 0;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
            Invoke("Idle2", 0.5f);
            timer = 0;
        }

        
    }
    void Idle2()
    {
        frogAnim.Idle();
    }

    public void MoveForward()
    {
        //if (t >= 1f)
        //{
        //    isForward = true;
            frogAnim.Jump();
            lastPos = transform.position;
            rb.velocity = new Vector3(0, 5f, 0);
            //t = 0;
            //pos2 = transform.position + new Vector3(0, 0, 1);
            
            newPos = transform.position + new Vector3(0, 0, 1);
            tiempoDeSalto = 0;
            //t2 = 0;
            //if (isLeft)
            //{
            //    isLeft = false;
            //    rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
            //}
            //if (isRight)
            //{
            //    isRight = false;
            //    rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
            //}
            //if (isBack)
            //{
            //    isBack = false;
            //    rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0));
            //}
        //}
    }

    public void MoveBack()
    {
        if (t >= 1f)
        {
            isBack = true;
            frogAnim.Jump();
            rb.velocity = new Vector3(0, 5f, 0);
            t = 0;
            pos2 = transform.position + new Vector3(0, 0, -1);
            t2 = 0;
            if (isLeft)
            {
                isLeft = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
            }
            if (isRight)
            {
                isRight = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
            }
            if (isForward)
            {
                isForward = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }
    }

    public void MoveLeft()
    {
        if (t >= 1f)
        {
            isLeft = true;
            frogAnim.Jump();
            rb.velocity = new Vector3(0, 5f, 0);
            t = 0;
            t2 = 0;
            pos2 = transform.position + new Vector3(-1, 0, 0);
            if (isForward)
            {
                isForward = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
            }
            if (isBack)
            {
                isBack = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
            }
            if (isRight)
            {
                isRight = false;
                isLeft = true;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, -180, 0));
            }
        }
    }

    public void MoveRight()
    {
        if (t >= 1f)
        {
            isRight = true;
            frogAnim.Jump();
            rb.velocity = new Vector3(0, 5f, 0);
            t = 0;
            t2 = 0;
            pos2 = transform.position + new Vector3(1, 0, 0);
            if (isForward)
            {
                isForward = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
            }
            if (isBack)
            {
                isBack = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
            }
            if (isLeft)
            {
                isRight = true;
                isLeft = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //pos2 = transform.position;
        onGround = true;
        if (collision.gameObject.tag=="floor")
        {
            Debug.Log("colisiona");
        }
        if (collision.gameObject.tag == "tree")
        {
            Debug.Log("pega en el arbol");
            //transform.position = collision.transform.position;
        }
        if (collision.gameObject.tag == "car")
        {
            Debug.Log("pega en el auto");
        }

    }
}
