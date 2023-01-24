using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyuncukontrol : MonoBehaviour
{
    public AudioClip atisSesi, dusmesesi, canAlmasesi, yaralanmaSesi;
    public Transform mermiPos;
    public GameObject mermi;
    public GameObject patlama;
    public UnityEngine.UI.Image canImaji;
    private float canDegeri = 100f;
    public oyunkontrol oKontrol;
    private AudioSource aSource;
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            aSource.PlayOneShot(atisSesi, 1f);
            GameObject go = Instantiate(mermi, mermiPos.position, mermiPos.rotation) as GameObject;
            GameObject goPatlama = Instantiate(patlama, mermiPos.position, mermiPos.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = mermiPos.transform.forward * 10f;
            Destroy(go.gameObject, 2f);
            Destroy(goPatlama.gameObject, 2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("zombi"))
        {
            aSource.PlayOneShot(yaralanmaSesi, 1f);
            canDegeri -= 10f;
            float x = canDegeri / 100f;
            canImaji.fillAmount = x;
            canImaji.color = Color.Lerp(Color.red, Color.green, x);

            if(canDegeri <= 0)
            {
                aSource.PlayOneShot(dusmesesi, 1f);
                oKontrol.OyunBitti();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("kalp"))
        {
            aSource.PlayOneShot(canAlmasesi, 1f);
            if(canDegeri<100f)
            canDegeri += 10f;
            float x = canDegeri / 100f;
            canImaji.fillAmount = x;
            canImaji.color = Color.Lerp(Color.red, Color.green, x);
        }
    }
}
