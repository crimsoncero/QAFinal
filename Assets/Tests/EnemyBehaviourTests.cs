using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemyBehaviourTests
{
    
    [UnityTest]
    public IEnumerator EnemySpawnTest()
    {
        string sceneName = "Stage 1";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.SetImmune(true);

        yield return new WaitForSeconds(5f);
        
        LogAssert.Expect(LogType.Log, "Enemy Spawned");
    }
    
    [UnityTest]
    public IEnumerator EnemyShootTest()
    {
        string sceneName = "Stage 1";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.SetImmune(true);
        
        yield return new WaitForSeconds(5f);
        
        LogAssert.Expect(LogType.Log, "Enemy Projectile Spawned");
    }
    
    [UnityTest]
    public IEnumerator EnemyHitTest()
    {
        string sceneName = "Stage 1";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.SetImmune(true);
        PlayerShooting playerShooting = GameObject.Find("Player").GetComponent<PlayerShooting>();
        playerShooting.fireRate = 10;
        yield return new WaitForSeconds(5f);
        
        LogAssert.Expect(LogType.Log, "Enemy Hull Hit");
    }
    
    [UnityTest]
    public IEnumerator EnemyShieldTest()
    {
        string sceneName = "Stage 2";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.SetImmune(true);
        PlayerShooting playerShooting = GameObject.Find("Player").GetComponent<PlayerShooting>();
        playerShooting.fireRate = 10;
        yield return new WaitForSeconds(5f);
        
        LogAssert.Expect(LogType.Log, "Enemy Shield Hit");
    }
    
    [UnityTest]
    public IEnumerator EnemyDestroyedTest()
    {
        string sceneName = "Stage 1";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.SetImmune(true);
        PlayerShooting playerShooting = GameObject.Find("Player").GetComponent<PlayerShooting>();
        playerShooting.fireRate = 10;
        
        yield return new WaitForSeconds(5f);
        
        LogAssert.Expect(LogType.Log, "Enemy Destroyed");
    }
}
