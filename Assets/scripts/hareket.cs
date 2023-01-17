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
            if (Input.GetKey(KeyCode.W))//alttaki fixedupdate i�indeki scipti kullan�rken animasyonlar patlad��� i�in b�yle bir script kulland�m ama geri gitme tu�unu atay�nca script patlad��� i�in sadece w,a,d tu�lar�n� kullanabiliyorsunuz ama istedi�iniz yere gitmekte serbestsiniz
            {
                moveDir = new Vector3(0, 0, 1);//Oyunda "W" ile y�r�n�yor, "A" ve "D" tu�lar� sadece y�n de�i�tirmeye yar�yor."S" tu�unu geri gitmesi i�in ayarlamaya �al��t�m fakat animasyonla iyi g�z�kmedi�i i�in kald�rd�m. 
                moveDir *= speed;//Mantarlar� �stlerine giderek toplayabilirsiniz.
                anim.SetInteger("hareket",1);//Oyunda 12 tane mantar etrafa da��t�lm��t�r. Onlar� bulursan�z kazan�rs�n�z
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
            if (nesne.gameObject.tag == "Mantarlar(Puan)") //Mantarlar� toplaman�z i�in �stlerine gidip "Space" tu�u ile vurman�z gerekiyordu ama tam olarak sa� kolu mantar�n i�ine sokman�z gerekiti�i i�in o k�sm� tam olarak ayarlayamad���m i�in sadece vuru� animasyonu var. 
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
