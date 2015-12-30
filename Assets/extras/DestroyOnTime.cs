using UnityEngine;
using System.Collections;

public class DestroyOnTime : MonoBehaviour
{
    public float time = 0f;
    void Start()
    {
        StartCoroutine(DelayedDestroy());
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
    
}
