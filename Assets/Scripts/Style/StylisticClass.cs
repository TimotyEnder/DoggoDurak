using System;
using UnityEngine;

public static class StylisticClass
{
    public static Color BossItem = new Color(0.345098f, 0, 0.022939f);
    public static Color CommonItem = new Color(0.003921569f, 0.2941177f, 0);
    public static Color RareItem = new Color(0, 0.165f, 0.58f);
    public static Color LegendaryItem = new Color(0.345098f, 0.2784314f, 0);

    public static Color Day1Encounter = new Color(0.184f, 0.529f,0.196f);  
    public static Color Day2Encounter = new Color(0, 0.478f, 0.49f);
    public static Color Day3Encounter = new Color(0.333f, 0, 0.569f);
    public static Color BossEncounter = new Color(0.345098f, 0.2784314f, 0);
    //modifier strings
    public static String BounceString="<bounce  a=0.4>BOUNCE</bounce>";
    public static String BurnString= "<shake d=0.8 a=1>BURN</shake>";
    public static String CrippleString="<wave>CRIPPLE</wave>";
    public static String DrawString="<dangle>DRAW</dangle>";
    public static String ParryString="<rainb>PARRY</rainb>";
    public static String RestoringString="<incr f=2>RESTORING</incr>";
    public static String SpikyString= "<swing>SPIKY</swing>";
    
    //modifier colors
    public static String BounceColor="<color=orange>";
    public static String BrunColor="<color=yellow>";
    public static String CrippleColor="<color=purple>";
    public static String DrawColor="<color=red>";
    public static String ParryColor="<color=white>";
    public static String RestoringColor="<color=green>";
    public static String SpikyColor="<color=grey>";




    


}
