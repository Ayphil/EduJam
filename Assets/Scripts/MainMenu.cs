using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
}
