using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerAnimator : MonoBehaviour
{
    //ref to anim controller bool, making a const so less chance of error in code
    private const string IS_WALKING = "IsWalking";

    //ref to animator
    private Animator playerAnimator;
    //ref to player
    [SerializeField] private Player player;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        playerAnimator.SetBool(IS_WALKING, player.PlayerIsWalking());
    }
}
