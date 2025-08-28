using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fase3JavierGarcia.Managers
{
    public class DataGridViewManager
    {
        private readonly DataGridView _pilaGrid;
        private readonly DataGridView _colaGrid;
        private readonly DataGridView _listaGrid;

        public DataGridViewManager(DataGridView pilaGrid, DataGridView colaGrid, DataGridView listaGrid)
        {
            _pilaGrid = pilaGrid;
            _colaGrid = colaGrid;
            _listaGrid = listaGrid;
            InitializeGrids();
        }

        private void InitializeGrids()
        {
            _pilaGrid.Columns.Clear();
            _colaGrid.Columns.Clear();
            _listaGrid.Columns.Clear();

            AddColumnsToGrid(_pilaGrid);
            AddColumnsToGrid(_colaGrid);
            AddColumnsToGrid(_listaGrid);
        }

        private void AddColumnsToGrid(DataGridView grid)
        {
            grid.Columns.Add("TipoIdentificacion", "Tipo Identificación");
            grid.Columns.Add("NumeroIdentificacion", "Número Identificación");
            grid.Columns.Add("NombreCompleto", "Nombre Completo");
            grid.Columns.Add("Edad", "Edad");
            grid.Columns.Add("Estrato", "Estrato");
            grid.Columns.Add("TipoAtencion", "Tipo Atención");
            grid.Columns.Add("ValorCopago", "Valor Copago");
            grid.Columns.Add("FechaRegistro", "Fecha Registro");
        }

        public void UpdateGrids(Stack<EstructuraDatosUsuario> pila, Queue<EstructuraDatosUsuario> cola, List<EstructuraDatosUsuario> lista)
        {
            _pilaGrid.Rows.Clear();
            _colaGrid.Rows.Clear();
            _listaGrid.Rows.Clear();

            foreach (var usuario in pila)
            {
                _pilaGrid.Rows.Add(usuario.TipoIdentificacion, usuario.NumeroIdentificacion, usuario.NombreCompleto, usuario.Edad, usuario.Estrato, usuario.TipoAtencion, $"${usuario.ValorCopago:N0}", usuario.FechaRegistro);
            }
            foreach (var usuario in cola)
            {
                _colaGrid.Rows.Add(usuario.TipoIdentificacion, usuario.NumeroIdentificacion, usuario.NombreCompleto, usuario.Edad, usuario.Estrato, usuario.TipoAtencion, $"${usuario.ValorCopago:N0}", usuario.FechaRegistro);
            }
            foreach (var usuario in lista)
            {
                _listaGrid.Rows.Add(usuario.TipoIdentificacion, usuario.NumeroIdentificacion, usuario.NombreCompleto, usuario.Edad, usuario.Estrato, usuario.TipoAtencion, $"${usuario.ValorCopago:N0}", usuario.FechaRegistro);
            }
        }
    }
}