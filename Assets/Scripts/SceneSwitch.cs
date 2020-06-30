using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        GameManager.gm.LoadScene(sceneName);
    }
}
