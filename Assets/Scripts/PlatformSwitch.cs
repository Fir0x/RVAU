using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    enum Platform
    {
        PC,
        VR
    }

    [SerializeField] private Platform _platform;

    // Start is called before the first frame update
    void Start()
    {
# if PLATFORM_ANDROID 
        if (_platform == Platform.PC)
            Destroy(gameObject);
#else
        if (_platform == Platform.VR)
            Destroy(gameObject);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
#endif
    }
}
