using System;
using UnityEngine;

namespace _scripts.Player
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [Header("Values Configuration")]
        [SerializeField] private float normalSpeed;
        [SerializeField] private float sprintSpeed;
        [SerializeField] private float sprintDuration;
        [SerializeField] private float rechargeSprintTime;
        [SerializeField] private float rotationX;
        [SerializeField] private float hungerSpeed;
        [SerializeField] private float hungerDuration;
        
        [HideInInspector] public float currentEnergy;
        [HideInInspector] public bool canRun = true;
        private Transform _playerCamera;
        private Rigidbody _rb;
        private float _currentSpeed;
        private bool _isHungry = false;
        private float _hungerTimer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
            
            Cursor.lockState = CursorLockMode.Locked;
            _playerCamera = Camera.main?.transform;

            _currentSpeed = normalSpeed;
            currentEnergy = sprintDuration;
            _hungerTimer = hungerDuration;
        }
    
        public void Rotation(float mouseX, float mouseY)
        {
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            _playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
        
        public void Move(float horizontal, float vertical)
        {
            Vector3 movement = transform.right * horizontal + transform.forward * vertical;
            movement *= _currentSpeed;
            
            Vector3 newSpeed = new Vector3(movement.x, _rb.velocity.y, movement.z);
            _rb.velocity = newSpeed;
        }

        public void CanSprint()
        {
            if (!_isHungry)
            {
                _currentSpeed = sprintSpeed;
                currentEnergy -= Time.deltaTime;

                if (currentEnergy <= 0)
                {
                    currentEnergy = 0;
                    canRun = false;
                    _currentSpeed = normalSpeed;
                }
            }
        }
        
        public void CantSprint()
        {
            _currentSpeed = _isHungry ? hungerSpeed : normalSpeed;
            
            if (currentEnergy < sprintDuration)
            {
                currentEnergy += (sprintDuration / rechargeSprintTime) * Time.deltaTime;
                if (currentEnergy >= sprintDuration)
                {
                    currentEnergy = sprintDuration;
                    canRun = true;
                }
            }
        }

        public void HungerManager()
        {
            _hungerTimer -= Time.deltaTime;
            if (_hungerTimer <= 0 && !_isHungry)
            {
                BecomeHungry();
            }
        }

        private void BecomeHungry()
        {
            _isHungry = true;
            _currentSpeed = hungerSpeed;
            canRun = false;
        }

        public void Eat()
        {
            _isHungry = false;
            _hungerTimer = hungerDuration;
            _currentSpeed = normalSpeed;
            canRun = true;
        }
    }
}
