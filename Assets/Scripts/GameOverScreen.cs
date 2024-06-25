using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _failCounterTextField;

    private int _failCounter = 0;


    public void AddFail()
    {
        _failCounter++;
        UpdateFailCounter();
    }

    private void UpdateFailCounter() => _failCounterTextField.text = $"(Количество ошибок - {_failCounter})";

}
