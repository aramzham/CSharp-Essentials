using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Asynchronous.EventBasedModelToTask
{
    class Program
    {
        static List<string> _urls = new List<string>()
        {
            "https://www.flashscore.com/", "https://www.duolingo.com/learn", "https://www.wildberries.am/brands/reebok"
        };

        static async Task Main(string[] args)
        {
            var requests = new List<Task<string>>();
            _urls.ForEach(x => requests.Add(AwaitWebClient(x)));
            
            AwaitWebClient(_urls[0]); // warning
            var result0 = AwaitWebClient(_urls[0]); // no warning
            AwaitWebClient(_urls[0]).NoWarning(); // no warning

            Log();
            
            // Continue AS EACH task completes
            while (requests.Count > 0)
            {
                // Process each completed response sequentially
                var response = await Task.WhenAny(requests);
                requests.Remove(response); // Remove the completed task from the collection
                // Process a single client's response
                Console.WriteLine(response.Result.Length);
            }
        }

        private static async Task<string> AwaitWebClient(string uri)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            // The System.Net.WebClient class supports the Event­based Asynchronous Pattern
            using (var wc = new WebClient())
            {
                // Create the TaskCompletionSource and its underlying Task object
                var tcs = new TaskCompletionSource<string>();
                // When a string completes downloading, the WebClient object raises the
                // DownloadStringCompleted event, which completes the TaskCompletionSource
                wc.DownloadStringCompleted += (s, e) =>
                {
                    if (e.Cancelled) tcs.SetCanceled();
                    else if (e.Error != null) tcs.SetException(e.Error);
                    else tcs.SetResult(e.Result);
                };
                // Start the asynchronous operation
                wc.DownloadStringAsync(new Uri(uri));
                // Now, we can the TaskCompletionSource’s Task and process the result as usual
                var result = await tcs.Task;
                // Process the resulting string (if desired)...
                return result;
            }
        }

        static void Log([CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = -1)
        {
            Console.WriteLine($"callerMemberName = {callerMemberName}, callerFilePath = {callerFilePath}, callerLineNumber = {callerLineNumber}");
        }
        
        // [CallerMemberName] String callerMemberName = null,
        // [CallerFilePath] String callerFilePath = null,
        // [CallerLineNumber] Int32 callerLineNumber = ­1
    }
}