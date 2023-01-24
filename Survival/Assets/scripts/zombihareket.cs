using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombihareket : MonoBehaviour
{
    public GameObject kalp;
    private GameObject oyuncu;
    private int zombiCan = 3;
    private int zombidenGelenPuan = 10;
    private float mesafe;
    private oyunkontrol oKontrol;
    private AudioSource aSource;
    private bool zombiOluyor = false;
   
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("Oyuncu");
        oKontrol=GameObject.Find("scripts").GetComponent<oyunkontrol>();
    }

    
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position; //destination gideceði nokta
        mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        if (mesafe < 10f)
        {
            if(!aSource.isPlaying)
            aSource.Play();
            if(!zombiOluyor)
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
        else
        {
            if (aSource.isPlaying)
                aSource.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("mermi"))
        {
            Debug.Log("Çarpýþma gerçekleþti");
            zombiCan--;
            if (zombiCan == 0)
            {
                zombiOluyor = true;
                oKontrol.PuanArtir(zombidenGelenPuan);
                Instantiate(kalp, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }
    }
}
