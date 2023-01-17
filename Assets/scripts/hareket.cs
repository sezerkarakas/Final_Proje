using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{

    public float speed = 0.25F;
    public float rotspeed = 80;
    float gravity = 8;
    float rot = 0;
    bool attack;

    Vector3 moveDir = Vector3.zero;

    CharacterController kontrol;
    Animator anim;

    void Start()
    {
        kontrol = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }


    public void Update()
    {

        if (kontrol.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))//alttaki fixedupdate içindeki scipti kullanýrken animasyonlar patladýðý için böyle bir script kullandým ama geri gitme tuþunu atayýnca script patladýðý için sadece w,a,d tuþlarýný kullanabiliyorsunuz ama istediðiniz yere gitmekte serbestsiniz
            {
                moveDir = new Vector3(0, 0, 1);//Oyunda "W" ile yürünüyor, "A" ve "D" tuþlarý sadece yön deðiþtirmeye yarýyor."S" tuþunu geri gitmesi için ayarlamaya çalýþtým fakat animasyonla iyi gözükmediði için kaldýrdým. 
                moveDir *= speed;//Mantarlarý üstlerine giderek toplayabilirsiniz.
                anim.SetInteger("hareket",1);//Oyunda 12 tane mantar etrafa daðýtýlmýþtýr. Onlarý bulursanýz kazanýrsýnýz
                moveDir = transform.TransformDirection(moveDir);

            }
            
            else
            {
                moveDir = new Vector3(0, 0, 0);
                anim.SetInteger("hareket", 0);

            }
        }
        if (Input.GetKey(KeyCode.Space))
        {

            attack = true;
            anim.SetBool("Saldiri", attack);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            attack = false;
            anim.SetBool("Saldiri", attack);
        }

        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        kontrol.Move(moveDir * Time.deltaTime);
    }

    /*  // Update is called once per frame
      void FixedUpdate()
      {
          float moveHorizontal = Input.GetAxis("Horizontal");
          float moveVertical = Input.GetAxis("Vertical");
          Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
          GetComponent<Rigidbody>().AddForce(movement*speed*Time.deltaTime);
          //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
      }*/

    void OnTriggerEnter(Collider nesne)
    {
        /*
        if (attack == true)
        {
            if (nesne.gameObject.tag == "Mantarlar(Puan)") //Mantarlarý toplamanýz için üstlerine gidip "Space" tuþu ile vurmanýz gerekiyordu ama tam olarak sað kolu mantarýn içine sokmanýz gerekitiði için o kýsmý tam olarak ayarlayamadýðým için sadece vuruþ animasyonu var. 
            {
                nesne.gameObject.SetActive(false);
            }

        }*/

        if (nesne.gameObject.tag == "Mantarlar(Puan)")
        {
            nesne.gameObject.SetActive(false);


        }
    }


}
