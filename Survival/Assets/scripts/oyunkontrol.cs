using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyunkontrol : MonoBehaviour
{
    public GameObject zombi;
    private float zamanSayaci;
    private float olusumSureci = 10f;
    public Text puanText;
    private int puan;
    void Start()
    {
        zamanSayaci = olusumSureci;
    }

    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci < 0)
        {
            Vector3 pos = new Vector3(Random.Range(391f, 690f), 22.002f, Random.Range(350f, 668f));
            Instantiate(zombi, pos, Quaternion.identity);
            zamanSayaci = olusumSureci;
        }
    }
    public void PuanArtir(int p)
    {
        puan += p;
        puanText.text = "" + puan;
    }

    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan", puan); 
        SceneManager.LoadScene("oyunBitti");
    }
}
