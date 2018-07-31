using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvisible : MonoBehaviour {

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
