using PuntoDeVenta.Data;

namespace PuntoDeVenta.Services
{
    // Este servicio se registrará como Singleton para compartir el estado
    // del empleado logueado en toda la aplicación.
    public class EstadoAutenticacionService
    {
        public Empleado? EmpleadoActual { get; private set; }

        // Evento para notificar a otros componentes cuando cambia el estado
        public event Action? OnChange;

        // --- Propiedades de conveniencia ---
        
        /// ¿Hay un usuario logueado?
        public bool EstaLogueado => EmpleadoActual != null;

        /// ¿El usuario logueado es Administrador?
        public bool EsAdmin => EstaLogueado && 
                             EmpleadoActual?.Puesto?.Equals("Administrador", StringComparison.OrdinalIgnoreCase) == true;


        /// ¿El usuario logueado tiene un puesto aprobado (no está "en espera")?
        public bool EstaAprobado => EstaLogueado &&
                                  EmpleadoActual?.Puesto?.Equals("en espera", StringComparison.OrdinalIgnoreCase) == false;


        public void IniciarSesion(Empleado empleado)
        {
            EmpleadoActual = empleado;
            NotificarCambioDeEstado();
        }

        public void CerrarSesion()
        {
            EmpleadoActual = null;
            NotificarCambioDeEstado();
        }

        private void NotificarCambioDeEstado() => OnChange?.Invoke();
    }
}