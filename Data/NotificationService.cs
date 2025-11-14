using System;
using System.Threading;
using System.Threading.Tasks;

public class NotificationService
{
    private readonly object _lock = new();
    private CancellationTokenSource? _cts;

    public event Action? OnChange;

    public string Message { get; private set; } = "";
    public string Tipo { get; private set; } = "info";
    public bool Visible { get; private set; } = false;

    public async Task SetMessage(string message, string tipo = "info", int durationMs = 3000)
    {
        if (string.IsNullOrEmpty(message)) return;

        lock (_lock)
        {
            // Cancelar temporizador previo
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            Message = message;
            Tipo = tipo;
            Visible = true;
        }

        NotifyStateChanged();

        try
        {
            await Task.Delay(durationMs, _cts.Token);
            // Si no fue cancelado, limpiar
            lock (_lock)
            {
                if (!_cts.IsCancellationRequested)
                {
                    Visible = false;
                    Message = "";
                }
            }
            NotifyStateChanged();
        }
        catch (TaskCanceledException)
        {
            // Temporizador cancelado por nuevo mensaje o ClearMessage
        }
    }

    public void ClearMessage()
    {
        lock (_lock)
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;

            Message = "";
            Tipo = "info";
            Visible = false;
        }
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        try
        {
            OnChange?.Invoke();
        }
        catch (Exception)
        {
            // No permitimos que una excepción en un handler rompa el servicio.
            // Registra si quieres la excepción en logs.
        }
    }
}
