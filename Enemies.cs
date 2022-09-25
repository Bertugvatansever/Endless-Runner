using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Cameracontroller cammoveSpeeddd;
    private Lifebar lifeBar;
    private Scoremanager enemydeathScore;
    private Animator enemyAnimator;
    public bool death;
    public bool enemyDirection;
    public CircleCollider2D swordCollider;
    public BoxCollider2D playerCollider;
    public Playercontrol playerControl;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        cammoveSpeeddd = FindObjectOfType<Cameracontroller>();
        enemyAnimator = GetComponent<Animator>();
        lifeBar = FindObjectOfType<Lifebar>();
        enemydeathScore = FindObjectOfType<Scoremanager>();
        playerControl = FindObjectOfType<Playercontrol>();
        swordCollider = playerControl.GetComponent<CircleCollider2D>();
        playerCollider = playerControl.GetComponent<BoxCollider2D>();
        enemySpeed = -1.5f;
        enemyDirection = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySpeed==-1.5f && enemyDirection== true)
        {
            Direction();
        }
        else if(enemySpeed == 1.5f && enemyDirection == false)
        {
            Direction();
        }
        if(playerControl.thecountDown.countDown==0)
        {
          transform.Translate(new Vector3(enemySpeed, 0, 0) * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider==swordCollider)
        {
            death = true;
            if(playerControl.doublepointActive == true)
            {
                enemydeathScore.scoreCount += 100f;
            }
            else
            {
                enemydeathScore.scoreCount += 50f;
            }
            enemyAnimator.SetBool("Death", death);
            Invoke("Deathfalse",0.5f);
        }
        if (collision.collider==playerCollider)
        {
            playerControl.deathSound.Play();
            if(playerControl.safeMode == false)
            {
                lifeBar.health -= 50;
            }
            else if(playerControl.safeMode == true)
            {
                if(playerControl.doublepointActive ==true)
                {
                    playerControl.thescoremanager.scoreCount += 100f;
                }
                else
                {
                    playerControl.thescoremanager.scoreCount += 50f;
                }
            }
            if(lifeBar.health <=0)
            {
                playerControl.thedeathmenu.SetActive(true);
                Time.timeScale = 0f;
                playerControl.thescoremanager.skorislemi();
                playerControl.thescoremanager.scoreIncreasing = false;
                if (PlayerPrefs.HasKey("Highscore : ") == true)
                {
                    playerControl.thescoremanager.pasthighscore = PlayerPrefs.GetFloat("Highscore : ");
                }
                if (PlayerPrefs.HasKey("Second Highscore : ") == true)
                {
                    playerControl.thescoremanager.pastsecondScore = PlayerPrefs.GetFloat("Second Highscore : ");
                }
                if (PlayerPrefs.HasKey("Third Highscore : ") == true)
                {
                    playerControl.thescoremanager.pastthirdScore = PlayerPrefs.GetFloat("Third Highscore : ");
                }
                // contact2 skor sayacýný kontrol eder burda kapattým.
                playerControl.contact2 = false;
                // ölünce hareket olmamasý için catcher false
                playerControl.catcher = false;
                playerControl.moveSpeed = playerControl.beginnermoveSpeed;
                playerControl.speedmilestoneCount = playerControl.beginnerspeedmilestoneCount;
                playerControl.speedýncreaseMilestone = playerControl.beginnerspeedýncreaseMilestone;
            }
            else
            {
                death = true;
                enemyAnimator.SetBool("Death", death);
                Invoke("Deathfalse", 0.5f);
            }
            
        }
    }
    private void Deathfalse()
    {
 
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Back")
        {
            enemySpeed *= -1;
        }
    }
    private void Direction()
    {
        enemyDirection = !enemyDirection;
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }









}
