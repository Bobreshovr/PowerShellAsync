using System.Management.Automation;
using System.Threading.Tasks;

namespace PowerShellAsync
{
    public static class PowerShellAsyncExtention
    {
        public async static Task<PSDataCollection<T2>> InvokeAsync<T1, T2>(this PowerShell source, PSDataCollection<T1> inputCollection)
        {
            PSDataCollection<T2> outputCollection = new PSDataCollection<T2>();
            var asyncResult = source.BeginInvoke<T1, T2>(inputCollection, outputCollection);

            var factory = new TaskFactory();

            await factory.FromAsync(asyncResult, x => x);

            return outputCollection;
        }

        public async static Task<PSDataCollection<T1>> InvokeAsync<T1>(this PowerShell source)
        {
            return await source.InvokeAsync<PSObject, T1>(null);
        }

        public async static Task InvokeAsync(this PowerShell source)
        {
            var asyncResult = source.BeginInvoke();

            var factory = new TaskFactory();

            await factory.FromAsync(asyncResult, x => x);
        }

        public async static Task StopAsync(this PowerShell source)
        {

            var asyncResult = source.BeginStop(null, null);

            var factory = new TaskFactory();

            await factory.FromAsync(asyncResult, x => x);
        }
    }
}
