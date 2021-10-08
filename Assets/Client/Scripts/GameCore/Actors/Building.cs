using UnityEngine;
using UnityEngine.Events;

namespace GameCore
{
    public class Building : MonoBehaviour
    {
        public UnityEvent OnClear = new UnityEvent();
        public UnityEvent OnApply = new UnityEvent();

        [SerializeField] private Dirts[] m_Dirts;


        private void Start() 
        {
            OnApply.AddListener(CheckStatus);
        }

        private void CheckStatus()
        {
            var countDestroy = 0;
            for(int i = 0; i < m_Dirts.Length; ++i)
            {
                if(m_Dirts[i].IsDestroy)
                    countDestroy++;
            }

            if(countDestroy == m_Dirts.Length)
                OnClear?.Invoke();
        }
    }
}
