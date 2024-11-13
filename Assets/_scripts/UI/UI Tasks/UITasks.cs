using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _scripts.TaskSystem
{
    public class UITasks : Tasks
    {
        public Transform UIPanel;
        public GameObject InteractablePanel;
        private bool isActivated = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) // Cambia el tag si es necesario
            {
                ActivateUITask(); // Activa la tarea cuando el jugador colisiona con el objeto en escena
            }
        }

        public void ActivateUITask()
        {

        }
    }
}


