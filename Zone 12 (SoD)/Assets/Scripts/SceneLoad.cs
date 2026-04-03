using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneLoad : MonoBehaviour
{
    public String sceneToLoad;
    public Slider loadingBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        AsyncOperation LoadOperation= SceneManager.LoadSceneAsync(sceneToLoad);
        
        while (!LoadOperation.isDone)
        {
            float progress = Mathf.Clamp01(LoadOperation.progress / 0.9f);
            loadingBar.value = progress;

            yield return null;
        }
    }

    
}
