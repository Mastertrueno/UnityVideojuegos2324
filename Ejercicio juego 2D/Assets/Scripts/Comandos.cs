using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Comandos : MonoBehaviour
{




}
public interface ICommand
{
    void Execute();
}
public class JumpCommand : ICommand
{
    private readonly Johnmovement player;
    private readonly int jumpforce;
    private readonly AudioClip jumpsound;
    public JumpCommand(Johnmovement player)
    {
        this.player = player;
    }
    public  void Execute()
    {
        Johnmovement.Jump(player.Rigidbody2D, jumpforce, jumpsound);
    }
}
public class ShootCommand : ICommand
{
    private readonly Johnmovement player;
    public ShootCommand(Johnmovement player)
    {
        this.player = player;
    }
    public void Execute()
    {
        Johnmovement.Shoot();
    }
}

