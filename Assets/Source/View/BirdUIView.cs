using TMPro;
using UnityEngine;

public class BirdUIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;

    private IScore _wallet;

    public void Init(IScore wallet)
    => _wallet = wallet;

    private void FixedUpdate()
    => _textScore.text = _wallet.Score.ToString();
}