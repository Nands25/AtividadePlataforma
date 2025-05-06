using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) 
            {
                SetupInstance();
            }
            return instance;
        }
    }

    public object LoadScene { get; set; }

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void SetupInstance() 
    {
        instance = FindObjectOfType<GameManager>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject(); 
            gameObj.name = "Singleton"; 
            instance = gameObj.AddComponent<GameManager>(); 
            DontDestroyOnLoad(gameObj); 
        }
    }
    
    private IEnumerator LoadSplashScene() 
    {
        SceneManager.LoadScene("Splash", LoadSceneMode.Additive);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("MainMenu");

        SceneManager.UnloadSceneAsync("Splash");
    }

    public void LoadScene1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    
}
