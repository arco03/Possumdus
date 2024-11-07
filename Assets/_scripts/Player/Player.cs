using UnityEngine;

namespace _scripts.Player
{
    public class Player1 : MonoBehaviour
    {
        [Header("Control Settings")] 
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;  
        [SerializeField] private string mouseX;
        [SerializeField] private string mouseY;
        
        [Header("Other Settings")]
        [SerializeField] private float mouseSensibility;
        [SerializeField] private Character character;

        private float _x, _y;
        private float _mX, _mY;

        private void Update()
        {
            _x = Input.GetAxisRaw(horizontal);
            _y = Input.GetAxisRaw(vertical);

            _mX = Input.GetAxis(mouseX) * mouseSensibility;
            _mY = Input.GetAxis(mouseY) * mouseSensibility;
            
            character.Rotation(_mX, _mY);
            character.HungerManager();

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && character.canRun &&
                character.currentEnergy > 0)
            {
                character.CanSprint();
            }
            else
                character.CantSprint();
        }
    
        private void FixedUpdate()
        {
            character.Move(_x,_y);
        }
    }
}
