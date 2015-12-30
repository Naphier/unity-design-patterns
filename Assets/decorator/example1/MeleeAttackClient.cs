using UnityEngine;
using System.Collections;
using Assets.decorator.example1;

public class MeleeAttackClient : MonoBehaviour
{
    public ParticleSystem kiParticles;
    MeleeAttack baseMeleeAttack;
    MeleeDecorator hardPunch;
    MeleeDecorator kiPunch;
    MeleeDecorator superKiPunch;
        
    void Start()
    {
        baseMeleeAttack = new BaseMelee();

        hardPunch = new HardPunch();
        hardPunch.SetMeleeAttack(baseMeleeAttack);

        kiPunch = new KiPunch(kiParticles);
        kiPunch.SetMeleeAttack(baseMeleeAttack);

        // Set up the Super Ki Punch
        HardPunch hpDeco = new HardPunch();
        hpDeco.SetMeleeAttack(baseMeleeAttack);
        superKiPunch = hpDeco;
        KiPunch kpDeco = new KiPunch(kiParticles);
        kpDeco.SetMeleeAttack(superKiPunch);
        superKiPunch = kpDeco;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Debug.Log("Base attack value: " + baseMeleeAttack.Attack());

        if (Input.GetKeyDown(KeyCode.W))
            Debug.Log("Hard punch value: " + hardPunch.Attack());

        if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("Ki Punch value: " + kiPunch.Attack());

        if (Input.GetKeyDown(KeyCode.R))
            Debug.Log("Super Ki Punch value: " + superKiPunch.Attack());
    }

    void OnGUI()
    {
        string label = "Q = Base attack\nW = Hard Punch\nE = Ki Punch\nR = Super Ki Punch";

        GUI.Label(new Rect(0, 0, 500, 500), label);
    }
}
