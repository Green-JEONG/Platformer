using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames
{
    [RequireComponent(typeof(Collider2D))]
    public class TeleportPoint : MonoBehaviour
    {
        public enum TransitionType
        {
            SameScene,
        }

        public enum TransitionWhen
        {
            ExternalCall, InteractPressed, OnTriggerEnter,
        }

        [Tooltip("This is the gameobject that will teleport. For example, the player.")]
        public GameObject transitioningGameObject;
        [Tooltip("Whether the transition will be within this scene.")]
        public TransitionType transitionType = TransitionType.SameScene;
        [Tooltip("The destination transform to which the gameobject will be teleported.")]
        public Transform destinationTransform;
        [Tooltip("What should trigger the teleportation to start.")]
        public TransitionWhen transitionWhen = TransitionWhen.OnTriggerEnter;
        [Tooltip("The player will lose control when the transition happens but should the axis and button values reset to the default when control is lost.")]
        public bool resetInputValuesOnTransition = true;
        [Tooltip("Is this transition only possible with specific items in the inventory?")]
        public bool requiresInventoryCheck = false;

        private bool m_TransitioningGameObjectPresent;

        void Start()
        {
            if (transitionWhen == TransitionWhen.ExternalCall)
                m_TransitioningGameObjectPresent = true;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == transitioningGameObject)
            {
                m_TransitioningGameObjectPresent = true;

                if (transitionWhen == TransitionWhen.OnTriggerEnter)
                    Teleport();
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == transitioningGameObject)
            {
                m_TransitioningGameObjectPresent = false;
            }
        }

        void Update()
        {
            if (!m_TransitioningGameObjectPresent)
                return;

            if (transitionWhen == TransitionWhen.InteractPressed)
            {
                if (Input.GetButtonDown("Interact"))
                {
                    Teleport();
                }
            }
        }

        public void Teleport()
        {
            if (transitioningGameObject != null && destinationTransform != null)
            {
                transitioningGameObject.transform.position = destinationTransform.position;
                Debug.Log("Teleported to " + destinationTransform.position);
            }
            else
            {
                Debug.LogWarning("Teleportation failed. Ensure both transitioningGameObject and destinationTransform are set.");
            }
        }
    }
}