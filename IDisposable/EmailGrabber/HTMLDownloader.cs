using System;
using System.IO;
using System.Net;

namespace EmailGrabber
{
    class HTMLDownloader : IDisposable
    {
        public HTMLDownloader(string path)
        {
            sw = new StreamWriter(path);
        }

        private WebClient wc = new WebClient();
        private StreamWriter sw;
        private bool disposed = false;

        public void Save(string url, string path)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            Uri uriResult;
            if (Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                uriResult = new Uri(url);

                var html = wc.DownloadString(uriResult);

                sw.Write(html);
            }
        }
        #region IDisposable pattern
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    sw.Dispose();
                    wc.Dispose();
                }
                disposed = true;
            }
        }
        ~HTMLDownloader()
        {
            Dispose(false);
        }
        #endregion
    }
}
