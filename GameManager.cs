using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public float G_Timer;
    public bool G_TimerStart;

    public int sceneCount;

    // ���� �κ� (���� �Ѿ �� ���� ��ü�� ������ �ı���Ŵ)
    static GameManager _instance;

    public static GameManager instance
    {
        get { return _instance; }
    }
    //

    public GameState currentGameState = GameState.menu;

    // ���� �޴� ���� (�߰�)
    public GameObject QuitMenu;

    // ���� ��� ����
    public GameObject Howto;

    // Start ��ư ���� ���� (�߰�)
    public GameObject StartButton;

    // Stage3 ����� ���� �κ� �߰�
    public GameObject Stage3Score;
    public Text FishScore;
    public float fishcount = 0f;

    // GameOverUI �߰�
    public GameObject GameOver;

    // EndingReStart
    public GameObject EndingReStart;

    // Stage ScoreText
    public GameObject StageScoreText;

    // ���� �޴� ���� ȿ�� (�߰�)
    AudioSource click;
    public AudioClip outgame;
    public AudioClip Clicksound;
    
    public GameManager()
    {
        G_Timer = 0f;
        G_TimerStart = false;
        sceneCount = 0;
    }

    // ���� �κ� (���� �Ѿ�� �����ǰ�)
    private void Awake()
    {
        if (instance == null)
        {
            _instance = this;

            // �߰�
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(QuitMenu);
            DontDestroyOnLoad(StartButton);
            DontDestroyOnLoad(Stage3Score);
            DontDestroyOnLoad(GameOver);
            DontDestroyOnLoad(EndingReStart);
            DontDestroyOnLoad(StageScoreText);
        }
        else
        {
            Destroy(gameObject);

            // �߰�
            Destroy(QuitMenu);
            Destroy(StartButton);
            Destroy(Stage3Score);
            Destroy(GameOver);
            Destroy(EndingReStart);
            Destroy(StageScoreText);
        }

        //�߰�
        click = GetComponent<AudioSource>();
    }
    //

    // Start is called before the first frame update
    void Start()
    {
      
    }

    void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            StageScoreText.SetActive(false);
        }
        else if (newGameState == GameState.inGame)
        {
            SceneManager.LoadScene("Stage1");
            StageScoreText.SetActive(true);
            G_Timer = 0f;
            G_TimerStart = true;
        }
        else if (newGameState == GameState.gameOver)
        {
            Debug.Log("���� ����");
            StageScoreText.SetActive(false);
            G_Timer = 0f;
            G_TimerStart = false;
            SceneManager.LoadScene("GameOver");
        }
        currentGameState = newGameState;
    }

    public void startGame()
    {
        click.clip = Clicksound;
        click.Play();
        SetGameState(GameState.inGame);
    }

    public void gameOver()
    {
        fishcount = 0f;
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    public void OpenHowTo()
    {
        click.clip = Clicksound;
        click.Play();
        Howto.SetActive(true);
    }

    public void CloseHowTo()
    {
        click.clip = Clicksound;
        click.Play();
        Howto.SetActive(false);
    }

    // �߰� �κ� (���� Ŭ�� �� ����)
    public void QuitGame()
    {
        click.clip = Clicksound;
        click.Play();
        Application.Quit();
    }
    //

    // �߰� �κ� (�ƴϿ��� Ŭ�� �� �ٽ� �������� ���ư�)
    public void ReturnGame()
    {
        Time.timeScale = 1;
        click.clip = Clicksound;
        click.Play();
        QuitMenu.SetActive(false);
    }
    //

    // Update is called once per frame
    void Update()
    {
        FishScore.text = "15 / " + fishcount;

        // �߰� �κ� (esc ���� �� ���� �޴� Ȱ��ȭ)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            click.clip = outgame;

            if (click.isPlaying)
            {
                return;
            }
            else
            {
                click.Play();
            }
            QuitMenu.SetActive(true);
        }
        //

        // �߰� �κ� (Start��ư ���� ����)
        if(SceneManager.GetActiveScene().name == "Start")
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
        //

        // Stage3Score �߰�
        if(SceneManager.GetActiveScene().name == "Stage3")
        {
            Stage3Score.SetActive(true);
        }
        else
        {
            Stage3Score.SetActive(false);
        }
        //

        // GameOver �߰�
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            GameOver.SetActive(true);
        }
        else
        {
            GameOver.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Ending")
        {
            SetGameState(GameState.menu);
            EndingReStart.SetActive(true);
        }
        else
        {
            EndingReStart.SetActive(false);
        }

        // G_Timer
        if (G_TimerStart)
        {
            if (SceneManager.GetActiveScene().name == "Ending")
            {
                G_TimerStart = false;
            }
            else
            {
                G_Timer += Time.deltaTime;
            }
            
        }
    }
}
