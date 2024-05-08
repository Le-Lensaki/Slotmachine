using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public PlayerStatus status;

    public Bet bet;
    private void Awake()
    {
        PlayerController.instance = this;
        this.status = GetComponent<PlayerStatus>();

        this.bet = GetComponent<Bet>();
    }
}
