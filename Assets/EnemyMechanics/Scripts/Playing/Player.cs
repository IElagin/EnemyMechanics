using EnemyMechanics.Core;
using EnemyMechanics.Movement;
using UnityEngine;

namespace EnemyMechanics.Playing
{
    public class Player : MonoBehaviour
    {
        private Mover _mover;
        private Vector3 _direction;
        
        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            _direction = (Input.GetAxisRaw("Horizontal") * Vector3.right) + (Input.GetAxisRaw("Vertical") * Vector3.forward); 
        
            if (_direction.magnitude <= ConfigData.MovementDeadZone)
                return;
        
            _mover.MoveTo(_direction);
            _mover.RotateTo(_direction);    
        }
    }
}