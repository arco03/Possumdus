using UnityEngine;

namespace _scripts.UI.UI_Tasks
{
    public class RotatingPipes : MonoBehaviour
    {
        [Header("Pipe Settings")]
        private readonly float[] _rotations = { 0, 90, 180, 270 };
        public float[] correctRotation;
        private int _possibleRots = 1;
        public bool isPlaced = false;
        public delegate void PipeStateChanged(RotatingPipes rotPipes);
        public event PipeStateChanged OnPipeChanged;
        private void Start()
        {
            _possibleRots = correctRotation.Length;
            int rand = Random.Range(0, _rotations.Length);
            transform.eulerAngles = new Vector3(0, 0, _rotations[rand]);
            if (_possibleRots > 1)
            {
                if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
                {
                    isPlaced = true;
                    CorrectMove();
                }
            }
            else if(transform.eulerAngles.z == correctRotation[0])
            {
                 isPlaced = true;
                 CorrectMove();
            }
            
        }

        public void MouseOn()
        {
            transform.Rotate(new Vector3(0, 0, 90));
            if (_possibleRots > 1)
            {
                if(transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && isPlaced == false)
                {
                    isPlaced = true;
                    CorrectMove();
                }else if(isPlaced == true)
                {
                    isPlaced = false;
                }
            }
            else if(transform.eulerAngles.z == correctRotation[0] && isPlaced == false)
            {
                isPlaced = true;
                CorrectMove();
            }else if(isPlaced == true)
            {
                isPlaced = false;
            }
        }

        private void CorrectMove()
        {
            OnPipeChanged?.Invoke(this);
        }
    } 
}
