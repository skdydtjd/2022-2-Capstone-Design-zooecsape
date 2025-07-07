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

    // 수정 부분 (씬이 넘어갈 때 같은 객체가 있으면 파괴시킴)
    static GameManager _instance;

    public static GameManager instance
    {
        get { return _instance; }
    }
    //

    public GameState currentGameState = GameState.menu;

    // 종료 메뉴 변수 (추가)
    public GameObject QuitMenu;

    // 게임 방법 변수
    public GameObject Howto;

    // Start 버튼 버그 수정 (추가)
    public GameObject StartButton;

    // Stage3 물고기 점수 부분 추가
    public GameObject Stage3Score;
    public Text FishScore;
    public float fishcount = 0f;

    // GameOverUI 추가
    public GameObject GameOver;

    // EndingReStart
    public GameObject EndingReStart;

    // Stage ScoreText
    public GameObject StageScoreText;

    // 종료 메뉴 사운드 효과 (추가)
    AudioSource click;
    public AudioClip outgame;
    public AudioClip Clicksound;
    
    public GameManager()
    {
        G_Timer = 0f;
        G_TimerStart = false;
        sceneCount = 0;
    }

    // 수정 부분 (씬이 넘어가도 유지되게)
    private void Awake()
    {
        if (instance == null)
        {
            _instance = this;

            // 추가
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

            // 추가
            Destroy(QuitMenu);
            Destroy(StartButton);
            Destroy(Stage3Score);
            Destroy(GameOver);
            Destroy(EndingReStart);
            Destroy(StageScoreText);
        }

        //추가
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
            Debug.Log("게임 오버");
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

    // 추가 부분 (예를 클릭 시 종료)
    public void QuitGame()
    {
        click.clip = Clicksound;
        click.Play();
        Application.Quit();
    }
    //

    // 추가 부분 (아니오를 클릭 시 다시 게임으로 돌아감)
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

        // 추가 부분 (esc 누를 시 종료 메뉴 활성화)
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

        // 추가 부분 (Start버튼 오류 수정)
        if(SceneManager.GetActiveScene().name == "Start")
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
        //

        // Stage3Score 추가
        if(SceneManager.GetActiveScene().name == "Stage3")
        {
            Stage3Score.SetActive(true);
        }
        else
        {
            Stage3Score.SetActive(false);
        }
        //

        // GameOver 추가
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
