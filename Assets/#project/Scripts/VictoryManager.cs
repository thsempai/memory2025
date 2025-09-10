using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    private string sceneName;
    [SerializeField] private float delayBeforeLoadingScene = 2f;

    public void Initialize(string sceneName)
    {
        this.sceneName = sceneName.Trim();
    }

    public void LaunchVictory()
    {
        StartCoroutine(_LaunchVictory());
    }

    private IEnumerator _LaunchVictory()
    {
        yield return new WaitForSeconds(delayBeforeLoadingScene);
        SceneManager.LoadScene(sceneName);
    }

}
