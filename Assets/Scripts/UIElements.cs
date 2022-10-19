using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menuWindow;




    private void Start()
    {
        _menuWindow.SetActive(false);
        _menuButton.onClick.AddListener(MenuWindow);


    }

    private void MenuWindow()
    {
        if (_menuWindow.active == true)
        {
            _menuWindow.SetActive(false);
        }
        else
        {
            _menuWindow.SetActive(true);
        }
    }
}
