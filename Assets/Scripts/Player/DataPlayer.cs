﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * - Crear un component que recopila dades del personatge: 
 * Nom, Cognom, Tipus de personatge, alçada, velocitat, 
 * distància a recórrer. Aquest component ha de ser consultat 
 * per altres classes i editable des de l'inspector.
 * 
 * - Associar velocitat i pes: el personatge anirà més lent 
 * caminant com més gran sigui la variable "weight" del 
 * component "DataPlayer". La velocitat del personatge és 
 * inversament proporcional al pes del personatge.
 * 
 * Mort: si el enemic toca al jugador aquest  l'enemic s'elimina i 
 * el player perd una vida. Si l'enemic toca a un altre enemic els dos 
 * s'eliminen. Si player perd dos vides s'acaba el joc. Si el joc s'acaba
 * torna a iniciar-se la partida.
 * */

public enum PlayerKind
{
    Sorcerer,
    Assassin,
    Barbarian,
    AstroGuy
}

public class DataPlayer : MonoBehaviour
    
{

    [SerializeField]
    private string Name, Surname;

    [SerializeField]
    private float Height, Speed, JumpSpeed, Weight;

    [SerializeField]
    private PlayerKind PlayerKind;

    [SerializeField]
    private int _hearts;
    public int Hearts { get { return _hearts; } }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetSpeed()
    {
        return Speed;
    }

    public float GetJumpSpeed()
    {
        return JumpSpeed;
    }

    public float GetWeight()
    {
        return Weight;
    }

    public float GetHeight()
    {
        return Height;
    }

    public void SetSpeed(float newSpeed)
    {
        Speed = newSpeed;
    }

    public string GetName()
    {
        return Name;
    }

    public PlayerKind GetKind()
    {
        return PlayerKind;
    }

    public void TakeDamage(int amount)
    {
        _hearts -= amount;
        if (!IsPlayerAlive())
        {
            Die();
        }
    }

    private bool IsPlayerAlive()
    {
        if (_hearts > 0) return true; else return false;
    }

    public int GetHearts()
    {
        return Hearts;
    }

    public void Die()
    {
        Debug.Log("Player SHOULD DIE");
        GameManager.Instance.GameOver();
    }

    private void OnDestroy()
    {
        
    }

}