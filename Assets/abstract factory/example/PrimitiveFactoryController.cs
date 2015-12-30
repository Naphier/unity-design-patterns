using UnityEngine;
using System.Collections;
using NG.AbstractFactoryExample;

/// <summary>
/// This class is NOT part of the pattern. 
/// It simply exists as our main program from which we will 
/// run our application.
/// </summary>

public class PrimitiveFactoryController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FactoryRunner());
    }

    PrimitiveClient runningClient;
    IEnumerator FactoryRunner()
    {
        PrimitiveFactory factory = new PrimitiveFactory();
        PrimitiveClient client = new PrimitiveClient(factory);
        runningClient = client;
        for (int i = 0; i < 5; i++)
        {
            client.CreateProducts(typeof(PrimitiveA));
            client.CreateProducts(typeof(PrimitiveB));
        }

        StartCoroutine(client.Run());

        while (client.isRunning)
            yield return new WaitForEndOfFrame();

        PrimitiveFactory2 factory2 = new PrimitiveFactory2();
        PrimitiveClient client2 = new PrimitiveClient(factory2);
        runningClient = client2;
        for (int i = 0; i < 5; i++)
        {
            client2.CreateProducts(typeof(PrimitiveA));
            client2.CreateProducts(typeof(PrimitiveB));
        }
        StartCoroutine(client2.Run());
    }


    void OnGUI()
    {
        if (runningClient != null && runningClient.runState != null)
        {
            GUI.Label(new Rect(0, 0, 500, 500), runningClient.runState);
        }
    }
}
