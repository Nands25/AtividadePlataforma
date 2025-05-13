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
    
    private void Start()
    {
        StartCoroutine(LoadSplashScene());
    }
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
            GameObject gameObj = new GameObject("GameManager"); 
            instance = gameObj.AddComponent<GameManager>(); 
            DontDestroyOnLoad(gameObj); 
        }
    }
    
    private IEnumerator LoadSplashScene() 
    {
        // Carrega a Splash como única cena
        SceneManager.LoadScene("Splash");

        // Espera 2 segundos
        yield return new WaitForSeconds(2f);

        // Carrega o menu principal
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadScene1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    
}
