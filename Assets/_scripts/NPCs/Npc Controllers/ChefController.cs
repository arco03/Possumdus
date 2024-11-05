using _scripts.NPCs.States;
using UnityEngine;

namespace _scripts.NPCs.Npc_Controllers
{
    public class ChefController : Npc
    {
        private void Start()
        {
            ChangeState(_walkingState);
        }

        public override void Interact()
        {
            //TODO:
            // Lógica de interacción específica con el jugador
            Debug.Log("El NPC Chef está interactuando con el jugador");
            // Cambiar a otro estado si es necesario (ej. ChangeState(new TalkingState());)
        }
    }
}