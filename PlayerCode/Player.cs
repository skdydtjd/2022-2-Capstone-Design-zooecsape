using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //이동속도, 점프력 조절
    public float walkForce = 8f;
    public float jumpForce = 50f;

    public int jumpCount = 0;
    public bool isGround = false;
    public bool isSliding = false;

    public float hp = 5.0f;

    Rigidbody2D p_rigid2D;
    SpriteRenderer spriteRenderer;
    Animator anim;

    AudioSource sound;
    AudioSource Hurt;

    public AudioClip jump;
    public AudioClip sliding;
    public AudioClip drop;
    public AudioClip hurt;
    public AudioClip Score;

    void Start()
    {
        p_rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        sound = GetComponent<AudioSource>();
        Hurt = GetComponent<AudioSource>();

        hp = 5.0f;
    }

    void Update()
    {
        // 캐릭터 이동
        float inputX = Input.GetAxis("Horizontal");
        float fallSpeed = p_rigid2D.velocity.y;
        float speed = walkForce * inputX;

        Vector2 p_velocity = new Vector2(speed, 0);
        p_velocity.y = fallSpeed;
        p_rigid2D.velocity = p_velocity;

        //좌우 플립, 걷는 애니메이션
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isWalk", true);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isWalk", true);
            spriteRenderer.flipX = false;
        }

        // 멈춤 애니메이션
        if (p_velocity.x == 0)
            anim.SetBool("isWalk", false);

        //점프
        if (Input.GetKeyDown(KeyCode.Z) && jumpCount < 2)
        {
            jumpCount++;
            p_rigid2D.velocity = new Vector2(0, 0);
            anim.SetBool("isJump", true);
            p_rigid2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            sound.clip = jump;
            sound.Play();
        }
        //아래로 점프
        if (Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(DownJump());
        }

        //슬라이딩(좌)
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.X) && isSliding == true && isGround == true)
        {
            sound.clip = sliding;
            sound.Play();
            StartCoroutine(S_Invincible()); // 무적
            StartCoroutine(Sliding());    // 슬라이딩
            StartCoroutine(IsSliding());  // 슬라이딩 쿨타임
        }

        //슬라이딩(우)
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.X) && isSliding == true && isGround == true)
        {
            sound.clip = sliding;
            sound.Play();
            StartCoroutine(S_Invincible()); // 무적
            StartCoroutine(Sliding());    // 슬라이딩
            StartCoroutine(IsSliding());  // 슬라이딩 쿨타임
        }

        //게임오버(체력)(낙하)
        if (GameManager.instance != null && hp <= 0)
        {
            GameManager.instance.gameOver();
        }

        if (GameManager.instance != null)
        {
            if (transform.position.y < -45f)
            {
                sound.clip = drop;
                sound.Play();

                if (transform.position.y < -60f)
                {
                    GameManager.instance.fishcount = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //슬라이딩 활성화
        if (collision.contacts[0].normal.y > 0.7f)
        {
            anim.SetBool("isJump", false);
            isGround = true;
            isSliding = true;
            jumpCount = 0;
        }

        //피격 처리
        if (collision.gameObject.tag == "enemy")
        {
            Hurt.clip = hurt;
            Hurt.Play();
            StartCoroutine(H_Invincible());
            Debug.Log("맞음");
        }

        if (collision.gameObject.tag == "fish")
        {
            sound.clip = Score;
            sound.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //점프 불가
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {
            isGround = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            sound.clip = Score;
            sound.Play();
            Destroy(collision.gameObject);
            hp = hp + 0.5f;

            if (hp >= 10f)
            {
                hp = 10f;
            }
        }
    }

    public float getHP()
    {
        return hp;
    }

    public void freeze()
    {
        StartCoroutine(FreezePosition());
    }

    //슬라이딩 쿨타임 2초
    IEnumerator IsSliding()
    {
        isSliding = false;
        yield return new WaitForSeconds(2.0f);
        isSliding = true;
    }

    //슬라이딩 중 무적
    IEnumerator S_Invincible()
    {
        gameObject.layer = 7;
        yield return new WaitForSeconds(1.0f);
        gameObject.layer = 3;
    }

    //다운 점프
    IEnumerator DownJump()
    {
        gameObject.layer = 12;
        yield return new WaitForSeconds(0.2f);
        gameObject.layer = 3;
    }

    //슬라이딩
    IEnumerator Sliding()
    {
        anim.SetBool("isSlide", true);
        walkForce = walkForce * 3;
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isSlide", false);
        walkForce = walkForce / 3;
    }

    //피격 후 무적 + 투명해짐
    IEnumerator H_Invincible()
    {
        hp = hp - 0.5f;
        gameObject.layer = 7;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        p_rigid2D.AddForce(new Vector2(-1f, 1f) * 7, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3.0f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        gameObject.layer = 3;
    }

    IEnumerator FreezePosition()
    {
        this.p_rigid2D.constraints = RigidbodyConstraints2D.FreezePosition;
        jumpCount = 3;
        yield return new WaitForSeconds(1.0f);
        jumpCount = 0;
        this.p_rigid2D.constraints = RigidbodyConstraints2D.None;
        this.p_rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
