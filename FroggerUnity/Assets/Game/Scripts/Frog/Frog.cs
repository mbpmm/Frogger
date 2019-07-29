using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public FrogController frogAnim;
    // Start is called before the first frame update
    private float timer;
    void Start()
    {

        frogAnim = GetComponent<FrogController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer>2.5f)
        {
            frogAnim.Jump();
            Invoke("Idle2",1.0f);
            timer = 0;
        }

        Debug.Log(timer);
    }


    void Idle2()
    {
        frogAnim.Idle();
    }
}
