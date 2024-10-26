using System.Diagnostics;

namespace BitrixReportGen;

public static class ClipboardManager
{
    public static async Task<bool> SetClipboard(string value)
    {
        if (!OperatingSystem.IsWindows()) return false;
        ArgumentNullException.ThrowIfNull(value);

        var clipboardExecutable = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                RedirectStandardInput = true,
                FileName = "clip",
                UseShellExecute = false
            }
        };

        try
        {
            clipboardExecutable.Start();
            await clipboardExecutable.StandardInput.WriteAsync(value); // CLIP uses STDIN as input.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to copy to clipboard! Exception: {ex}");
            return false;
        }
        finally
        {
            clipboardExecutable.StandardInput.Close();
            await clipboardExecutable.WaitForExitAsync();
        }

        return true;
    }
}