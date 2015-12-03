using UnityEngine;
using System.Collections;
using NG.PrimitiveFactory;

public class PrimitiveFactoryController : MonoBehaviour
{
    void Start()
    {
        PrimitiveFactory factory = new PrimitiveFactory();
        PrimitiveClient client = new PrimitiveClient(factory);

        StartCoroutine(client.Run());
    }

    void Update()
    {

    }
}
