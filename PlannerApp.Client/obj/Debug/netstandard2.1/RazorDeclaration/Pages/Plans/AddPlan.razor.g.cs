// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace PlannerApp.Client.Pages.Plans
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using PlannerApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using PlannerApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using PlannerApp.Shared.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using PlannerApp.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Code\PlannerApp\PlannerApp.Client\_Imports.razor"
using Tewr.Blazor.FileReader;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Code\PlannerApp\PlannerApp.Client\Pages\Plans\AddPlan.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/plans/add")]
    public partial class AddPlan : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "D:\Code\PlannerApp\PlannerApp.Client\Pages\Plans\AddPlan.razor"
       
    [CascadingParameter]
    private Task<AuthenticationState> authenticationState { get; set; }

    PlanRequest model = new PlanRequest();
    System.IO.Stream fileStream = null;
    string imageContent = string.Empty;
    string fileName = string.Empty;

    bool isBusy = false;

    ElementReference inputReference;

    string message = string.Empty;
    Models.AlertMessageType messageType = Models.AlertMessageType.Success;

    async Task choseFileAsync()
    {
        var allowedExtensions = new string[] { ".jpg", ".png", ".bmp" };

        var file = (await fileReaderService.CreateReference(inputReference).EnumerateFilesAsync()).FirstOrDefault();

        var fileInfo = await file.ReadFileInfoAsync();
        string extension = System.IO.Path.GetExtension(fileInfo.Name);

        if (!allowedExtensions.Contains(extension))
        {
            message = "The chosen file is invalid. Must be .jpg, .png or .bmp.";
            messageType = Models.AlertMessageType.Error;
            return;
        }

        message = null;

        using (var memoryStream = await file.CreateMemoryStreamAsync())
        {
            fileStream = new System.IO.MemoryStream(memoryStream.ToArray());
            fileName = fileInfo.Name;
            imageContent = $"data:{fileInfo.Type};base64, {Convert.ToBase64String(memoryStream.ToArray())}";
        }
    }

    async Task postPlanAsync()
    {
        isBusy = true;

        var userState = authenticationState.Result;
        plansService.AccessToken = userState.User.FindFirst("AccessToken").Value;

        model.CoverFile = fileStream;
        model.FileName = fileName;
        var result = await plansService.PostPlanAsync(model);

        if (result.IsSuccess)
        {
            navigationManager.NavigateTo("/Plans");
        }
        else
        {
            message = result.Message;
            messageType = Models.AlertMessageType.Error;
        }

        isBusy = false;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFileReaderService fileReaderService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PlansService plansService { get; set; }
    }
}
#pragma warning restore 1591
