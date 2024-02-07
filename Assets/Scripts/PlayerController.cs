using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumForce = 10f;//Fuerza del salto
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;  
    public AudioClip crashSound;
    public GameObject btnPlay;
    private AudioSource audioSource;
    private float delay = 2.0f;
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; //Se modifica la Gravedad
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");//Animacion de salto
            dirtParticle.Stop(); //Para detener la particula de tierra
            audioSource.PlayOneShot(jumpSound, 1.0f);// reproduce el sonido al saltar
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play(); //Para detener la particula de tierra

        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);//Animacion de muerte
            playerAnimator.SetInteger("DeathType_int", 1);//Seleccionamos el tipo de animacion de muerte en este caso el tipo #2
            explosionParticle.Play();//Reproduccir particula cuando el player se tropiesa con el obstaculo
            dirtParticle.Stop(); //Para detener la particula de tierra
            audioSource.PlayOneShot(crashSound, 1.0f);// reproduce el sonido chocar con el obstaculo
            Invoke("ActivarBotonPlay", delay); ;
        }
    }

    private void ActivarBotonPlay()
    {
        btnPlay.SetActive(true);
    }
}
