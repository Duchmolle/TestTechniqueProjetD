using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravityFallMultiplier;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxAngularVelocity;

    [SerializeField] private CollisionsManager _collisionsManager;

    [SerializeField] private UIManager _uIManager;
    [SerializeField] private CameraFollow _cameraFollow;

    [SerializeField] GameObject _aventurier;

    private Vector3 _verticalVelocity;
    private Vector3 _horizontalVelocity;
    private Rigidbody _playerRb;
    private Vector3 _movementInput;
    private bool _isJumping;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        _horizontalVelocity = _movementInput.normalized * _speed;
        Vector3 velocity = _verticalVelocity + _horizontalVelocity;
        
        _playerRb.velocity = velocity;

        float maxAngularVelocity = _maxAngularVelocity;
        _playerRb.maxAngularVelocity = maxAngularVelocity;

        PlayerJump();

        if (!_collisionsManager.IsGrounded())
        {
            _verticalVelocity += Physics.gravity * _gravityFallMultiplier * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            StartCoroutine(RespawnCoroutine());
        }

        if(other.gameObject.layer == 8)
        {
            _uIManager.WinCanvas();
            _aventurier.SetActive(false);
        }
    }
    private void GetInput()
    {
        float horizontalInput;
        float verticalInput;

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        _movementInput = new Vector3(horizontalInput, 0, verticalInput);

        if (Input.GetButtonDown("Jump") && _collisionsManager.IsGrounded())
        {
            _isJumping = true;
        }
    }

    private void PlayerJump()
    {
        if(_isJumping)
        {
            _verticalVelocity = Vector3.up * _jumpForce;
            _isJumping = false;
        }
    }

    IEnumerator RespawnCoroutine()
    {
        _cameraFollow.enabled = false;
        _uIManager._timerDisplay.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        _uIManager.DeadScreen();
    }
}
