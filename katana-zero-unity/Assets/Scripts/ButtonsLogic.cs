using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsLogic : MonoBehaviour
{
    public Button start;
    public Button exit;
    public Button settings;


    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(() => {
            SceneManager.LoadScene("BaseScene");
        });        
        exit.onClick.AddListener(() => {
            Application.Quit();
        });        
        settings.onClick.AddListener(() => {
            SceneManager.LoadScene("Settings");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
