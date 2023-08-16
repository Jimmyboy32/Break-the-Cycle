using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    // variables for bank account management
    [SerializeField] int startingBalance = 150; 

    [SerializeField] int currentBalance;
    public int CurrentBalance {  get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;

    // On awake sets starting money as current money
    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    // Deposit money in bank account
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }
    
    // Withdraw money from bank account
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            // Game over
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
