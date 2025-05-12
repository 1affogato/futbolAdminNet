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
        private string _errorMessage;
        public bool IsViewVisible {
            get => _isViewVisible;
            set {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
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
                OnPropertyChanged(nameof(Password));
            }
        }

        public void ExecuteLogin() {


            var cuenta = _repositoryCuentaAdmin.GetByUsername(_username);
            if (cuenta != null) {
                if (cuenta.Nombre == _username && cuenta.Contraseña.Equals(_password)) {
                    IsViewVisible = false;
                }
            } else {
                ErrorMessage = "* Invalid Username or Password";
                // La vista necesita un mensaje de error con el nombre de abajo
                // MensajeError = "Usuario o contraseña incorrectos";
            }
        }
    }
}
