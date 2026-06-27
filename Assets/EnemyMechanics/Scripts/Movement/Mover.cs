using UnityEngine;

namespace EnemyMechanics.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        
        public void MoveTo(Vector3 direction)
        {
            transform.Translate(direction * (_speed * Time.deltaTime), Space.World);    
        }

        public void RotateTo(Vector3 direction)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);    
        }
    }
}