using System;
using _scripts.Player.Context;
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
        [SerializeField]private float hungerTimer;
        
        [Header("Objects Configuration")]
        [SerializeField] private float rayDistance;
        [SerializeField] private float holdDistance;
        [SerializeField] private float attractionForce;
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private float levitationForce;
        
        [HideInInspector] public float currentEnergy;
        [HideInInspector] public bool canRun = true;
        [HideInInspector] public GameObject pikedObject;
        [HideInInspector] public bool isObjectLevitating = false;
        [HideInInspector] public Rigidbody pikedObjectRb;
        
        public float hungerDuration;
        private Transform _playerCamera;
        private Rigidbody _rb;
        private IPlayerContext context;
        private float _currentSpeed;
        private bool _isHungry = false;
        private IInteract interactable;
        

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
            
            context = GetComponent<PlayerContext>(); 
            if (context == null) 
                Debug.LogError("PlayerContext not found on Player.");
            
            Cursor.lockState = CursorLockMode.Locked;
            _playerCamera = Camera.main?.transform;
            
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

        public void ObjectPiked()
        {
            var ray = new Ray(_playerCamera.position, _playerCamera.forward);
            Debug.DrawRay(_playerCamera.position, _playerCamera.forward * rayDistance, Color.red);
            
            if (Physics.Raycast(ray, out var hit, rayDistance, interactableLayer.value))
            {
                interactable = hit.collider.GetComponent<IInteract>();

                if (interactable != null)
                {
                  pikedObject = hit.collider.gameObject;
                  pikedObjectRb = pikedObject.GetComponent<Rigidbody>();

                  if (pikedObjectRb != null)
                  {
                      pikedObjectRb.useGravity = false;
                      pikedObjectRb.freezeRotation = true;
                      pikedObjectRb.detectCollisions = false;
                      
                      interactable.OnInteract();

                      isObjectLevitating = true;
                      Debug.Log("objeto detectado: " + pikedObject.name);
                  }
                  else
                  {
                      Debug.Log("El objecto no tiene un rigidbody asignado");
                  }
                }
                else
                {
                    Debug.LogWarning("El objecto no implementa la interfaz");
                }    
            }
            else
            {
                Debug.LogWarning("El objecto no alcanzo ningun objecto interactuable");
            }
        }

        public void LevitateObject()
        {
            if (pikedObjectRb != null && isObjectLevitating)
            {
                Vector3 levitateDirection = Vector3.up * levitationForce;
                pikedObjectRb.AddForce(levitateDirection, ForceMode.Acceleration);
            }
        }

        public void FollowPlayer()
        {
            if (pikedObject != null)
            {
                Vector3 targetPosition = _playerCamera.position + _playerCamera.forward * holdDistance;
                pikedObject.transform.position = Vector3.Lerp(pikedObject.transform.position, targetPosition, Time.deltaTime * 10f);
            }
        }
        
        public void ReleaseObject()
        {
            if (pikedObject != null)
            {
                interactable.OnRelease();
                
                pikedObjectRb.useGravity = true;
                pikedObjectRb.freezeRotation = false;
                pikedObjectRb.detectCollisions = true;
                
                isObjectLevitating = false;
                pikedObject = null;
                pikedObjectRb = null;
                interactable = null;
            }
        }

        // private void OnCollisionEnter(Collision other)
        // {
        //     if (other.gameObject.TryGetComponent(out IInteract component))
        //     {
        //         // if (context != null) 
        //         //     component.Interact(context);
        //         // else
        //         //     Debug.LogWarning("Context is null, cannot interact.");
        //      }
        // }

    }
}
