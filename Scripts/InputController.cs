using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Platform _platform;

    [SerializeField] private Joystick _joystick;

    private IPlayerMoveble _player;

    private float _horizontal;
    private float _vertical;

    private enum Platform
    {
        Android,
        PC
    }

    private void Start()
    {
        _player = PlayerMove.Instance;
        if (_platform == Platform.Android)
        {
            _joystick.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (_platform == Platform.PC)
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }
        else if(_platform == Platform.Android)
        {
            _horizontal = _joystick.Horizontal;
            _vertical = _joystick.Vertical;
        }
        if (_horizontal != 0 || _vertical != 0)
            _player.Run(_horizontal, _vertical);
        else
            _player.Idle();
    }
}
