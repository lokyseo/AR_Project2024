using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Monster
{
    public int id;
    public string name;
    public float hp;
    public float defence;
    public List<Elemental> weaknessElementals = new List<Elemental>();
    public List<Elemental> strongElementals = new List<Elemental>();
    public string animationAddress;

    [Header("º¸»ó")]
    public int dropGold;
    public int dropJam;

    public static implicit operator OnMobIsDead(Monster monster)
    {
        return new OnMobIsDead { monster = monster };
    }

    public Monster Clone()
    {
        Monster monster = new Monster();

        monster.id = id;
        monster.name = name;
        monster.hp = hp;
        monster.defence = defence;

        monster.weaknessElementals = new List<Elemental>(weaknessElementals);
        monster.strongElementals = new List<Elemental>(strongElementals);

        monster.animationAddress = animationAddress;
        monster.dropGold = dropGold;
        monster.dropJam = dropJam;
        return monster;
    }
}

public enum Elemental
{
    None,
    Nomal,
    Fire,
    Water,
    Grass,
    Light,
    Dark
}
