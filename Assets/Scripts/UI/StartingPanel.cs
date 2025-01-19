using UnityEngine;

public class StartingPanel : MonoBehaviour
{
    public void StartGame()
    {
        GameController.Instance.StartGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
