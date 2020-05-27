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
    public bool isIdle = false;
    public AudioSource sounds;
    public AudioSource playmusic;
    public AudioClip damage_sound;
    public AudioClip playing_music;
    public AudioClip dead_music;
    public int maxHealth = 4;
    public int curentHealth;
    public HealthBar healthBar;
    const float timeBetweenDamage = 0.2f;
    public float timeSinceLastDamage = 0.2f;
    //para contar las vidas 
    //public int CoinsCont = 0; 

    [SerializeField]
    private GameObject gameoverUI;

    private Rigidbody2D rigi;
    public Animator anim;
    void Start()
    {
        playmusic.clip = playing_music;
        playmusic.Play();
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curentHealth = maxHealth;
        healthBar.setHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false && !(PauseMenu.GamePause))
        {
            
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rigi.velocity = Vector2.zero;
                rigi.AddForce(new Vector2(0, upForce));
                isIdle = false;
                anim.SetBool("isIdle", false);
            }
            if (!isIdle)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }

                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
            
        }
        timeSinceLastDamage -= Time.deltaTime;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isIdle = true;
            anim.SetBool("isIdle", true);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(2);
        }
        if (collision.gameObject.CompareTag("ArrowE"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
            //ResetDamage();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            ScoreSystem.scoreValue += 1;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Puerta"))
        {
            SceneManager.LoadScene("Final");
        }
        if (ScoreSystem.scoreValue == 5)
        {
            AddLive(1);
            ScoreSystem.scoreValue = 0; 
        }
    } 

    void TakeDamage (int damage)
    {
        if (timeSinceLastDamage < 0)
        {
            timeSinceLastDamage = timeBetweenDamage;
            sounds.clip = damage_sound;
            sounds.Play();
            curentHealth -= damage;
            healthBar.setHealth(curentHealth);
            if (curentHealth <= 0)
            {
                isDead = true;
                Destroy(this.gameObject);
                gameoverUI.SetActive(true);
                //music.Stop();
                playmusic.Stop();
                playmusic.clip = dead_music;
                playmusic.Play();
            }
        }
 
    }

    void AddLive(int damage)
    {
        if (timeSinceLastDamage < 0)
        {
            timeSinceLastDamage = timeBetweenDamage;
            sounds.clip = damage_sound;
            sounds.Play();
            curentHealth += damage;
            healthBar.setHealth(curentHealth);
            if (curentHealth <= 0)
            {
                isDead = true;
                Destroy(this.gameObject);
                gameoverUI.SetActive(true);
                //music.Stop();
                playmusic.Stop();
                playmusic.clip = dead_music;
                playmusic.Play();
            }
        }

    }

    IEnumerator ConfirmIdle()
    {
        yield return new WaitForSeconds(1);
    }

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
