using UnityEngine;

public class PlayerMove : MonoBehaviour, IPlayerMoveble
{
    public static PlayerMove Instance;

    [Range(0f, 2f)]
    [SerializeField] private float _speed;

    private Vector3 _moveDirection;

    private Rigidbody _rigidbody;

    private Animator _animator;

    private bool _withBoxes = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    public void Run(float horizontal, float vertical)
    {
        if (_withBoxes == false)
            _animator.SetBool("Running", true);
        else
            _animator.SetBool("RunningWithBox", true);
        _animator.SetBool("IdleWithBox", false);

        _moveDirection = new Vector3(-horizontal * _speed, 0, -vertical * _speed);
        _moveDirection = Vector3.ClampMagnitude(_moveDirection, _speed);
        Vector3 m = new Vector3(-vertical * _speed, 0, horizontal * _speed);
        m = Vector3.ClampMagnitude(m, _speed);
        if (_moveDirection != Vector3.zero)
        {
            _rigidbody.MovePosition(transform.position + _moveDirection);
            _rigidbody.MoveRotation(Quaternion.LookRotation(m));
        }
    }

    public void Idle()
    {
        _animator.SetBool("Running", false);
        _animator.SetBool("RunningWithBox", false);
        if (_withBoxes == true)
            _animator.SetBool("IdleWithBox", true);
    }

    public void GetBox(bool value)
    {
        _withBoxes = value;
    }
}
