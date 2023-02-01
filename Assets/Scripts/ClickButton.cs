using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour
{    public void DoClick()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0);
#if UNITY_STANDALONE_WIN
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
#endif
    }
}
