using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FutbolAdmin.Repositories;

namespace FutbolAdmin.ViewModel {
    public class LoginViewModel : ViewModelBase {
        
        protected readonly RepositoryCuentaAdmin _repositoryCuentaAdmin;
        public ICommand LoginCommand { get; }

        public LoginViewModel() {
            _repositoryCuentaAdmin = new RepositoryCuentaAdmin();
            LoginCommand = new ComandoViewModel(execute => ExecuteLogin());
        }

        // Ventana
        protected bool _isViewVisible;
        public bool IsViewVisible {
            get => _isViewVisible;
            set {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        // Datos

        protected string _username;
        public string Username {
            get => _username;
            set {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        protected string _password;
        public string Password {
            get => _password;
            set {
                _password = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public void ExecuteLogin() {
            Console.WriteLine($"Called login for Username: {Username}");
            var cuenta = _repositoryCuentaAdmin.GetByUsername(_username);
            if (cuenta == null) {
                IsViewVisible = false;
            }
            // La vista necesita un mensaje de error con el nombre de abajo
            // MensajeError = "Usuario o contraseña incorrectos";
        }
    }
}
