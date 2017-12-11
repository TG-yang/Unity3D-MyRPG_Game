using UnityEngine;
using System.Collections;

public class CharacterCreation : MonoBehaviour
{

    public GameObject[] characterPrefabs;

    public UIInput nameInput;
    private GameObject[] characterGameObjects;

    private int selecteIndex = 0;
    private int length; //可供选择的角色

    void Start()
    {
        length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];

        for (int i = 0; i < length; i++)
        {
            characterGameObjects[i] =
                GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;

        }
    }

    void UpdateCharacterShow()
    {
        characterGameObjects[selecteIndex].SetActive(true);
        for (int i = 0; i < length; i++)
        {
            if (i!=selecteIndex)
            {
                characterGameObjects[i].SetActive(false);
            }
        }
    }

    public void OnNextButtonClick() //点击下一个按钮
    {
        selecteIndex++;
        selecteIndex %= length;
        UpdateCharacterShow();
    }

    public void OnPreButtonClick()
    {
        selecteIndex--;
        if (selecteIndex==-1)
        {
            selecteIndex = length - 1;
        }
        UpdateCharacterShow();
    }

    public void OnOKButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selecteIndex);
        PlayerPrefs.SetString("name", nameInput.value);
        //加载下个场景
    }
}
