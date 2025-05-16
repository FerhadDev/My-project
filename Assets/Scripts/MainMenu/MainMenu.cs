using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("MainMenu References")]
    [SerializeField] private GameObject _SettingMenu;
    [SerializeField] private GameObject _MainMenu;
    [SerializeField] private GameObject _RulesMenu;
    [SerializeField] private GameObject _CreditsMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Hal haz;rda oldugun sceneden sonra gelen sceneye kecir.
    }
    public void GoToSettingMenu()
    {
        _SettingMenu.SetActive(true);
    }
    public void GoToRulesMenu()
    {
        _RulesMenu.SetActive(true);
    }
    public void GoToCreditsMenu()
    {
        _CreditsMenu.SetActive(true);
    }
    public void GoToMainMenu()
    {
        _SettingMenu.SetActive(false);
        _CreditsMenu.SetActive(false);
        _RulesMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
