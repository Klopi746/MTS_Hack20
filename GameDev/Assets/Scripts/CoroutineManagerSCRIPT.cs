using System.Collections;
using UnityEngine;

public class CoroutineManagerSCRIPT : MonoBehaviour
{
    public static CoroutineManagerSCRIPT Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void Run(IEnumerator Coroutine)
    {
        StartCoroutine(Coroutine);
    }



    public void Stop(IEnumerator Coroutine)
    {
        StopCoroutine(Coroutine);
    }
}
