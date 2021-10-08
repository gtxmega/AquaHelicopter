using UnityEngine;
using UnityEngine.Events;

namespace GameCore.Actors
{
    public enum EActorStates
    {
        Awake, Start, Active, Inactive
    }

    public abstract class Actor : MonoBehaviour
    {
        public UnityEvent EventUpdate = new UnityEvent();

        [SerializeField] private EActorStates actorStates;

        protected virtual void Start()
        {
            SubscrubeOnEvents();
        }

        protected virtual void Update() 
        {
            if(actorStates == EActorStates.Active)
            {
                EventUpdate.Invoke();
            }
        }

        public virtual void EnableActor()
        {
            actorStates = EActorStates.Active;
        }
        public virtual void DisableActor()
        {
            actorStates = EActorStates.Inactive;
        }

        protected virtual void SubscrubeOnEvents()
        {
            if(GameMode.Instance != null)
            {
                GameMode.Instance.LevelStart.AddListener(EnableActor);
                GameMode.Instance.LevelLose.AddListener(DisableActor);
            }
        }
        protected virtual void UnSubscrubeOnEvents()
        {
            if(GameMode.Instance != null)
            {
                GameMode.Instance.LevelStart.RemoveListener(EnableActor);
                GameMode.Instance.LevelLose.RemoveListener(DisableActor);
            }
        }


        private void OnEnable() 
        {
            SubscrubeOnEvents();
        }
        private void OnDisable() 
        {
            UnSubscrubeOnEvents();
        }
    }
}
