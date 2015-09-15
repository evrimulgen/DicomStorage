using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DicomStorage.WindowsService
{
    public abstract class BackgroundService: IDisposable
    {
        protected Task WorkTask;
        protected CancellationTokenSource TokenSource;
        public static List<BackgroundService> Services = new List<BackgroundService>();

        public virtual void Start()
        {
            TokenSource = new CancellationTokenSource();
            var token = TokenSource.Token;
            WorkTask = Task.Factory.StartNew(workAction, token);
            lock (Services)
                Services.Add(this);
        }

        public virtual void Stop()
        {
            if (WorkTask != null)
            {
                TokenSource.Cancel();
                WorkTask.Wait();
                WorkTask.Dispose();
                WorkTask = null;
                TokenSource.Dispose();
                TokenSource = null;
            }
            lock (Services)
                Services.Remove(this);
        }

        protected abstract void workAction();

        public bool CancellationPending
        {
            get { return TokenSource == null || TokenSource.IsCancellationRequested; }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
