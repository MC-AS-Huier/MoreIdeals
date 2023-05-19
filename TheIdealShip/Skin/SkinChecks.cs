using System.Collections.Generic;
using System.IO;

namespace TheIdealShip
{
    public static class SkinChecks
    {
        public static string TORFolderName = "TheOtherHats";
        public static string[] TORHatStrings;
        public static bool TORCheck()
        {
            if (Directory.Exists(GetPatch(TORFolderName)))
            {
                TORHatStrings = Directory.GetFiles(GetPatch(TORFolderName), ".png");
                return true;
            }
            return false;
        }

        public static string ExtremeHatFolderName = "ExtremeHat";
        public static bool ExtremeCheck()
        {
            if (Directory.Exists(GetPatch(ExtremeHatFolderName)))
            {
                TORHatStrings = Directory.GetFiles(GetPatch(TORFolderName), ".png");
                return true;
            }
            return false;
        }

        public static string GetPatch(string name) => "./" + name;
    }
}