using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.LoadScene1("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("jogo encerrado");
    }
}
