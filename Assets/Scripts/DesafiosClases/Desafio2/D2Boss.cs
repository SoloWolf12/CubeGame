using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum Command 
{
move,
damage,
heal,
moveAndDamage,
moveAndHeal,
nothing
}

enum WhereToMove 
{
forward,backward,right,left,none
}

public class D2Boss : MonoBehaviour
{
    [SerializeField] D2Minion OrderMinion; 
    [SerializeField] Command action;
    [SerializeField] WhereToMove moveWhere;
    [SerializeField] private int healtAmount;
    [SerializeField] private int damageAmount;
    private float _timer;
    [SerializeField] private float timeToReset;
    private bool readyToCast=false;

    void Update()
    {
        TimeToNewCommand();      
    }

    private void TimeToNewCommand()
    {
        if (readyToCast == false)
        {
            _timer += Time.deltaTime;
            //Debug.Log(_timer);
            if (_timer >= timeToReset)
            {
                readyToCast = true;
                _timer= 0;
            }
        }
        else 
        {
            DetectCommands();
        }      
    }

    private void DetectCommands()
    {

        if (action == Command.heal) 
        {
            Debug.Log("curar minion");
            HealMinion();
            readyToCast = false;
        }
        else if (action == Command.damage) 
        {
            Debug.Log("Dañar minion");
            DamageMinion();
            readyToCast = false;
        }
        else if (action == Command.move) 
        {
            Debug.Log("mover minion");
            MoveMinion();
            readyToCast = false;
        }
        else if (action == Command.moveAndDamage)
        {
            Debug.Log("mover y dañar minion");
            MoveMinion();
            DamageMinion();
            readyToCast = false;
        }
        else if (action == Command.moveAndHeal)
        {
            Debug.Log("mover y curar minion");
            MoveMinion();
            HealMinion();
            readyToCast = false;
        }
        else 
        {
            Debug.Log("seleccione una accion");
        }
    }

    private void HealMinion() 
    {
        OrderMinion.Heal(healtAmount);    
    }
    private void DamageMinion()
    {
        OrderMinion.Damage(damageAmount);
    }
    private void MoveMinion()
    {
        if (moveWhere == WhereToMove.forward)
        {
            OrderMinion.Move(new Vector3(0, 0, 1));
        }
        else if (moveWhere == WhereToMove.backward)
        {
            OrderMinion.Move(new Vector3(0, 0, -1));
        }
        else if (moveWhere == WhereToMove.right)
        {
            OrderMinion.Move(new Vector3(1, 0, 0));
        }
        else if (moveWhere == WhereToMove.backward)
        {
            OrderMinion.Move(new Vector3(-1, 0, 0));
        }
        else 
        {
            Debug.Log("seleccionar una direccion");
        }
        
    }

}
