using EnemyMechanics.Playing;
using EnemyMechanics.Spawning;
using UnityEngine;

namespace EnemyMechanics.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Spawner _spawner;
        
        private void Awake()
        {
            _spawner.Spawn(_player);       
        }
    }    
}

