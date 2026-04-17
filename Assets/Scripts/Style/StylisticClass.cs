using System;
using UnityEngine;

public static class StylisticClass
{
    public static Color BossItem = new Color(1, 0.173f, 0.227f);
    public static Color CommonItem = new Color(0.003921569f, 0.2941177f, 0);
    public static Color RareItem = new Color(0, 0.165f, 0.58f);
    public static Color LegendaryItem = new Color(0.345098f, 0.2784314f, 0);

    public static Color Day1Encounter = new Color(0.184f, 0.529f, 0.196f);
    public static Color Day2Encounter = new Color(0, 0.478f, 0.49f);
    public static Color Day3Encounter = new Color(0.333f, 0, 0.569f);
    public static Color BossEncounter = new Color(0.345098f, 0.2784314f, 0);

    //modifier strings
    public static String BounceString = "<bounce a=0.4>BOUNCE</bounce>";
    public static String BurnString = "<shake d=0.8 a=1>BURN</shake>";
    public static String CrippleString = "<wave>CRIPPLE</wave>";
    public static String DrawString = "<dangle>DRAW</dangle>";
    public static String ParryString = "<rainb>PARRY</rainb>";
    public static String RestoringString = "<incr f=2>RESTORING</incr>";
    public static String SpikyString = "<swing>SPIKY</swing>";
    public static String PoisonString = "<wiggle>POISON</wiggle>";

    //modifier colors
    public static string BounceColor = "<color=#FFA500FF>";
    public static string BurnColor = "<color=#FFFF00FF>";
    public static string CrippleColor = "<color=#c300ff>";
    public static string DrawColor = "<color=#ff0000>";
    public static string ParryColor = "<color=#FFFAFA>";
    public static string RestoringColor = "<color=#01bb1e>";
    public static string SpikyColor = "<color=#999999>";
    public static string PoisonColor = "<color=#95BA3E>";
    public static string DebuffedColor = "<color=red>";

    // common text elements
    public static string ActivateString = "<color=red>ACTIVATE:</color>";
    public static string ConsumeString = "<color=green>CONSUME:</color>";
    public static string HighLight = "<b>";
    public static string HighLightClose = "</b>";
    public static string SecondaryColor = "<color=red>";

    public static string DamageNumber(int damage)
    {
        return $" <b>{damage}{DamageIcon}</b> ";
    }

    public static string ShieldNumber(int amount)
    {
        return $" <b>{ShieldIcon}{amount}</b> ";
    }

    public static string DebuffedDesc =
        $"{DebuffedColor}<b>Debuffed (Is defended by everything and deals zero damage)</b></color>";
    public static string LaikaDesc =
        "<b>Laika Card (Defends/Is defended by anything but it's number is 0)</b>";
    public static string ShieldDesc =
        $"<b><sprite name=Shield>Shield (reduces damage by a flat amount to no less than 1<sprite name=Damage>)</b>";

    //active items
    public static Color ActiveItemUseInvalid = new Color(0.678f, 0.012f, 0.098f);

    //icons
    public static string DamageIcon = "<sprite name=Damage>";
    public static string HealingIcon = "<sprite name=Healing>";
    public static string RestPoint = "<sprite name=RestPoint>";
    public static string RubleSign = "<sprite name=Ruble>";
    public static string ShieldIcon = "<sprite name=Shield>";
    public static string GrateIcon =
        $"<size={SettingsState.ToolTipFontSizeText + 1}><sprite name=Ruble></size>";
    public static string CrestIcon =
        $"<size={SettingsState.ToolTipFontSizeText + 1}><sprite name=Crest></size>";
}
