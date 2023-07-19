using System;
using System.Collections.Generic;
using System.Linq;
using NextShip.Net;

namespace NextShip.Updates;

public static class VersionManager
{
    // Github链接
    public const string GithubUrl = "https://github.com/NextShipAU/NextShip";

    // Gitee链接
    public const string GiteeUrl = "https://gitee.com/mc-huier-sgss/NextShip";

    // CDN
    public const string jsdelivrUrl = "https://cdn.jsdelivr.net/gh/NextShipAU/NextShip";

    // 构建件存放
    public const string nightlyUrl = "https://nightly.link/NextShipAU/NextShip/workflows/Build-Release/main";

    // 服务器alist
    public const string alistUrl = "http://pan.pafyx.top/TIS";

    // 2018k.cnAPI
    public const string KApiUrl = "http://api.2018k.cn";

    public const string KApiId = "FC912F87DE524E5393F6F35B66B8ACEB";

    // HUdate=HasUpdate 判断是否有更新
    public static bool HUpdate;

    public static readonly List<(string, Download)> URLs = new()
    {
        (GithubUrl, Download.Github),
        (GiteeUrl, Download.Gitee),
        (jsdelivrUrl, Download.Jsdelivr),
        (nightlyUrl, Download.Nightly),
        (alistUrl, Download.Alist)
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

    public static Download GetDownloadEnum()
    {
        var pingInfos = GetDownLoadUrlPingInfo();
        var values = pingInfos.Values.ToList();
        values.Sort(
            (n1, n2) =>
            {
                if (n1.pingTime > n2.pingTime)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            );

        return pingInfos.First(n => n.Value == values[0]).Key;
    }

    public static Dictionary<Download, PingInfo> GetDownLoadUrlPingInfo()
    {
        Dictionary<Download, PingInfo> pingInfos = new Dictionary<Download, PingInfo>();
        pingInfos.Add(Download.Github, PingUtils.Ping("github.com"));
        pingInfos.Add(Download.Gitee, PingUtils.Ping("Gitee.com"));
        pingInfos.Add(Download.Alist, PingUtils.Ping("pan.pafyx.top"));
        pingInfos.Add(Download.Nightly, PingUtils.Ping("nightly.link"));
        pingInfos.Add(Download.Jsdelivr, PingUtils.Ping("jsdelivr.net"));
        return pingInfos;
    }
    
    public enum Download
    {
        Github,
        Gitee,
        Jsdelivr,
        Nightly,
        Alist
    }
}