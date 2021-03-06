﻿using System;
using System.Windows.Forms;
using HematoLab.Gestores;


namespace HematoLab.Formularios
{
    public partial class FormPacientesTurnosCancelados : MetroFramework.Forms.MetroForm
    {

        GestorTurnos migestor;
        GestorDGV miGestorDGV;
        public string fecha;

        public FormPacientesTurnosCancelados()
        {
            InitializeComponent();
            migestor = new GestorTurnos();
            miGestorDGV = new GestorDGV();
        }

        private void FormPacientesTurnosCancelados_Load(object sender, EventArgs e)
        {
            miGestorDGV.efectosDGV(dataGridView1);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "select * from VistaturnosCancelados where Fecha like '%"+fecha+"%' order by 1";
                miGestorDGV.cargarDataGrid(dataGridView1, consulta);

                if (dataGridView1.Rows.Count == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "No hay datos para mostrar");
                }

            }
            catch (Exception exc)
            {
                MetroFramework.MetroMessageBox.Show(this, "No se pudo obtener los datos: " + exc.ToString(), "Error al obtener los datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
