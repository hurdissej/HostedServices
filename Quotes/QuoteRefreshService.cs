using System;
using System.Threading;
using System.Threading.Tasks;

public class QuoteRefreshService : HostedService
{    
    public QuoteProvider QuoteProvider { get; }
    public const int SecondsBetweenRefresh = 5;
    public QuoteRefreshService(QuoteProvider quoteProvider)
    {
        QuoteProvider = quoteProvider;
    }


    public async override Task ExecuteAsync(CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            await QuoteProvider.UpdateString(token);
            await Task.Delay(TimeSpan.FromSeconds(SecondsBetweenRefresh), token);
        }
    }
}