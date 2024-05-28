using UnityEngine;


public class ButtonController : MonoBehaviour
{
    public void MyOnClick()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        int childCount = mainCamera.transform.childCount;

          
        for (int i = 0; i < childCount; i++)
        {
            Transform childObject = mainCamera.transform.GetChild(i);
            if (childObject.name == gameObject.name)
            {
                childObject.gameObject.SetActive(true);
            }
            else
            {
                childObject.gameObject.SetActive(false);
            }
        }
        MenuController.CloseMenuAfterClickButton();
    } 
}
