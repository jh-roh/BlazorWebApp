namespace BlazorWebApp.Shared
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}


// git rm -r --cached .vs/BlazorWebApp/DesignTimeBuild/.dtbcache.v2
// git rm -r --cached .vs/BlazorWebApp/v17/.suo
// git rm -r --cached .vs/BlazorWebApp/v17/DocumentLayout.json
// git rm -r --cached .vs/ProjectEvaluation/blazorwebapp.metadata.v7.bin
// git rm -r --cached .vs/ProjectEvaluation/blazorwebapp.projects.v7.bin
// git rm -r --cached BlazorWebApp.Client/obj/Debug/net8.0/BlazorWebApp.Client.AssemblyInfo.cs
// git rm -r --cached BlazorWebApp.Client/obj/Debug/net8.0/BlazorWebApp.Client.AssemblyInfoInputs.cache
// git rm -r --cached BlazorWebApp.Server/obj/Debug/net8.0/BlazorWebApp.Server.AssemblyInfo.cs
// git rm -r --cached BlazorWebApp.Server/obj/Debug/net8.0/BlazorWebApp.Server.AssemblyInfoInputs.cache
// git rm -r --cached BlazorWebApp.Shared/obj/Debug/net8.0/BlazorWebApp.Shared.AssemblyInfo.cs
// git rm -r --cached BlazorWebApp.Shared/obj/Debug/net8.0/BlazorWebApp.Shared.AssemblyInfoInputs.cache


//.gitignore가 제대로 동작하지 않을 경우
//git rm -r --cached .
//git add .
//git commit -m "fixed untracked files"