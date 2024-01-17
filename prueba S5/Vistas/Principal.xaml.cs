using prueba_S5.Models;
using System;
using System.Collections.Generic;


namespace prueba_S5.Vistas
{
    public partial class Principal : ContentPage
    {
        private Persona selectedPerson;
        private bool isEditing;

        public Principal()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = "";
            App.personaRepo.AddNewPerson(txtName.Text);
            StatusMessage.Text = App.personaRepo.StatusMessague;
            
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = "";
            List<Persona> people = App.personaRepo.GetAllPeople();
            ListaPersona.ItemsSource = people;
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var person = (Persona)button.BindingContext;

            bool answer = await DisplayAlert("Confirmaci�n", $"�Est�s seguro de que deseas eliminar a {person.Name}?", "S�", "No");

            if (answer)
            {
                App.personaRepo.DeletePerson(person.Id);
                btnMostrar_Clicked(sender, e); // Actualizar la lista despu�s de eliminar la persona
            }
        }
        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            selectedPerson = (Persona)button.BindingContext;
            txtName.Text = selectedPerson.Name;
        }
        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var person = (Persona)button.BindingContext;
            if (selectedPerson != null && !string.IsNullOrEmpty(txtName.Text))
            {
                string newName = txtName.Text;
                App.personaRepo.UpdatePerson(selectedPerson.Id, newName);
                StatusMessage.Text = App.personaRepo.StatusMessague;
                txtName.Text = string.Empty;

                await DisplayAlert("Alerta", "Acaba de recibir una modificaci�n", "Aceptar");
                btnMostrar_Clicked(sender, e); // Actualizar la lista despu�s de guardar los cambios
            }
        }


    }
}
