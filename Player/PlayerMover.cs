using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMover : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";

    [SerializeField] private SoundHandler _sounds;

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _currentSpeed;

    [SerializeField] private float _minJumpForse;
    [SerializeField] private float _maxJumpForse;   
    [SerializeField] private float _currentJumpForce;   

    private Rigidbody2D _rigidBody;
    private PlayerAnimator _animator;

    private bool _isJumping;
    private bool _facingRight;

    public bool IsGrounded { get; private set; }

    public void Initialize()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _animator = GetComponent<PlayerAnimator>();
        _animator.Initialize();
    }

    private void Start()
    {
        _facingRight = true;
    }

    private void OnValidate()
    {
        Validator.Validate(ref _currentSpeed, _minSpeed, _maxSpeed);
        Validator.Validate(ref _currentJumpForce, _minJumpForse, _maxJumpForse);
    }

    public void TryMove()
    {
        float translationHorizontal = Input.GetAxis(HorizontalInput);

        if (translationHorizontal != 0)
        {
            _rigidBody.velocity = new Vector2(translationHorizontal * _currentSpeed, _rigidBody.velocity.y);
            _animator.Move();

            if (translationHorizontal > 0 && _facingRight == false)
            {
                TryFlip();
            }
            else if (translationHorizontal < 0 && _facingRight)
            {
                TryFlip();
            }
        }
        else
        {
            _animator.Idle();
        }
    }

    public void Jump()
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _currentJumpForce);
        _isJumping = true;

        _animator.Jump();
        _sounds.Jump();
    }
    
    private void TryFlip()
    {
        _facingRight = !_facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            IsGrounded = true;
            _isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            IsGrounded = false;
        }
    }
}