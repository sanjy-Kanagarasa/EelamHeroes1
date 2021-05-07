using System;
using System.Collections.Generic;
using Microsoft.JSInterop;
using System.Linq;
using System.Threading.Tasks;

namespace EelamHeroes
{
    public static class FileUtil
    {
        public static void SaveAs(this IJSRuntime js, string filename, byte[] data)
        {
            js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));
        }
    }
}
