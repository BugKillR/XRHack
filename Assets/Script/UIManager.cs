using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty showBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showBtn.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
        }

        if (menu.activeSelf == false)
        {
            Time.timeScale = 1;
        }
        else if(menu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
    }
}
