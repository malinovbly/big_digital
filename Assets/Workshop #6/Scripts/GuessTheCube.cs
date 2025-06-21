using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuessTheCube : MonoBehaviour
{
    public Rigidbody[] _rbs;
    public GameObject[] _buttons;
    private int _ans;
    public GameObject _win;
    public GameObject _lose;

    void Start()
    {
        _win.SetActive(false);
        _lose.SetActive(false);
        _ans = Random.Range(1, _rbs.Length + 1);
    }

    private void GameResult()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].GetComponent<Button>().interactable = false;
            
            if (_ans != i + 1)
                _rbs[i].useGravity = true;
        }
    }

    public void PressButton()
    {
        GameObject pressedButton = EventSystem.current.currentSelectedGameObject;
        if (pressedButton != null)
        {
            int cubeNumber = int.Parse(pressedButton.name.Substring(13, 1));
            _win.SetActive(_ans == cubeNumber);
            _lose.SetActive(_ans != cubeNumber);
            GameResult();
        }
    }
}
