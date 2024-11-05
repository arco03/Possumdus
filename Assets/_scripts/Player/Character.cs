using System;
using UnityEngine;
using UnityEngine.Serialization;

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
        [HideInInspector] public float currentEnergy;
        [HideInInspector] public bool canRun = true;
        public float hungerDuration;
        private Transform _playerCamera;
        private Rigidbody _rb;
        private IPlayerContext context;
        private float _currentSpeed;
        private bool _isHungry = false;
         [SerializeField]private float hungerTimer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
            
            Cursor.lockState = CursorLockMode.Locked;
            _playerCamera = Camera.main?.transform;
            
            context = GetComponent<PlayerContext>(); 
            if (context == null)
            {
                Debug.LogError("PlayerContext not found on Player.");
            }
            
            _currentSpeed = normalSpeed;
            currentEnergy = sprintDuration;
            hungerTimer = hungerDuration;
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
            hungerTimer -= Time.deltaTime;
            if (hungerTimer <= 0 && !_isHungry)
            {
                BecomeHungry();
            }
        }

        public void BecomeHungry()
        {
            _isHungry = true;
            _currentSpeed = hungerSpeed;
            canRun = false;
        }

        public void Eat()
        {
            _isHungry = false;
            hungerTimer = hungerDuration;
            _currentSpeed = normalSpeed;
            canRun = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IInteract component))
            {
                if (context != null) 
                    component.Interact(context);
                else
                    Debug.LogWarning("Context is null, cannot interact.");
            }
        }
    }
}
