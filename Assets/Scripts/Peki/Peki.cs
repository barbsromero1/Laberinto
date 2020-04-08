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
    public AudioSource sounds;
    public AudioSource playmusic;
    public AudioClip damage_sound;
    public AudioClip playing_music;
    public AudioClip dead_music;
    public int maxHealth = 4;
    public int curentHealth;
    public HealthBar healthBar;

    [SerializeField]
    private GameObject gameoverUI;

    private Rigidbody2D rigi;
    Animator anim;
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
            sounds.clip = damage_sound;
            //StartCoroutine(DamagePeki());
            sounds.Play();
            curentHealth -= 1;
            healthBar.setHealth(curentHealth);
            if (curentHealth == 0)
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
        if (collision.gameObject.CompareTag("ArrowE"))
        {
            sounds.clip = damage_sound;
            sounds.Play();
            curentHealth -= 1;
            healthBar.setHealth(curentHealth);
            if (curentHealth == 0)
            {
                isDead = true;
                Destroy(this.gameObject);
                gameoverUI.SetActive(true);
                Destroy(collision.gameObject);
                //music.Stop();
                playmusic.Stop();
                playmusic.clip = dead_music;
                playmusic.Play();
            }
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
