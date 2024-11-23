using System;
using UnityEngine;

namespace _scripts.Managers
{
    [Serializable]
    public enum CursorState
    {
        ShowCursor,
        HideCursor
    }
    public class CursorManager : MonoBehaviour
    {
        public static CursorManager Instance;
        
        public CursorState CursorState { get; private set; }
        
        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void EnableInteractionMode()
        {
            CursorState = CursorState.HideCursor;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void DisableInteractionMode()
        {
            CursorState = CursorState.ShowCursor;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }
}