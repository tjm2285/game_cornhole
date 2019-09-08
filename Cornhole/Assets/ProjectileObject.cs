using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObject : MonoBehaviour
{
    private int _duration = 30;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(LifeSpan());
    }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(_duration);
        Destroy(gameObject);
    }
}
