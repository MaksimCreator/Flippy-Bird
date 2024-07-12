using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameView : MonoBehaviour
{
    private const int _numberScoreIsNewMedal = 10;

    [SerializeField] private Sprite _bronseMedsl,_serebroMedal,_goldMedal,_platinaMedal;
    [SerializeField] private Button _restartButton,_menu,_quit;
    [SerializeField] private TextMeshProUGUI _scoreEndGame,_best,_scoreGame;
    [SerializeField] private Image _medal,_newBest;

    public void Show(int score, Action restarButton,Action menuButton,Action quit)
    {
        NewBest(score);
        SetMedal(score);

        _restartButton.onClick.RemoveAllListeners();
        _menu.onClick.RemoveAllListeners();
        _quit.onClick.RemoveAllListeners();

        _restartButton.onClick.AddListener(() => restarButton());
        _menu.onClick.AddListener(() => menuButton());
        _quit.onClick.AddListener(() => quit());

        _scoreGame.gameObject.SetActive(false);
        _scoreEndGame.text = score.ToString();
        _best.text = PlayerPrefs.GetInt(Constant.MyBest, 0).ToString();

        gameObject.SetActive(true);
    }

    private void NewBest(int score)
    {
        if (PlayerPrefs.GetInt(Constant.MyBest, 0) < score)
        {
            PlayerPrefs.SetInt(Constant.MyBest, score);
            _newBest.gameObject.SetActive(true);
        }
    }

    private void SetMedal(int score)
    {
        Sprite[] _allMedals = new Sprite[]
        {
            _bronseMedsl,
            _serebroMedal,
            _goldMedal,
            _platinaMedal
        };
        int AccamulatedScore = 0;

        for (int i = 0; i < _allMedals.Length; i++)
        {
            AccamulatedScore += _numberScoreIsNewMedal;

            if (AccamulatedScore > score)
                return;

            _medal.gameObject.SetActive(true);
            _medal.sprite = _allMedals[i];
        }
    }
}