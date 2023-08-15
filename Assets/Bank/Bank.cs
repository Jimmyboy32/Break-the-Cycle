using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    // variables for bank account management
    [SerializeField] int startingBalance = 150; 

    [SerializeField] int currentBalance;
    public int CurrentBalance {  get { return currentBalance; } }

    // On awake sets starting money as current money
    void Awake()
    {
        currentBalance = startingBalance;
    }

    // Deposit money in bank account
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }
    
    // Withdraw money from bank account
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
