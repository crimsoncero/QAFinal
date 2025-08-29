using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SceneSmokeTest
{
    // Add test case per scene that needs to be in the build    
    
    [TestCase("Stage 1", ExpectedResult = (IEnumerator)null)]
    [TestCase("Stage 2", ExpectedResult = (IEnumerator)null)]
    [UnityTest]
    public IEnumerator SceneLoadsWithoutErrors(string sceneName)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Assert.AreEqual(sceneName, SceneManager.GetActiveScene().name);
    }
}
