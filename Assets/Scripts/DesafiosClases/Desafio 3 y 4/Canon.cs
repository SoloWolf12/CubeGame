using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private KeyCode shootKeyCode;
    [SerializeField] private KeyCode shootKeyCodeJ;
    [SerializeField] private KeyCode shootKeyCodeK;
    [SerializeField] private KeyCode shootKeyCodeL;
    [SerializeField] private KeyCode autoShootModeKeyCodeA;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float toleranceBetwenShoots;
    [SerializeField] private bool isAuto=false;
    private float _timer;
    private int _bulletCounter;

    private void Update()
    {
        UpdateTimer();
        CheckInputs();
        TimeToReShoot();
    }
    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
    }
    private void CheckInputs() 
    {
        if (_timer >= toleranceBetwenShoots)
        {
            if (Input.GetKeyDown(shootKeyCode))
            {
                Shoot(1);
            }
            else if (Input.GetKeyDown(shootKeyCodeJ))
            {
                Shoot(2);
            }
            else if (Input.GetKeyDown(shootKeyCodeK))
            {
                Shoot(3);
            }
            else if (Input.GetKeyDown(shootKeyCodeL))
            {
                Shoot(4);
            }          
        }
        if (Input.GetKeyDown(autoShootModeKeyCodeA))
        {
            if (isAuto)
            {
                isAuto = false;
            }
            else
            {
                isAuto = true;
            }
        }
    }
    private void Shoot(int numberOfBullets)
    {
        
        Instantiate(bullet,shootPoint);
            _bulletCounter = numberOfBullets;
        _timer = 0;
        
    }
    private void TimeToReShoot()
    {
        if(isAuto) 
        {
            if (_timer >= toleranceBetwenShoots)
            {
                Instantiate(bullet, shootPoint);
                _bulletCounter--;
                _timer = 0;
            }
        }
        if (_bulletCounter > 1) 
        {
            if(_timer >= toleranceBetwenShoots) 
            {
                Instantiate(bullet,shootPoint);
                _bulletCounter--;
                _timer = 0;
            }
        }
    }
}