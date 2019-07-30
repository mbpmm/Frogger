using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public FrogController frogAnim;
    // Start is called before the first frame update
    private float t;
    private Vector3 pos2;
    private float timer;
    private float timer2;
    void Start()
    {
        pos2 = transform.position;
        frogAnim = GetComponent<FrogController>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, pos2, t);
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W))
        {
            Move();
            Invoke("Idle2",0.5f);
            timer = 0;
        }

        Debug.Log(timer);
    }


    void Idle2()
    {
        frogAnim.Idle();
    }

    public void Move()
    {
        frogAnim.Jump();
        t = 0;
        pos2 = transform.position + new Vector3(0, 0, 1);
        
    }
}
