using Accounting.Interest.CrossCutting.Exception;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using Accounting.Interest.CrossCutting.Exception.Base;

namespace Accounting.Interest.CrossCutting.Configuration.ExceptionModels
{
    public class DefaultExceptionResponse : IDisposable
    {
        private bool _disposed = false;

        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public DefaultExceptionResponse()
        {
            Notification = new NotificationObject();
        }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("notification")]
        public NotificationObject Notification { get; set; }

        public class NotificationObject
        {
            [JsonProperty("responseCode")]
            public HttpStatusCode ResponseCode { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("details")]
            public System.Exception Details { get; set; }

            [JsonProperty("invalidFields")]
            public IEnumerable<ErrorModel> InvalidFields { get; set; }

            public bool ShouldSerializeDetails() => Details != null;

            public bool ShouldSerializeInvalidFields() => InvalidFields != null;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _safeHandle?.Dispose();

            _disposed = true;
        }
    }
}
