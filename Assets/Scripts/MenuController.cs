using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static bool isMenuOpen;
    public GameObject menu;
    public static bool isButtonWasClicked;
    private void Awake()
    {
        menu.SetActive(false);
    }

    public static void CloseMenuAfterClickButton()
    {
        isButtonWasClicked = true;
    }
    
    void Update()
    {
        if (isButtonWasClicked)
        {
            menu.SetActive(false);
            isMenuOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            isButtonWasClicked = false;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                isMenuOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                menu.SetActive(true);
                isMenuOpen = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
