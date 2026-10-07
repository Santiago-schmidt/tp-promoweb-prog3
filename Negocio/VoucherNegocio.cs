using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VoucherNegocio
    {
        public bool ValidarVoucher(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Buscamos si el código existe y si el IdCliente está en NULL (lo que significa que no se usó)[cite: 2]
                datos.setearConsulta("SELECT CodigoVoucher FROM Vouchers WHERE CodigoVoucher = @codigo AND IdCliente IS NULL");
                datos.setearParametro("@codigo", codigoVoucher);
                datos.ejecutarLectura();

                // Si Lector.Read() es true, significa que encontró un registro que cumple las condiciones
                if (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
