using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 10f;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.anyKey)
        {
            _animator.SetFloat("Speed", 1);

            if (Input.GetKey(KeyCode.D))
            {
                _spriteRenderer.flipX = false;
                transform.Translate((Vector3.right * _speed) * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _spriteRenderer.flipX = true;
                transform.Translate((Vector3.left * _speed) * Time.deltaTime);
            }
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }
}