using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyunBitti : MonoBehaviour
{
    public Text puan;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        puan.text = "Puan�n�z:" + PlayerPrefs.GetInt("puan");
    }

    public void YenidenOyna()
    {
        SceneManager.LoadScene("oyun");
    }
}
