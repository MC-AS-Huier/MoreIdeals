using Hazel;
using NextShip.Api.Patches;

namespace NextShip.Api.Extension;

public class PasswordVerification
{
    public static bool Enable { get; private set; }

    public static int Password;

    public static void UseVerification()
    {
        Enable = true;
        _Harmony.PatchAll(typeof(InnerNetClientPatch));
    }

    public static void Write(ref MessageWriter writer)
    {
        if (Password == 0) return;
        var messageString = $"Password:{Password.ToString()}";
        writer.Write(messageString);
    }
}