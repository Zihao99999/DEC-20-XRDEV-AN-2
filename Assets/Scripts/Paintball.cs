using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour
{
    public List<Material> paintballPaints = new List<Material>();
    private static int paintIndex = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Paintable")
        {
            collision.collider.GetComponent<Renderer>().material = paintballPaints[paintIndex];

            paintIndex++;

            if(paintIndex == paintballPaints.Count)
            {
                paintIndex = 0;
            }
        }
    }
}
