using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{

    public const string Is_Walking = "IsWalking";


    Player player;
    Animator playerAnimator;


    private void Start()
    {
        player = GetComponent<Player>();

        if (transform.Find("Body"))
        {
            playerAnimator = transform.Find("Body").GetComponent<Animator>();
        }

        player.Event_OnPlayerMove += Player_Event_OnPlayerMove;
    }


    private void Player_Event_OnPlayerMove(bool _value)
    {
        playerAnimator?.SetBool(Is_Walking, _value);
    }


}
