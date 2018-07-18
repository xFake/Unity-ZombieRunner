using System;
using UnityEngine;
using ZombieRunner;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling

        private Animator animator;
        private Player player;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
            animator = GetComponent<Animator>();
            player = FindObjectOfType<Player>();
        }


        private void Update()
        {
            if (player != null)
                agent.SetDestination(player.transform.position);

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                animator.SetBool("Attack", false);
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                animator.SetBool("Attack", true);
                character.Move(Vector3.zero, false, false);
            }
        }
    }
}
