using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float speed = 0f;
    [SerializeField] float fallLimitY = -10f;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    [SerializeField] bool jump;
    [SerializeField] Animator anim;
    [SerializeField] UIController VARUIController;
    public float distanceTraveled;
    public int collectedCoins;
    
    public bool airJump;
    [SerializeField] GameObject shield;   // child sphere on the player, disabled by default
    public bool shieldIsActive;

    public void ActivateShield()
    {
        shieldIsActive = true;
        if (shield != null) shield.SetActive(true);
    }

    float lastYPos; 

    void Start()
    {
        lastYPos = transform.position.y;
    }

    void Update()
    {
        if (CheckForFall()) return;

        distanceTraveled += Time.deltaTime * 5f;

        CheckForInput();
        CheckForFalling();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EndGameZone"))
        {
            Debug.Log(" you Fell off the map !!!!");
            VARUIController.ShowGameOverScreen();
        }
        else if (collision.gameObject.CompareTag("Obsticle"))
        {
            if (shieldIsActive)
            {
                shieldIsActive = false;
                if (shield != null) shield.SetActive(false);
                Destroy(collision.gameObject);
            }
            else
            {
                VARUIController.ShowGameOverScreen();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Obsticle"))
        {
            Debug.Log("Shield Hit!!!!!");
            Destroy(collision.gameObject);
        }
        
    }

    void FixedUpdate()
    {
        CheckForGround();
        ApplyJump();
    }

    bool CheckForFall()
    {
        if (transform.position.y < fallLimitY)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return true;
        }
        return false;
    }

    void CheckForInput()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            anim.SetTrigger("jump");
        }

        if(isGrounded==true || airJump==true )
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
               jump = true ;
               anim.SetTrigger("jump");
                if (airJump==true && isGrounded==false)
                {
                    airJump=false;
                }
            }
        }
    }

    void ApplyJump()
    {
        if (jump)
        {
            jump = false;
            playerRb.AddForce(new Vector2(speed, jumpForce), ForceMode2D.Impulse);
        }
    }

    void CheckForGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if (hit.collider != null && hit.distance < 0.1f)
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
            Debug.DrawRay(raycastOrigin.position, Vector2.down * hit.distance, Color.green);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
    }

    void CheckForFalling()
    {
        anim.SetBool("falling", transform.position.y < lastYPos);
        lastYPos = transform.position.y;
    }
}