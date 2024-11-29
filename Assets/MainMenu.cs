using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panelCredits;
    public GameObject panelMenu;
    private void Start()
    {
        panelCredits.SetActive(false);
        panelMenu.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        panelCredits.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void GoBack()
    {
        panelCredits.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
