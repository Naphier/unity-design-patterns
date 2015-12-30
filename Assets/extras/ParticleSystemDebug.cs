using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSystemDebug : MonoBehaviour
{
    ParticleSystem pSys;
    public bool show = true;

    void Start()
    {
        pSys = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pSys.Stop();
            pSys.Clear();
            pSys.Play();
        }

        if (Input.GetMouseButton(0))
            pSys.Emit(1);
    }

    void OnGUI()
    {
        if (!show)
            return;

        string meessage = string.Format(
            "isPlaying: {0}" +
            "\nisPaused: {1}" +
            "\nisStopped: {2}" + 
            "\nisAlive: {3}" + 
            "\nemission.enabled: {4}" + 
            "\nparticleCount: {5}",
            pSys.isPlaying,
            pSys.isPaused,
            pSys.isStopped,
            pSys.IsAlive(),
            pSys.emission.enabled,
            pSys.particleCount
            );

        GUI.Label(new Rect(300, 0, 500, 500), meessage);
    }
}
