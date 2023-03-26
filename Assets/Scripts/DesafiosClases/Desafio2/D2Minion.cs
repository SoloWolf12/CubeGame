using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D2Minion : MonoBehaviour
{
    [SerializeField] private int life;
    private int _maxlife = 100;
    [SerializeField] private float speed;
 
    
    public void Move(Vector3 direction)
    {
        transform.position += direction * (speed * Time.deltaTime);
        
    }
    public void Heal(int amountToHeal) 
    {
        life+= amountToHeal;

        if(life > _maxlife)
        {
            life=100; 
        }
    }

    public void Damage(int amountToDamage)
    {
        life -= amountToDamage;

        if (life <= 0)
        {
            life=0;
        }
    }
}
