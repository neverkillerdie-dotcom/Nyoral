using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Unity.Services.CloudCode.Apis;
using Unity.Services.CloudCode.Core;
using Unity.Services.CloudSave.Model;

namespace HelloWorld;

public class MyModule
{
    readonly IGameApiClient m_GameApiClient;
    readonly ILogger<MyModule> m_Logger;

    // currentSkin 번호와 반드시 같은 순서여야 함
    private static readonly string[] fandomKeys =
    {
        "Qndeoddl",   // currentSkin 0
        "akfh",       // currentSkin 1
        "clzh",       // currentSkin 2
        "dkfmsid",    // currentSkin 3
        "dlskfl",     // currentSkin 4
        "goenddl",    // currentSkin 5
        "qkzn",       // currentSkin 6
        "qlsmfdl",    // currentSkin 7
        "vldpssk",    // currentSkin 8
        "vpxh",       // currentSkin 9
        "znflal"      // currentSkin 10
    };

    public MyModule(
        IGameApiClient gameApiClient,
        ILogger<MyModule> logger)
    {
        m_GameApiClient = gameApiClient;
        m_Logger = logger;
    }

    [CloudCodeFunction("SayHello")]
    public string Hello(string name)
    {
        return $"Hello, {name}!";
    }

    [CloudCodeFunction("GetServerTime")]
    public string GetServerTime(IExecutionContext context)
    {
        return DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
    }

    [CloudCodeFunction("UpdateFandomScore")]
    public async Task<long> UpdateFandomScore(
        IExecutionContext context,
        int currentSkin,
        int increment)
    {
        // 없는 스킨 번호가 들어오는 것 방지
        if (currentSkin < 0 || currentSkin >= fandomKeys.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(currentSkin));
        }

        // 음수 점수 추가 방지
        if (increment < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(increment));
        }

        string key = fandomKeys[currentSkin];

        var result =
            await m_GameApiClient.CloudSaveData.GetCustomItemsAsync(
                context,
                context.ServiceToken,
                context.ProjectId,
                "FandomRanking",
                new List<string> { key }
            );

        var item = result.Data.Results[0];

        long currentScore = (long)item.Value;

        long newScore = currentScore + increment;

        await m_GameApiClient.CloudSaveData.SetCustomItemAsync(
            context,
            context.ServiceToken,
            context.ProjectId,
            "FandomRanking",
            new SetItemBody(
                key,
                newScore,
                item.WriteLock
            )
        );

        return newScore;
    }
    [CloudCodeFunction("GetFandomScores")]
    public async Task<List<long>> GetFandomScores(IExecutionContext context)
    {
        var result =
            await m_GameApiClient.CloudSaveData.GetCustomItemsAsync(
                context,
                context.ServiceToken,
                context.ProjectId,
                "FandomRanking",
                new List<string>(fandomKeys)
            );

        Dictionary<string, long> scoreByKey = new Dictionary<string, long>();

        foreach (var item in result.Data.Results)
        {
            scoreByKey[item.Key] = (long)item.Value;
        }

        List<long> scores = new List<long>();

        foreach (string key in fandomKeys)
        {
            if (scoreByKey.TryGetValue(key, out long score))
            {
                scores.Add(score);
            }
            else
            {
                scores.Add(0);
            }
        }

        return scores;
    }
}