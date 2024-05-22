using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private int sceneId;
    public void Update()
    {
        SceneManager.LoadScene(sceneId);
    }
}
