using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _best;
    [SerializeField] private Button _startGame,_exit;

    public void Init()
    {
        _best.text = $"My Best : {PlayerPrefs.GetInt(Constant.MyBest, 0)}";

        _startGame.onClick.RemoveAllListeners();
        _startGame.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

        _exit.onClick.RemoveAllListeners();
        _exit.onClick.AddListener(Application.Quit);
    }
}