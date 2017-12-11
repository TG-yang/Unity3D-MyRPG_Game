using UnityEngine;
using System.Collections;

public class PressAnyKey : MonoBehaviour
{

    private bool isAnyKeyDown = false;
    private GameObject buttonContainer;

    void Start()
    {
        buttonContainer = this.transform.parent.Find("ButtonContainer").gameObject;
    }

    void Update()
    {
        if (isAnyKeyDown ==false)
        {
            if (Input.anyKey)
            {
                ShowButton();
            }
        }
    }

    void ShowButton()
    {
        buttonContainer.SetActive(true);
        this.gameObject.SetActive(false);

        isAnyKeyDown = true;

    }
}
