using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json.Linq;
using Playload.App.Services;
using Playload.App.UI;
using System;
using System.DirectoryServices.ActiveDirectory;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Playload.App
{
    public partial class FormMain : Form
    {
        string apiKey = "dd2d278ae9f98cb809b48b0ca7cd84d8";
        private int? selectedPetId = null;
        private string selectedClientId = null;

        public FormMain()
        {
            InitializeComponent();

            //добавляются колонки в таблицу
            dataGridViewPets.Columns.Add("id", "#");
            dataGridViewPets.Columns.Add("alias", "Кличка");
            dataGridViewPets.Columns.Add("breed", "Порода");
            dataGridViewPets.Columns.Add("type", "Вид");
            dataGridViewPets.Columns.Add("sex", "Пол");
            dataGridViewPets.Columns.Add("birthday", "День рождения");

            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке данных: {ex}");
            }

        }

        /// <summary>
        /// Открывает окно настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonSettingAPI_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.FormClosed += FormSettings_FormClosed;
            formSettings.ShowDialog();
        }

        /// <summary>
        /// Ивент для окна настроек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            await LoadData();
        }
        private async void FormAddEdit_FormClosed(object sender,FormClosedEventArgs e)
        {
            await LoadPetsAsync();
        }



        /// <summary>
        /// подгружает клиентов в комбобокс
        /// </summary>
        /// <returns></returns>
        private async Task LoadData()
        {
            Cursor = Cursors.WaitCursor;
            FileService fileService = new FileService();

            string domain = fileService.GetAllDataFromXml().domain;
            string url = $"https://{domain}.vetmanager2.ru";

            ClientService clientService = new ClientService(domain, apiKey);
            var jsonResponse = JObject.Parse(await clientService.GetAllClientsAsync());
            var clients = jsonResponse["data"]["client"];

            comboBoxClients.Items.Clear();
            comboBoxClients.Items.Add("");

            foreach (var clientInfo in clients)
            {
                string lastName = clientInfo["last_name"]?.ToString() ?? "";
                string firstName = clientInfo["first_name"]?.ToString() ?? "";

                if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName))
                {
                    string fullName = $"{lastName} {firstName}";
                    comboBoxClients.Items.Add(fullName);
                }
            }
            Cursor = Cursors.Default;

        }

        /// <summary>
        /// Загружает питомцев пользователя в таблицу
        /// </summary>
        /// <returns></returns>
        private async Task LoadPetsAsync()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (comboBoxClients.SelectedItem == null)
                {
                    Cursor = Cursors.Default;
                    return;
                }
                // Получаем выбранное имя пользователя
                string selectedUser = comboBoxClients.SelectedItem.ToString();
                if (string.IsNullOrEmpty(selectedUser))
                {
                    buttonAdd.Enabled = false;
                    dataGridViewPets.Rows.Clear();
                    return;
                }
                string[] nameParts = selectedUser.Split(' ');
                string lastName = nameParts[0];
                string firstName = nameParts[1];

                FileService fileService = new FileService();
                PetService petService = new PetService(fileService.GetAllDataFromXml().domain, apiKey);
                ClientService clientService = new ClientService(fileService.GetAllDataFromXml().domain, apiKey);

                var userJsonResponse = JObject.Parse(await clientService.GetClientAsyncByFistNameLastName(firstName, lastName));
                var userId = userJsonResponse["data"]["client"][0]["id"].ToString();

                selectedClientId = userId;

                var petsJsonResponse = JObject.Parse(await petService.GetPetsByOwnerIdAsync(userId));

                dataGridViewPets.Rows.Clear();
                buttonAdd.Enabled = true;

                foreach (var pet in petsJsonResponse["data"]["pet"])
                {
                    dataGridViewPets.Rows.Add(pet["id"], pet["alias"], pet["breed"]["title"], pet["type"]["title"], pet["sex"], pet["birthday"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки питомцев: {ex.Message}");
            }
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// включает кнопки при наведении на строку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewPets_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPets.Rows[e.RowIndex];
                selectedPetId = Convert.ToInt32(row.Cells["id"].Value);
                EnableButtons();
            }
           

        }

        /// <summary>
        /// выключает кнопки при наведении на строку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewPets_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
           DisableButtons();
        }

        private async Task DisableButtons()
        {
            await Task.Delay(400);
            buttonDelete.Enabled = false;
            buttonEdit.Enabled = false;

        }

        private async Task EnableButtons()
        {
            await Task.Delay(500);
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
        }

        /// <summary>
        /// Загрузка питомцев при смене значения комбобокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadPetsAsync();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm(selectedPetId.ToString(), selectedClientId);
            addEditForm.FormClosed += FormAddEdit_FormClosed;
            addEditForm.ShowDialog();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm("-1", selectedClientId);
            addEditForm.FormClosed += FormAddEdit_FormClosed;
            addEditForm.ShowDialog();
        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            FileService fileService = new FileService();

            string domain = fileService.GetAllDataFromXml().domain;
            string url = $"https://{domain}.vetmanager2.ru";
            PetService petService = new(url, apiKey);
            await petService.DeletePetAsync(selectedPetId.ToString());
            await LoadPetsAsync();
            Cursor = Cursors.Default;
        }
    }

}
