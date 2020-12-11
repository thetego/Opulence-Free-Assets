//////////////////////////////////////////////
//                                          //
//  Written by thetego (@muratcan.thetego)  //
//                                          //
//////////////////////////////////////////////
using UnityEngine;
using System.Collections.Generic;
using System.IO;


[System.Serializable]
public class Colour
{
    #region Variables
        public string name;
        public byte r,g,b,a;
        public static List<Colour> Colours {get;} = new List<Colour>();
    #endregion
    #region CustomColors
        public static Color32 red {get;} = new Color32(255,0,0,255);
        public static Color32 BlueCrayola {get;} = new Color32(33,118,255,255);
        public static Color32 Sunglow {get;} = new Color32(253,202,64,255);
        public static Color32 Orange {get;} = new Color32(247,125,36,255);
        public static Color32 SpaceBlack {get;} = new Color32(49,57,60,255);
        public static Color32 DarkPurple {get;} = new Color32(39,16,51,255);
        public static Color32 PastelCyan {get;} = new Color32(56,134,151,255);
        public static Color32 ShockingPink {get;} = new Color32(242,109,249,255);
        public static Color32 RoseBonBon {get;} = new Color32(235,75,152,255);
        public static Color32 LibertyPurple {get;} = new Color32(81,88,187,255);
        public static Color32 PrussianBlue {get;} = new Color32(4,53,101,255);
        public static Color32 MaximumGreen {get;} = new Color32(105,143,63,255);
        public static Color32 OxfordBlue {get;} = new Color32(10,18,42,255);
        public static Color32 ArmyGreen {get;} = new Color32(39,59,9,255);
        public static Color32 CuteOrange {get;} = new Color32(199,62,29,255);
        public static Color32 AmaranthRed {get;} = new Color32(218,62,82,255);
        public static Color32 ElectricBlue {get;} = new Color32(142,249,243,255);
        public static Color32 Turquoise {get;} = new Color32(41,231,205,255);
        public static Color32 PinkDick {get;} = new Color32(224,172,213,255);
    #endregion
    public static Color32 NewColour (byte r, byte g, byte b, byte a)
    {
        Color32 clr = new Color32 (r,g,b,a);
        return clr;
    }
    public static void LoadColours()
    {
        string[] lines = File.ReadAllLines(@"Assets/ColourClass/CustomColours.txt");

        int lineCount = File.ReadAllLines(@"Assets/ColourClass/CustomColours.txt").Length;
        string[] words;
        foreach (string item in lines)
        {
            words = item.Split(' ');
            string name = words[0];
            byte r = byte.Parse(words[1]);
            byte g = byte.Parse(words[2]);
            byte b = byte.Parse(words[3]);
            byte a = byte.Parse(words[4]);
            Colours.Add(new Colour(name,r,g,b,a));
        }
    }
    public static void CreateColour (string name,byte r, byte g, byte b, byte a)
    {
        if(Directory.Exists(Application.dataPath+"/ColourClass"))
        {
            if (File.Exists(Application.dataPath+"/ColourClass"+"/CustomColours.txt"))
            {
                File.AppendAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt","\n"+name+" "+r.ToString()+" "+g.ToString()+" "+b.ToString()+" "+a.ToString());
            }
            else 
            {
                File.Create(Application.dataPath+"/ColourClass"+"/CustomColours.txt");
                File.AppendAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt",name+" "+r.ToString()+" "+g.ToString()+" "+b.ToString()+" "+a.ToString());
            }
        }
        else 
        {
            Directory.CreateDirectory(Application.dataPath+"/ColourClass");
            File.Create(Application.dataPath+"/ColourClass"+"/CustomColours.txt");
            File.AppendAllText(Application.dataPath+"/ColourClass"+"/CustomColours.txt",name+" "+r.ToString()+" "+g.ToString()+" "+b.ToString()+" "+a.ToString());
        }
    }
    public Colour (string _name, byte _r,byte _g, byte _b, byte _a)
    {
        name = _name;
        r=_r;
        g=_g;
        b=_b;
        a=_a;
    }
}
