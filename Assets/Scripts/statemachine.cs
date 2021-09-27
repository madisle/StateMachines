using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statemachine : MonoBehaviour
{
    // Start is called before the first frame update
    public enum state
    {
        idle,
        walking,
        swiming,
        climbing
    }
    public state currentstate= state.idle;
    Vector3 lastposition;
    void Start()
    {
        lastposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentstate)
        {
            case state.idle: idle();
                break;
            case state.walking: walking();
                break;
            case state.swiming: swimming();
                break;
            case state.climbing: climbing();
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="WaterTrigger")
        {
            currentstate = state.swiming;
        }
        else if (other.name=="MountainTrigger")
        {
            currentstate = state.climbing;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currentstate = state.walking;
    }
    void swimming()
    {

    }
    void climbing()
    {

    }
    void idle()
    {
        if (lastposition!=transform.position)
        {
            currentstate = state.walking;
        }
        lastposition = transform.position;
    }
    void walking()
    {
        if (lastposition == transform.position)
        {
            currentstate = state.idle;
        }
        lastposition = transform.position;
    }
}
