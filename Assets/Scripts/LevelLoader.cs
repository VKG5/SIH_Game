using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float waitInSeconds = 1.5f;
    int currSceneIndex;
    // Start is called before the first frame update
    void Start()
    {   
        currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currSceneIndex==0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(waitInSeconds);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currSceneIndex + 1);
    }
}
