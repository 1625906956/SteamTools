using ReactiveUI;
using System.Application.Services;
using System.Application.UI.Resx;

namespace System.Application.UI.ViewModels
{
    public class ArchiSteamFarmPlusPageViewModel : TabItemViewModel
    {
        readonly IArchiSteamFarmService asfSerivce = DI.Get<IArchiSteamFarmService>();
        public override string Name
        {
            get => AppResources.ArchiSteamFarmPlus;
            protected set { throw new NotImplementedException(); }
        }

        public ArchiSteamFarmPlusPageViewModel()
        {
            IconKey = nameof(ArchiSteamFarmPlusPageViewModel).Replace("ViewModel", "Svg");
        }

        public string? WebUrl => asfSerivce.IPCUrl;

        private string? _CommandString;
        public string? CommandString
        {
            get => _CommandString;
            set => this.RaiseAndSetIfChanged(ref _CommandString, value);
        }

        public void RunOrStopASF()
        {
            if (asfSerivce.IsArchiSteamFarmRuning)
            {
                asfSerivce.StopArchiSteamFarm();
            }
            else
            {
                asfSerivce.RunArchiSteamFarm();
            }
        }

    }
}
