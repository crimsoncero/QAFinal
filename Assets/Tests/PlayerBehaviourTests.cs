using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

public class PlayerBehaviourTests
{
    
    [UnityTest]
    public IEnumerator ShootTest()
    {
        string sceneName = "Stage 1";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.SetImmune(true);
        
        LogAssert.Expect(LogType.Log, "Player Projectile Spawned");
    }

    [UnityTest]
    public IEnumerator HitAndDeathTest()
    {
        string sceneName = "Stage 1";
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        PlayerShooting playerShooting = GameObject.Find("Player").GetComponent<PlayerShooting>();
        playerShooting.enabled = false;

        float testTime = 180f;

        while (testTime > 0f)
        {
            if (playerShooting == null)
            {
                break;
            }
            testTime -= 1f;
            yield return new WaitForSeconds(1f);
        }
        
        LogAssert.Expect(LogType.Log, "Player Destroyed");
        
    }
    
}
