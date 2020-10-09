using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Engine))]
public class InputReceiver : MonoBehaviour
{
    Engine engine;

    private void Awake()
    {
        engine=GetComponent<Engine>();
    }

    private void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");


            engine.Gas(v);
        

            engine.Brake(100);
        

            engine.Steer(h);
        

          
        

    }
}
