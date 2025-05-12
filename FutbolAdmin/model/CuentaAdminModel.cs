using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace FutbolAdmin.Model {
    public class CuentaAdminModel {
        public int Id_Cuenta { get; set; }
        public string Nombre { get; set; }
        public SecureString Contraseña { get; set; }
    }
}
