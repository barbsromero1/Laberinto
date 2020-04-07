using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class Peki : MonoBehaviour
{
    // Start is called before the first frame update
    public float upForce;
    public float speed = 0.5f;
    private bool isDead = false;
<<<<<<< HEAD
    public AudioSource sounds;
    public AudioClip damage_sound;
    public int maxHealth = 4;
    public int curentHealth;
    public HealthBar healthBar;
=======

    private LivesManager liveSystem;
>>>>>>> 48724d589bd6b27d304d108625d597858e2c6e87

    private Rigidbody2D rigi;
    Animator anim;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
<<<<<<< HEAD
        curentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
=======
        liveSystem = FindObjectOfType<LivesManager>();
>>>>>>> 48724d589bd6b27d304d108625d597858e2c6e87
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rigi.velocity = Vector2.zero;
                rigi.AddForce(new Vector2(0, upForce));
                anim.Play("Peki_Anima");
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.localScale = new Vector3(1f,1f,1f);
                anim.Play("Peki_Anima");
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                transform.localScale = new Vector3(-1f,1f,1f);
                anim.Play("Peki_Anima");
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isDead = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
<<<<<<< HEAD
            sounds.clip = damage_sound;
            //StartCoroutine(DamagePeki());
            sounds.Play();
            if (curentHealth == 1)
            {
                curentHealth -= 1;
                healthBar.setHealth(curentHealth);

                isDead = true;
                Destroy(this.gameObject);
            }
            else
            {
                curentHealth -= 1;
                healthBar.setHealth(curentHealth);
            }
=======
            liveSystem.TakeLife();
            isDead = true;
>>>>>>> 48724d589bd6b27d304d108625d597858e2c6e87
        }
    }

    //IEnumerator DamagePeki()
    //{
    //    sounds.Play();
    //    isDead = true;
    //    yield return new WaitForSeconds(3);
    //    Destroy(this.gameObject);
    //}

    //IEnumerator KillTheMonnkey()
    //{
    //    //para que si tu personaje no se ve en pantalla es muerte absoluta 
    //    yield return new WaitForSeconds(2f);
    //    // WaitUntil(); funcion que se cumpla para que se ejecute 
    //    isDead = true;
    //    yield return new WaitForSeconds(1f);
    //    //maneras de llamar a una scene 
    //    //SceneManager.LoadScene(1);
    //    SceneManager.LoadScene("GameOver");
    //}

}
