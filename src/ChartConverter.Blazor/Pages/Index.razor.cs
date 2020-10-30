using ChartConverter.Blazor.Models;
using ChartConverter.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartConverter.Blazor.Pages
{
    public partial class Index
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

        Configurator configurator;
        RequestCodeModel requestCodeModel = new RequestCodeModel();

        string status;
        bool isDisabled;

        async Task HandleValidSubmit()
        {
            isDisabled = true;

            configurator.SaveCurrent();

            status = $"Retrieving zip-file from BeastSaber..";

            var requestCode = requestCodeModel.RequestCode.Replace("!bsr", "").Trim();

            var converter = new BeatSaberToCloneHeroConverter(configurator.Config);
            var beatSaberStream = await converter.GetBeatSaverStreamFromRequestCode(requestCode);

            status = $"Converting to Clone Hero zip..";
            StateHasChanged();

            var cloneHeroZip = await converter.GenerateCloneHeroZipStreamFromBeatSaberZipStream(beatSaberStream);

            await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", cloneHeroZip.FileName, "application/octet-stream", cloneHeroZip.Data);

            status = $"Done!";
            requestCodeModel.RequestCode = "";
            isDisabled = false;
            StateHasChanged();
        }
    }
}
