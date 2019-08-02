using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public FrogController frogAnim;
    // Start is called before the first frame update
    private float t;
    private float t2;
    private Vector3 pos2;
    private Quaternion rot2;
    private float timer;
    private bool isLeft;
    private bool isRight;
    private bool isForward;
    void Start()
    {
        isForward = true;
        //pos2 = transform.position;
        rot2 = transform.rotation;
        frogAnim = GetComponent<FrogController>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime*2f;
        transform.position = Vector3.Lerp(transform.position, pos2, t);
        timer += Time.deltaTime;
        t2 += Time.deltaTime * 2f;
        transform.rotation = Quaternion.Lerp(transform.rotation, rot2, t2);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveForward();
            Invoke("Idle2",0.5f);
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

        Debug.Log(timer);
        Debug.Log("derecha: " +isRight);
        Debug.Log("izquierda: " + isLeft);
    }


    void Idle2()
    {
        frogAnim.Idle();
    }

    public void MoveForward()
    {
        if (t >= 1f)
        {
            isForward = true;
            frogAnim.Jump();
            t = 0;
            pos2 = transform.position + new Vector3(0, 0, 1);
            t2 = 0;
            if (isLeft)
            {
                isLeft = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
            }
            if (isRight)
            {
                isRight = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
            }
        }
    }

    public void MoveLeft()
    {
        if (t >= 1f)
        {
            isLeft = true;
            frogAnim.Jump();
            t = 0;
            t2 = 0;
            pos2 = transform.position + new Vector3(-1, 0, 0);
            if (isForward)
            {
                isForward = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, -90, 0));
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
            t = 0;
            t2 = 0;
            pos2 = transform.position + new Vector3(1, 0, 0);
            if (isForward)
            {
                isForward = false;
                rot2 = transform.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
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
        pos2 = transform.position;
    }
}
