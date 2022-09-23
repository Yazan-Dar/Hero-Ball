using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ValueChangedEvent : UnityEvent<int> { };

public class Gamemanager : MonoBehaviour
{
    public ValueChangedEvent scoreChanged = new ValueChangedEvent();
    public ValueChangedEvent lifeChanged = new ValueChangedEvent();

    private static int lifeNumber = 3;
    private static int scoreNumber = 0;

    public int LifeNumber { get { return lifeNumber; } }
    public int ScoreNumber { get { return scoreNumber; } }

    private int coinsLeft;
    public int CoinsLeft { get { return coinsLeft; } }

    private float timer = 15.0f;

    public float TimerNumber { get { return timer; } }
    private float timing = 0.000001f;

    public GameObject playAgainBtn;
    public RawImage pause;
    public Texture playIcon;
    public Texture pauseIcon;

    private Text completeLevel;
    private Text gameover;
    private Text textScoreObj;
    private Text totalSNum;
    private Rigidbody rb;
    private Vector3 originalPos;
    private GameObject player;
    private float Sphere = 0.1f;
    private int SphersM = 5;
    private float distance;
    private Vector3 sphereParts;
    private float explosionForce = 150f;
    private float explosionRadius = 4f;
    private float explosionUpward = 0.4f;
    private bool paused = true;
    private bool haveSchield = false;
    private Material[] materials;
    private Material playerMaterial;
    private Material green;
    private RawImage schildIcon;
    private Text SchildTimerText;
    private Scene currentScene;
    private GameObject GameOverAudio;
    private GameObject LevelCompleteAudio;
    private GameObject ExplosionAudio;
    private GameObject ClickAudio;

    private void Start()
    {
        ClickAudio = GameObject.Find("Click Audio");
        currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level01")
        {
            coinsLeft = 40;
        }
        else if (sceneName == "Level02")
        {
            coinsLeft = 80;
        }

        if (sceneName == "Level01" || sceneName == "Level02" || sceneName == "Level03")
        {
            distance = Sphere * SphersM / 2;
            sphereParts = new Vector3(distance, distance, distance);
            player = GameObject.Find("Player");
            completeLevel = GameObject.Find("Level Complete").GetComponent<Text>();
            gameover = GameObject.Find("Game Over").GetComponent<Text>();
            textScoreObj = GameObject.Find("Total Score").GetComponent<Text>();
            totalSNum = GameObject.Find("Total Score Number").GetComponent<Text>();
            rb = GameObject.Find("Player").GetComponent<Rigidbody>();
            originalPos = GameObject.Find("Player").GetComponent<Transform>().position;
            materials = player.GetComponent<MeshRenderer>().materials;
            playerMaterial = player.GetComponent<MeshRenderer>().material = materials[0];
            schildIcon = GameObject.Find("Schild Icon").GetComponent<RawImage>();
            SchildTimerText = GameObject.Find("Schild Timer").GetComponent<Text>();
            GameOverAudio = GameObject.Find("GameOver Audio");
            LevelCompleteAudio = GameObject.Find("Level Complete Audio");
            ExplosionAudio = GameObject.Find("Explosion Audio");
        }
        else if (sceneName == "EndWindow")
        {
            totalSNum = GameObject.Find("Total Score Number").GetComponent<Text>();
            totalSNum.text = scoreNumber.ToString();
        }
    }

    public void getCoinsLeft()
    {
        coinsLeft--;
    }

    public void getLife()
    {
        lifeNumber++;
        lifeChanged.Invoke(lifeNumber);
    }

    public void getScore()
    {
        scoreNumber++;
        scoreChanged.Invoke(scoreNumber);
    }

    private void Update()
    {
        if (haveSchield)
        {
            timer = timer - 1f * Time.deltaTime;
            timer = (float) System.Math.Round(timer, 2);

            if (timer == 0)
            {
                haveSchield = false;
                player.GetComponent<MeshRenderer>().material = playerMaterial;
                schildIcon.enabled = false;
                SchildTimerText.enabled = false;
            }
        }
    }

    public void getSchild()
    {
        green = player.GetComponent<MeshRenderer>().material = materials[1];
        player.GetComponent<MeshRenderer>().material = green;
        schildIcon.enabled = true;
        SchildTimerText.enabled = true;
        haveSchield = true;
    }

    public void ShieldProtection()
    {
        if (!haveSchield)
        {
            LoseLife();
        }
    }

    public void LoseLife()
    {
        if (lifeNumber > 0)
        {
            lifeNumber--;
            lifeChanged.Invoke(lifeNumber);
            rb.isKinematic = true;
            player.GetComponent<Transform>().position = originalPos;
            rb.isKinematic = false;
            player.SetActive(true);

            if (currentScene.name == "Level03")
            {
                haveSchield = false;
                player.GetComponent<MeshRenderer>().material = playerMaterial;
                schildIcon.enabled = false;
                SchildTimerText.enabled = false;
            }
        }
        else
        {
             Debug.Log("Leider verloren");
             gameover.enabled = true;
             totalSNum.enabled = true;
             textScoreObj.enabled = true;
             playAgainBtn.SetActive(true);
             rb.constraints = RigidbodyConstraints.FreezeAll;
             totalSNum.text = scoreNumber.ToString();
             GameOverAudio.GetComponent<AudioSource>().Play();
        }
    }

    public void EndPoint(GameObject nextLevelBtn)
    {
        Debug.Log("Ziel erreicht");
        completeLevel.enabled = true;
        nextLevelBtn.SetActive(true);
        textScoreObj.enabled = true;
        totalSNum.enabled = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        totalSNum.text = scoreNumber.ToString();
        LevelCompleteAudio.GetComponent<AudioSource>().Play();
    }

    public void explode()
    {
        if (!haveSchield)
        {
            ExplosionAudio.GetComponent<AudioSource>().Play();
            player.SetActive(false);

            for (int x = 0; x < SphersM; x++)
            {
                for (int y = 0; y < SphersM; y++)
                {
                    for (int z = 0; z < SphersM; z++)
                    {
                        createPiece(x, y, z);
                    }
                }
            }

            Vector3 explosionPos = player.transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, player.transform.position, explosionRadius, explosionUpward);
                }
            }
        }
    }

    void createPiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        piece.GetComponent<MeshRenderer>().material.color = Color.white;
        piece.transform.position = player.transform.position + new Vector3(Sphere * x, Sphere * y, Sphere * z) - sphereParts;
        piece.transform.localScale = new Vector3(Sphere, Sphere, Sphere);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = Sphere;
    }

    public void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = timing;
            pause.texture = playIcon;
            paused = false;
        }
        else
        {
            Time.timeScale = 1;
            pause.texture = pauseIcon;
            paused = true;
        }
    }

    public void ReturnLevel()
    {
        ClickAudio.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        lifeNumber = 3;
        scoreNumber = 0;
    }

    public void NextLevel()
    {
        ClickAudio.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        ClickAudio.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
        lifeNumber = 3;
        scoreNumber = 0;
    }

    public void Exitt()
    {
        ClickAudio.GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
