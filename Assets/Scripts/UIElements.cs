using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _menuWindow.SetActive(false);
        _menuButton.onClick.AddListener(MenuWindow);
        _exitButton.onClick.AddListener(CloseApp);
    }

    private void CloseApp()
    {
        Application.Quit();
    }

    private void MenuWindow()
    {
        if (_menuWindow.activeSelf == true)
        {
            _menuWindow.SetActive(false);
        }
        else
        {
            _menuWindow.SetActive(true);
        }
    }
}
