using System;
using System.Collections.Generic;

namespace TheIdealShip.Updates;

public static class VersionManager
{
    // Github链接
    public const string GithubUrl = "https://github.com/TheIdealShipAU/TheIdealShip";

    // Gitee链接
    public const string GiteeUrl = "https://gitee.com/mc-huier-sgss/TheIdealShip";

    // CDN
    public const string jsdelivrUrl = "https://cdn.jsdelivr.net/gh/TheIdealShipAU/TheIdealShip";

    // 构建件存放
    public const string nightlyUrl = "https://nightly.link/TheIdealShipAU/TheIdealShip/workflows/Build-Release/main";

    // 服务器alist
    public const string alistUrl = "http://pan.pafyx.top/TIS";

    // 2018k.cnAPI
    public const string KApiUrl = "http://api.2018k.cn";

    public const string KApiId = "FC912F87DE524E5393F6F35B66B8ACEB";

    // HUdate=HasUpdate 判断是否有更新
    public static bool HUpdate;

    public static readonly List<(string, string)> URLs = new()
    {
        (GithubUrl, "Github"),
        (GiteeUrl, "Gitee"),
        (jsdelivrUrl, "JsdelivrUrl"),
        (nightlyUrl, "Nightly"),
        (alistUrl, "Alist")
    };

    public static Version lastVersion;
    public static Version NowVersion;

    private static string KApi_addId(this string URL)
    {
        return URL + "?id=" + KApiId;
    }

    private static string KApi_addCheckVersion(this string URL)
    {
        return URL + "/checkVersion";
    }

    private static string KApi_addGetInfo(this string URL)
    {
        return URL + "/getExample";
    }

    public static void VersionCheck()
    {
    }

    // 使用Github检查更新
    public static bool GithubVersionCheck(string URL)
    {
        return false;
    }

    // 使用Gitee检测更新
    public static bool GiteeVersionCheck(string URL)
    {
        return false;
    }

    // 使用2018k.cn检测更新
    public static bool KVersionCheck(string URL)
    {
        Msg("", MethodUtils.GetClassName());
        return false;
    }
}