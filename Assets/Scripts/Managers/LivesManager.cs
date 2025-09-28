using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class LivesManager : MonoBehaviour, IObservable
    {
        private List<IObserver> _observers = new List<IObserver>();

        public static LivesManager Instance { get; private set; }
        public List<IObserver> Observers { get { return _observers; } }
        [SerializeField] public int numLives = 5;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); 
            }
            else
            {
                Instance = this;
            }
        }

        public void IncrementLives(int num)
        {
            if(numLives == 0) { return; }
            numLives += num;
            if(numLives <= 0)
            {
                numLives = 0;
                OnZeroLives();
            }
            ((IObservable)this).Raise();
        }

        public void SetLives(int num)
        {
            numLives = num;
            ((IObservable)this).Raise();
        }

        public void OnZeroLives()
        {
            Debug.Log("GAME OVER!!!");
        }
    }
}
