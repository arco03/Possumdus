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

        #region VerificationButtons
        private void Start()
        {
            _possibleRots = correctRotation.Length;
            int rand = Random.Range(0, _rotations.Length);
            transform.eulerAngles = new Vector3(0, 0, _rotations[rand]);
            CheckPipeState();
           /* if (_possibleRots > 1)
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
            }*/
            
        }

        public void MouseOn()
        {
            transform.Rotate(new Vector3(0, 0, 90));
            CheckPipeState();
           /* if (_possibleRots > 1)
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
            }*/
        }

        public void CheckPipeState()
        {
            bool previousState = isPlaced;
            isPlaced = false;
            foreach (float correct in correctRotation)
            {
                if (Mathf.Approximately(transform.eulerAngles.z, correct))
                {
                    isPlaced = true;
                    break;
                }
            }
            if (previousState != isPlaced)
            {
                CompletePipeState();
            }
        }

        public void CompletePipeState()
        {
            OnPipeChanged?.Invoke(this);
            Debug.Log($"Tubería {gameObject.name} cambió estado a: {isPlaced}");
        }

    }
    #endregion
}
