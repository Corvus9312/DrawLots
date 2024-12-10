using Microsoft.AspNetCore.Components;

namespace DrawLots.Pages;

public class HomeBase : ComponentBase
{
    protected List<string> Lots = [];

    protected List<string> Result = [];

    protected string NowWinner = string.Empty;

    protected string FontColor = "black";

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        for (int i = 0; i < 49; i++)
        {
            Lots.Add($"{i}");
        }
    }

    protected async Task Draw()
    {
        FontColor = "black";

        var random = new Random();

        var sleepTask = Task.Delay(5000);

        while (!sleepTask.Status.Equals(TaskStatus.RanToCompletion))
        {
            var index = random.Next(0, Lots.Count);
            NowWinner = Lots[index];

            StateHasChanged();

            await Task.Delay(100);
        }

        Result.Add(NowWinner);

        FontColor = "red";
        StateHasChanged();
    }
}