using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTriggerZone : MonoBehaviour
{
    public Animator bridgeAnim;

    private void OnTriggerEnter(Collider other)
    {
        bridgeAnim.SetTrigger("Rise");
    }
}
