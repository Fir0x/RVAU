using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventRelay : MonoBehaviour
{
    [SerializeField] private EventRelay _relay;

    private void Start()
    {
        StartCoroutine(Launcher());
    }

    IEnumerator Launcher()
    {
        yield return new WaitForSeconds(5);
    }

    public void Test(int value, bool isRpc)
    {
        string debug;
#if UNITY_ANDROID
        debug = "VR"
#else
        debug = "PC";
#endif
        Debug.Log($"Platform is {debug}. Value received is {value}. {(isRpc ? "Remote" : "Local")}");
    }
}
