using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_World : MonoBehaviour
{
    private void Start()
    {
        print("Hello World!");
    }

    // mejora
    public string PrintEveryFrame;
    private void Update()
    {
        print(PrintEveryFrame);
    }
}
