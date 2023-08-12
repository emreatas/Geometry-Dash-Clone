using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GDClone.CubeCharacter
{
    public enum SpeedState { slow, normal, fast, faster, fastest }
    public enum GameMode { Cube, Ship }

    public enum States { speedState, gamemodeState, gravityState }

    [RequireComponent(typeof(Rigidbody2D))]
    public class CubeMovement : MonoBehaviour
    {
        [SerializeField] SpeedState _currentSpeed;
        [SerializeField] GameMode _currentGameMode;

        Dictionary<SpeedState, float> _speed = new Dictionary<SpeedState, float>();

        [SerializeField] Transform _groundCheck;
        [SerializeField] float _groundCheckRadius;
        [SerializeField] LayerMask _groundMask;


        float _forceModeValue = 26.6581f;

        int _gravity = 1;

        Rigidbody2D _rb;
        [SerializeField] Transform _sprite;

        private void OnEnable()
        {
            GameManager.GameManager.OnChangeMovement += GameManager_OnChangeMovement;
            GameManager.GameManager.OnGameStart += GameManager_OnGameStart;

        }



        private void GameManager_OnGameStart()
        {
            SceneManager.LoadScene("GameScene");
            Time.timeScale = 1;
        }

        private void GameManager_OnChangeMovement(GameMode arg1, SpeedState arg2, bool arg3, States arg4)
        {
            ChangeThroughPortal(arg1, arg2, arg3 ? 1 : -1, arg4);
        }

        private void OnDisable()
        {
            GameManager.GameManager.OnChangeMovement -= GameManager_OnChangeMovement;
            GameManager.GameManager.OnGameStart -= GameManager_OnGameStart;


        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = 12.41067f;

            SetSpeedValues();
        }

        private void Update()
        {
            transform.position += Vector3.right * _speed[_currentSpeed] * Time.deltaTime;

            if (_rb.velocity.y < -24.2f)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, -24.2f);
            }


            Invoke(_currentGameMode.ToString(), 0);


        }

        bool OnGround()
        {
            return Physics2D.OverlapBox(
                transform.position + Vector3.down * _gravity * .5f,
                Vector3.right * 1.1f + Vector3.up * _groundCheckRadius,
                0,
                _groundMask);
        }
        bool TouchingWall()
        {
            return Physics2D.OverlapBox(
                (Vector2)transform.position + (Vector2.right * 0.55f),
                Vector2.up * 0.8f + (Vector2.right * _groundCheckRadius),
                0,
                _groundMask);
        }
        void Cube()
        {
            if (OnGround())
            {

                Vector3 Rotation = _sprite.rotation.eulerAngles;
                Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
                _sprite.rotation = Quaternion.Euler(Rotation);
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("zýpzýp");
                    _rb.velocity = Vector2.zero;
                    _rb.AddForce(Vector2.up * _forceModeValue * _gravity, ForceMode2D.Impulse);
                }
            }
            else
            {
                _sprite.Rotate(Vector3.back, 452.4152186f * Time.deltaTime * _gravity);
            }
        }

        void Ship()
        {
            transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * 2);

            if (Input.GetMouseButton(0))
            {
                _rb.gravityScale = -4.315f;
            }
            else
            {
                _rb.gravityScale = 4.315f;
            }
        }


        public void ChangeThroughPortal(GameMode GameMode, SpeedState SpeedState, int gravity, States State)
        {
            switch (State)
            {
                case States.speedState:
                    _currentSpeed = SpeedState;
                    break;
                case States.gamemodeState:
                    _currentGameMode = GameMode;
                    break;
                case States.gravityState:
                    _gravity = gravity;
                    _rb.gravityScale = Mathf.Abs(_rb.gravityScale) * gravity;
                    break;
            }


        }


        void SetSpeedValues()
        {
            _speed[SpeedState.slow] = 8.6f;
            _speed[SpeedState.normal] = 10.4f;
            _speed[SpeedState.fast] = 12.96f;
            _speed[SpeedState.faster] = 15.6f;
            _speed[SpeedState.fastest] = 19.27f;
        }

    }
}