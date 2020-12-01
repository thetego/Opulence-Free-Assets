//////////////////////////////////////////
//Written by thetego (@muratcan.thetego)//
//              Opulence ©              //
//////////////////////////////////////////
using UnityEngine;
public class BoolConverter 
{
    public static int BoolToInt (bool value)
    {
        if (value)
            return 1;
        else
            return 0;
    }
    public static bool IntToBool(int value)
    {
        if (value == 1)
            return true;
        else if (value == 0)
            return false;
        else if (value != 0 && value != 1)
            Debug.LogError("Error : The input value is not equal to 1 or 0 (So automatically assigned false)"); return false;
    }
}
