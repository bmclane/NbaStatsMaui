using CommunityToolkit.Mvvm.ComponentModel;
using NbaStatsMaui.Interfaces;

namespace NbaStatsMaui.ViewModels
{
    public partial class BaseViewModel : ObservableObject, IBaseViewModel, IDisposable
    {
        private readonly SemaphoreSlim _isBusyLock = new(1, 1);

        private bool _isInitialized;
        private bool _isBusy;
        private bool _disposedValue;

        public bool IsInitialized
        {
            get => _isInitialized;
            set => SetProperty(ref _isInitialized, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            private set => SetProperty(ref _isBusy, value);
        }

        public INbaApiService NbaApiService
        {
            get;
            private set;
        }

        public BaseViewModel(INbaApiService nbaApiService)
        {
            NbaApiService = nbaApiService;
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task IsBusyFor(Func<Task> unitOfWork)
        {
            await _isBusyLock.WaitAsync();

            try
            {
                IsBusy = true;

                await unitOfWork();
            }
            finally
            {
                IsBusy = false;
                _isBusyLock.Release();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _isBusyLock?.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}
