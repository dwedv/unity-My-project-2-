using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch: MonoBehaviour
{

    public Material material1;
    public Material material2;
    private bool isMaterial1Active = true;

    void Start()
    {
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Toggle the material based on the current state.
            if (isMaterial1Active)
            {
                GetComponent<Renderer>().material = material2;
            }
            else
            {
                GetComponent<Renderer>().material = material1;
            }
            // Flip the state to track which material is currently active.
            isMaterial1Active = !isMaterial1Active;

        }
    }
}
