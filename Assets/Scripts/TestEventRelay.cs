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
        yield return new WaitForSeconds(2);

        _relay.RaiseTest(gameObject.GetInstanceID(), false);
    }

    public void Test(int value, bool isRpc)
    {
        string debug;
#if UNITY_ANDROID
        debug = "VR";
#else
        debug = "PC";
#endif
        string callType = isRpc ? "Remote" : "Local";
        Debug.Log($"Platform is {debug}. Value received is {value}. {callType}");
    }
}
