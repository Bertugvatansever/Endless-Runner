using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontrol : MonoBehaviour
{
    public Text goldCountText;
    public Text attackText;
    public Text pauseText;
    public Text movementText;
    public Text heavyjumpText;
    public Text jumpText;
    public Sayac thecountDown;
    public GameObject thedeathmenu;
    public GameObject Shield;
    public AudioSource warriordoublejumpSound;
    public AudioSource warriorjumpSound;
    public AudioSource warriorattackSound;
    public AudioSource attackSound;
    public AudioSource deathSound;
    public AudioSource jumpSound;
    public AudioSource powerupSound;
    public Cameracontroller cameraLocation;
    public Pausemenu pauseControl;
    public Scoremanager thescoremanager;
    private Rigidbody2D playerrigid;
    private Collider2D playerCollider;
    private CircleCollider2D swordColliderrr;
    private Animator playerAnimator;
    public Animator shieldAnimator;
    public Gamemanager thegameManager;
    public Mainmenu menu;
    public LayerMask whichGround;
    public Transform groundCheck;
    public float groundcheckRadius;
    public float moveSpeed;
    public float beginnermoveSpeed;
    public float jumpForce;
    public float jumpTime;
    public float speed;
    private float jumptimeCounter;
    private string warriordoubleJump;
    public float goldCount;
    public bool contact;
    public bool contact2;
    public bool catcher;
    public bool attack;
    public bool safeMode;
    public bool doublepointActive;
    public float powerupactiveTime;
    public float powerupactiveTime2;
    public bool direction;
    public int jumpCount;
    public float speedMultiplier;
    public float speed�ncreaseMilestone;
    public float beginnerspeed�ncreaseMilestone;
    public float speedmilestoneCount;
    public float beginnerspeedmilestoneCount;
    // Start is called before the first frame update
    void Start()
    {
        pauseControl.gameObject.SetActive(true);
        pauseControl = FindObjectOfType<Pausemenu>();
        pauseControl.gameObject.SetActive(false);
        //thescoremanager = FindObjectOfType<Scoremanager>();
        playerrigid = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
        thegameManager = FindObjectOfType<Gamemanager>();
        thecountDown = FindObjectOfType<Sayac>();
        cameraLocation = FindObjectOfType<Cameracontroller>();
        jumptimeCounter = jumpTime;
        beginnermoveSpeed = moveSpeed;
        beginnerspeed�ncreaseMilestone = speed�ncreaseMilestone;
        beginnerspeedmilestoneCount = speedmilestoneCount;
        goldCount = PlayerPrefs.GetFloat("Goldcount");
        goldCountText.text = ""+goldCount;
        swordColliderrr = GetComponent<CircleCollider2D>();
        swordColliderrr.enabled = false;
        warriordoubleJump = PlayerPrefs.GetString("playerSelect");
    }
    void Update()
    {
        // zemine de�dikten sonra z�plama kontrol�
        contact = Physics2D.OverlapCircle(groundCheck.position, groundcheckRadius, whichGround);
        speed = playerrigid.velocity.x;
        // zamanla h�z art���
        if (cameraLocation.transform.position.x > speedmilestoneCount)
        {
            //speedmilestoneCount : S�n�r mesafesi bu mesafe ge�ilince h�z artar
            //speed�ncraseMilestone : Mesafeyi her seferinde daha da uza�a ta��r
            // SpeedMultiplier : H�z �arpan�
            speedmilestoneCount += speed�ncreaseMilestone;
            speed�ncreaseMilestone = speed�ncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }
        // Catcher ba�lang��ta hareket etmeyi engeller
        if (thecountDown.countDown == 0 && catcher == true)
        {
            if(contact == true)
            {
                if (warriordoubleJump == "false")
                {
                    jumpCount = 2;
                }
            }
            // z�plama
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (contact == true)
                {
                    
                    // tekrar �arj
                    jumptimeCounter = jumpTime;
                    playerrigid.velocity = new Vector2(playerrigid.velocity.x, jumpForce);
                    if(warriordoubleJump=="true")
                    {
                        warriorjumpSound.Play();
                    }
                    else
                    {
                        jumpSound.Play();
                    }
                   
                }
                if((jumpCount>0) && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
                {
                    jumpSound.Play();
                    playerrigid.velocity = new Vector2(playerrigid.velocity.x, jumpForce+2f);
                    
                }
               
            }
            // sa�a do�ru gitme
            if (Input.GetKey(KeyCode.D))
            {
                playerrigid.velocity = new Vector2(moveSpeed, playerrigid.velocity.y);
            }
            // sola do�ru gitme
            if (Input.GetKey(KeyCode.A))
            {
                playerrigid.velocity = new Vector2(-moveSpeed * 2, playerrigid.velocity.y);
            }
            // space bas�l� tutunca daha fazla z�plama
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                if (jumptimeCounter > 0)
                {
                    playerrigid.velocity = new Vector2(playerrigid.velocity.x, jumpForce);
                    jumptimeCounter -= Time.deltaTime;
                }


            }
            // spaceden elini �ekince fazla z�plamay� s�f�rlama
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                jumptimeCounter = 0;
                jumpCount -= 1;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseControl.PauseGame();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                swordColliderrr.enabled = true;
                attack = true;
                if(warriordoubleJump=="true")
                {
                    warriorattackSound.Play();
                }
                else
                {
                    attackSound.Play();
                }
                Invoke("Attackfalse", 0.4f);
            }
            // karakter sa�a bak�yorsa ve sola gidilmek isteniyorsa kafay� sola d�nd�r
            if (direction == true && speed < 0)
            {
                Direction();
                
            }
            // karakter sola bak�yorsa ve sa�a gidilmek isteniyorsa kafay� sa�a d�nd�r
            else if (direction == false && speed > 0)
            {
                Direction();
            }
            
        }
        // Animasyon
        playerAnimator.SetFloat("Speed", playerrigid.velocity.x);
        playerAnimator.SetBool("contact", contact);
        playerAnimator.SetBool("Attack", attack);
        playerAnimator.SetFloat("Countdown", thecountDown.countDown);
        powerupactiveTime -= Time.deltaTime;
        shieldAnimator.SetFloat("Activetime",powerupactiveTime);
        powerupactiveTime2 -= Time.deltaTime;
    }
 
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Killbox")
        {
            Time.timeScale = 0f;
            deathSound.Play();
            thedeathmenu.SetActive(true);
            thescoremanager.skorislemi();
            thescoremanager.scoreIncreasing = false;
            if (PlayerPrefs.HasKey("Highscore : ") == true)
            {
                thescoremanager.pasthighscore = PlayerPrefs.GetFloat("Highscore : ");
            }
            if (PlayerPrefs.HasKey("Second Highscore : ") == true)
            {
                thescoremanager.pastsecondScore = PlayerPrefs.GetFloat("Second Highscore : ");
            }
            if (PlayerPrefs.HasKey("Third Highscore : ") == true)
            {
                thescoremanager.pastthirdScore = PlayerPrefs.GetFloat("Third Highscore : ");
            }
            // contact2 skor sayac�n� kontrol eder burda kapatt�m.
            contact2 = false;
            // �l�nce hareket olmamas� i�in catcher false
            catcher = false;
            moveSpeed = beginnermoveSpeed;
            speedmilestoneCount = beginnerspeedmilestoneCount;
            speed�ncreaseMilestone = beginnerspeed�ncreaseMilestone;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "startScore")
            contact2 = true;
            movementText.gameObject.SetActive(false);
            heavyjumpText.gameObject.SetActive(false);
            jumpText.gameObject.SetActive(false);
            pauseText.gameObject.SetActive(false);
            attackText.gameObject.SetActive(false);
        if(trig.gameObject.tag=="coin")
        {
            goldCount += 1;
            PlayerPrefs.SetFloat("Goldcount", goldCount);
            goldCountText.text = "" + goldCount;
        }
        if(trig.gameObject.name=="Shield(Clone)")
        {
            powerupSound.Play();
            Shield.gameObject.SetActive(true);
            powerupactiveTime = 20f;
            safeMode = true;
            shieldAnimator.SetBool("safemode",safeMode);
            Invoke("DontSafe",20f);
            
        }
        if(trig.gameObject.name=="DoublePoint(Clone)")
        {
            powerupSound.Play();
            if(contact2 ==true)
            {
                thescoremanager.doublee = true;
                doublepointActive = true;
                powerupactiveTime2 = 20f;
                Invoke("DontDoublePoint",20f);
            }
            
            
        }
    }
    private void Attackfalse()
    {
        attack = false;
        swordColliderrr.enabled = false;
    }
    private void DontSafe()
    {
        safeMode = false;
        shieldAnimator.SetBool("safemode", safeMode);
        Shield.gameObject.SetActive(false);
    }
    private void DontDoublePoint()
    {
        doublepointActive = false;
    }
   private void Direction()
    {
        direction = !direction;
        playerAnimator.SetBool("Direction", direction);
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
