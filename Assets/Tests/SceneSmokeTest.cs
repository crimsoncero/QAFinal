using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneSmokeTest
{
    // Add test case per scene that needs to be in the build    

    [UnityTest]
    public IEnumerator SceneOne()
    {
        string sceneName = "Stage 1";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Assert.AreEqual(sceneName, SceneManager.GetActiveScene().name);
    }
    
    [UnityTest]
    public IEnumerator SceneTwo()
    {
        string sceneName = "Stage 2";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Assert.AreEqual(sceneName, SceneManager.GetActiveScene().name);
    }
    
}
